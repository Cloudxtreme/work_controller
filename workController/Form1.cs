using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Security;
using Titanium.Web.Proxy.EventArguments;
using Titanium.Web.Proxy.Exceptions;
using Titanium.Web.Proxy.Helpers;
using Titanium.Web.Proxy.Http;
using Titanium.Web.Proxy.Models;
using System.Collections.Concurrent;
using Titanium.Web.Proxy;

namespace workController
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private object lockObj = new object();

        private ProxyServer proxyServer;
        private IDictionary<Guid, HeaderCollection> requestHeaderHistory = new ConcurrentDictionary<Guid, HeaderCollection>();
        private IDictionary<Guid, HeaderCollection> responseHeaderHistory = new ConcurrentDictionary<Guid, HeaderCollection>();

        private ExplicitProxyEndPoint explicitEndPoint;

        public static List<string> whitelist = new List<string>();
        public static List<string> blocktimes = new List<string>();

        bool proxyStarted = false;

        void ProxyTestController()
        {
            proxyServer = new ProxyServer();

            proxyServer.ExceptionFunc = exception =>
            {
                lock (lockObj)
                {
                    /*var color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (exception is ProxyHttpException phex)
                    {
                        Console.WriteLine(exception.Message + ": " + phex.InnerException?.Message);
                    }
                    else
                    {
                        Console.WriteLine(exception.Message);
                    }

                    Console.ForegroundColor = color;*/
                }
            };
            proxyServer.ForwardToUpstreamGateway = true;
            proxyServer.CertificateManager.SaveFakeCertificates = true;
        }

        public void StartProxy()
        {
            ProxyTestController();

            proxyServer.BeforeRequest += OnRequest;
            proxyServer.BeforeResponse += OnResponse;

            proxyServer.ServerCertificateValidationCallback += OnCertificateValidation;
            proxyServer.ClientCertificateSelectionCallback += OnCertificateSelection;
            
            explicitEndPoint = new ExplicitProxyEndPoint(IPAddress.Any, Properties.Settings.Default.port);
            
            explicitEndPoint.BeforeTunnelConnectRequest += OnBeforeTunnelConnectRequest;
            explicitEndPoint.BeforeTunnelConnectResponse += OnBeforeTunnelConnectResponse;

            proxyServer.AddEndPoint(explicitEndPoint);
            try
            {
                proxyServer.Start();
                foreach (var endPoint in proxyServer.ProxyEndPoints)
                {
                    AppndText("Listening on " + endPoint.GetType().Name + " endpoint at Ip " + endPoint.IpAddress + " and port: " + endPoint.Port, Color.Black);
                }
                proxyServer.SetAsSystemProxy(explicitEndPoint, ProxyProtocolType.AllHttp);
                proxyStarted = true;
                sTARTToolStripMenuItem.Enabled = false;
                sTOPToolStripMenuItem.Enabled = true;
            }
            catch
            {
                AppndText("Proxy is already running", Color.Red);
            }
        }

        public void Stop()
        {
            AppndText("Stopping proxy server.", Color.Black);
            explicitEndPoint.BeforeTunnelConnectRequest -= OnBeforeTunnelConnectRequest;
            explicitEndPoint.BeforeTunnelConnectResponse -= OnBeforeTunnelConnectResponse;

            proxyServer.BeforeRequest -= OnRequest;
            proxyServer.BeforeResponse -= OnResponse;
            proxyServer.ServerCertificateValidationCallback -= OnCertificateValidation;
            proxyServer.ClientCertificateSelectionCallback -= OnCertificateSelection;

            proxyServer.Stop();
        }

        private async Task OnBeforeTunnelConnectRequest(object sender, TunnelConnectSessionEventArgs e)
        {
            string hostname = e.WebSession.Request.RequestUri.Host;
            //AppndText("Tunnel to: " + hostname,Color.Black);

            if (hostname.Contains("dropbox.com"))
            {
                //Exclude Https addresses you don't want to proxy
                //Useful for clients that use certificate pinning
                //for example dropbox.com
                e.DecryptSsl = false;
            }
        }

        private async Task OnBeforeTunnelConnectResponse(object sender, TunnelConnectSessionEventArgs e)
        {

        }
        
        private async Task OnRequest(object sender, SessionEventArgs e)
        {
            bool skip = false;
            bool itsTime = false;

            //AppndText(e.WebSession.Request.Url,Color.Black);
            requestHeaderHistory[e.Id] = e.WebSession.Request.Headers;

            foreach (string times in blocktimes)
            {
                string[] t = times.Split('-');
                if (Convert.ToInt32(DateTime.Now.ToString("HHmmss")) > Convert.ToInt32(t[0].Replace(":", "")) || Convert.ToInt32(DateTime.Now.ToString("HHmmss")) < Convert.ToInt32(t[1].Replace(":", "")))
                {
                    itsTime = true;
                    break;
                }
                else
                    AppndText("[DEBUG] Checking block time: " + t[0] + "-" + t[1] + ". Current time is " + DateTime.Now.ToString("HH:mm:ss"),Color.Black);
            }

            if (itsTime)
            {
                foreach (string wl in whitelist)
                {
                    //Console.WriteLine("[DEBUG] Checking if URL: " + e.WebSession.Request.RequestUri.AbsoluteUri + " contains:" + wl);
                    if (e.WebSession.Request.RequestUri.AbsoluteUri.Contains(wl))
                    {
                        skip = true;
                        break;
                    }
                }

                if (!skip)
                {
                    e.Ok(Properties.Settings.Default.blockedmsg);
                    AppndText("Website content from " + e.WebSession.Request.RequestUri.AbsoluteUri + " is not on whitelist",Color.Black);
                }
            }

            ////Redirect example
            //if (e.WebSession.Request.RequestUri.AbsoluteUri.Contains("wikipedia.org"))
            //{
            //   e.Redirect("https://www.paypal.com");
            //}
        }
        
        private void MultipartRequestPartSent(object sender, MultipartRequestPartSentEventArgs e)
        {

        }

        private async Task OnResponse(object sender, SessionEventArgs e)
        {
            //WriteToConsole("Active Server Connections:" + ((ProxyServer)sender).ServerConnectionCount);
        }
        
        public Task OnCertificateValidation(object sender, CertificateValidationEventArgs e)
        {
            if (e.SslPolicyErrors == SslPolicyErrors.None)
            {
                e.IsValid = true;
            }

            return Task.FromResult(0);
        }
        
        public Task OnCertificateSelection(object sender, CertificateSelectionEventArgs e)
        {
            return Task.FromResult(0);
        }

        void AppndText(string text, Color color)
        {
            fakeConsole.SelectionStart = fakeConsole.TextLength;
            fakeConsole.SelectionLength = 0;

            fakeConsole.SelectionColor = color;
            fakeConsole.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + text + Environment.NewLine);
            fakeConsole.SelectionColor = fakeConsole.ForeColor;

            fakeConsole.SelectionStart = fakeConsole.Text.Length;
            fakeConsole.ScrollToCaret();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
                string whiteList = Properties.Settings.Default.whitelist;
                AppndText("Whitelisting sites: " + whiteList, Color.Black);
                if (whiteList.Length > 0)
                {
                    if (whiteList.Contains(","))
                    {
                        string[] txt = whiteList.Split(',');
                        foreach (string wl in txt)
                        {
                            whitelist.Add(wl);
                        }
                    }
                    else
                        whitelist.Add(whiteList);
                }
                else
                    AppndText("WARNING: whitelist is empty!",Color.Red);
                
                string blockTimes = Properties.Settings.Default.blocktimes;
                AppndText("blocked times: " + blockTimes, Color.Black);
                if (blockTimes.Length > 0)
                {
                    if (blockTimes.Contains(","))
                    {
                        string[] txt = blockTimes.Split(',');
                        foreach (string wl in txt)
                        {
                            blocktimes.Add(wl);
                        }
                    }
                    else
                        blocktimes.Add(blockTimes);
                }
                else
                    AppndText("WARNING: blocked times are empty!",Color.Red);
                
            StartProxy();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                proxyServer.Stop();
            } catch
            {

            }
        }

        private void whitelistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new whitelist().Show();
        }

        private void blockTimesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new blocktimes().Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Jacob Fliss on 4/23/2018" + Environment.NewLine + "This application uses the Titanium Web Proxy library.", "About Work Controller");
        }

        private void howToSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Open the standard Control Panel (All Items)." + Environment.NewLine + Environment.NewLine + "Internet Options > Connections (tab) > LAN Settings (button)." + Environment.NewLine + Environment.NewLine + "Check the \"Use a proxy server...\" checkbox." + Environment.NewLine + Environment.NewLine + "Press the \"Advanced\" button." + Environment.NewLine + Environment.NewLine + "Fill in HTTP and Secure sections with your PC's IP and port 8000.", "How To Setup Work Controller");
        }

        private void blockedMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new blockedmsg().Show();
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new general().Show();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.toSystemTray)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    Hide();
                    notifyIcon1.Visible = true;
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.startMinimized)
                WindowState = FormWindowState.Minimized;
        }

        private void sTARTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartProxy();
        }

        private void sTOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                proxyServer.Stop();
                proxyStarted = false;
                sTOPToolStripMenuItem.Enabled = false;
                sTARTToolStripMenuItem.Enabled = true;
            }
            catch
            {
                AppndText("ERR: Proxy doesnt exist", Color.Red);
            }
            AppndText("Proxy server has stopped", Color.Red);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
        }
    }
}
