namespace plesklib
{
    using plesklib.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class PleskClient
    {
        private string apiurl;
        private string hostname;
        private string port;
        private string username;
        private string password;

        public PleskClient()
        {

        }

        public PleskClient(string hostname, string username, string password, string port = "8443", bool https = true)
        {
            this.hostname = hostname;
            this.username = username;
            this.password = password;
            this.port = port;
            
            this.apiurl = String.Format("{2}://{0}:{1}/enterprise/control/agent.php", hostname, port, https ? "https" : "http");
        }

        private void Auth(ref HttpWebRequest req)
        {
            req.Timeout = 30000;
            req.Method = "POST";
            req.Headers.Add("HTTP_AUTH_LOGIN", username);
            req.Headers.Add("HTTP_AUTH_PASSWD", password);
            req.ContentType = "text/xml";
        }

        public string SerializeObjectToXmlString<T>(T TModel)
        {
            string xmlData = String.Empty;

            var encoding = new UTF8Encoding(false);    

            XmlSerializerNamespaces EmptyNameSpace = new XmlSerializerNamespaces();
            EmptyNameSpace.Add("", "");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, encoding);
            xmlWriter.Formatting = Formatting.Indented;

            xmlSerializer.Serialize(xmlWriter, TModel, EmptyNameSpace);

            memoryStream = (MemoryStream)xmlWriter.BaseStream;
            xmlData = encoding.GetString(memoryStream.ToArray());

            return xmlData;
        }

        public T DeSerializeObject<T>(string xmlString)
        {
            T deSerializeObject = default(T);

            var xmlSerializer = new XmlSerializer(typeof(T));

            using (var stringReader = new StringReader(xmlString))
            {
                var XR = new XmlTextReader(stringReader);
                
                if (xmlSerializer.CanDeserialize(XR))
                {
                    deSerializeObject = (T)xmlSerializer.Deserialize(XR);
                }
            }
        
            return deSerializeObject;
        }

        private string SendHttpRequest(string meesage)
        {
            var result = String.Empty;
            var bytes = new ASCIIEncoding().GetBytes(meesage);            

            //Bypass SSL validation.
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate
                                                                            (object sender, X509Certificate certificate, X509Chain chain,
                                                                            SslPolicyErrors sslPolicyErrors)
            { return true; };
            
            var request = (HttpWebRequest)WebRequest.Create(this.apiurl);
            Auth(ref request);            
            request.ContentLength = meesage.Length;

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();                
            }

            result = GetResponseContent(request);
            return result;
        }

        private string GetResponseContent(HttpWebRequest request)
        {
            using (StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }

        private Toutput ExecuteWebRequest<Tinput, Toutput>(Tinput apiRequest)
        {
            var response = new ApiResponse();
            response.Status = false;

            var result = Activator.CreateInstance(typeof(Toutput));

            try
            {
                var message = SerializeObjectToXmlString<Tinput>(apiRequest);
                response.ResponseXmlString = SendHttpRequest(message);                
                result = DeSerializeObject<Toutput>(response.ResponseXmlString);

                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.MessageDetails = ex.StackTrace;
            }

            if (!response.Status)
            {
                var output = result as IResponseResult;

                if(output != null)
                    output.SaveResult(response);                
            }

            return (Toutput)result;
        }

        #region Webspace
        public WebSpaceAddResult CreateWebSpace(string name, string ipaddr, string username, string password)
        {
            var prop = new List<HostingProperty>();
            prop.Add(new HostingProperty() { Name = "ftp_login", Value = username });
            prop.Add(new HostingProperty() { Name = "ftp_password", Value = password });

            var add = new WebspaceAddPacket();
            add.webspace.add.genSetup.name = name;
            add.webspace.add.genSetup.ipaddress = ipaddr;
            add.webspace.add.hosting.Properties = prop.ToArray();

            return ExecuteWebRequest<WebspaceAddPacket, WebSpaceAddResult>(add);
        }
        #endregion

        #region Site (Domain)
        public SiteAddResult CreateSite(string name, int webspaceId, bool sslSupport = true, bool dedicatedAppPool = false, bool enableClassicAsp = false , 
                                                     bool enableDotNet = false, bool enableSsi = true, bool enablePhp = false, 
                                                     bool enableCgi = false, bool enablePerl = false, bool enablePython = false, 
                                                     bool enableFastCgi = false, bool enableMiva = false, string Webstat = "none", 
                                                     bool enableErrorDocs = true, bool enableWebDeploy = false)
        {              
            var prop = new List<HostingProperty>();
            prop.Add(new HostingProperty() { Name="ssl", Value = sslSupport ? "true" : "false" });
            prop.Add(new HostingProperty() { Name = "iis_app_pool", Value = dedicatedAppPool ? "true" : "false" });
            prop.Add(new HostingProperty() { Name = "asp", Value = enableClassicAsp ? "true" : "false" });
            prop.Add(new HostingProperty() { Name = "asp_dot_net", Value = enableDotNet ? "true" : "false" });
            prop.Add(new HostingProperty() { Name = "ssi", Value = enableSsi ? "true" : "false" });
            prop.Add(new HostingProperty() { Name = "php", Value = enablePhp ? "true" : "false" });
            prop.Add(new HostingProperty() { Name = "cgi", Value = enableCgi ? "true" : "false" });
            prop.Add(new HostingProperty() { Name = "perl", Value = enablePerl ? "true" : "false" });
            prop.Add(new HostingProperty() { Name = "python", Value = enablePython ? "true" : "false" });
            prop.Add(new HostingProperty() { Name = "fastcgi", Value = enableFastCgi ? "true" : "false" });
            prop.Add(new HostingProperty() { Name = "miva", Value = enableMiva ? "true" : "false" });
            prop.Add(new HostingProperty() { Name = "webstat", Value = Webstat }); // none | webalizer | awstats
            prop.Add(new HostingProperty() { Name = "errdocs", Value = enableErrorDocs ? "true" : "false" });
            prop.Add(new HostingProperty() { Name = "web_deploy", Value = enableWebDeploy ? "true" : "false" });
            
            var add = new SiteAddPacket();
            add.Site.Add.GenSetup.Name = name;
            add.Site.Add.GenSetup.WebSpaceId = webspaceId;
            add.Site.Add.Hosting.Properties = prop.ToArray();

            return ExecuteWebRequest<SiteAddPacket, SiteAddResult>(add);            
        }

        public SiteDelResult DeleteSite(string name)
        {
            var del = new SiteDelPacket();
            del.site.del.filter.Name = name;

            return ExecuteWebRequest<SiteDelPacket, SiteDelResult>(del);
        }

        public SiteGetResult GetSite(string name)
        {
            var get = new SiteGet();
            get.filter.Name = name;

            return ExecuteWebRequest<SiteGet, SiteGetResult>(get);
        }
        #endregion

        #region Alias
        public SiteAliasPacketResult CreateAlias(int siteId, string name, bool enableWeb = true, bool enableMail = false, bool enableTomcat = false)
        {
            var add = new SiteAliasPacket();
            add.siteAlias.createSiteAlias.SiteId = siteId;
            add.siteAlias.createSiteAlias.AliasName = name;
            add.siteAlias.createSiteAlias.pref.web = enableWeb ? "1" : "0";
            add.siteAlias.createSiteAlias.pref.mail = enableMail ? "1" : "0";
            add.siteAlias.createSiteAlias.pref.tomcat = enableTomcat ? "1" : "0";

            return ExecuteWebRequest<SiteAliasPacket, SiteAliasPacketResult>(add);
        }

        public SiteAliasDelResult DeleteAlias(string name)
        {
            var del = new SiteAliasDelPacket();
            del.site.delete.filter.Name = name;

            return ExecuteWebRequest<SiteAliasDelPacket, SiteAliasDelResult>(del);
        }

        #endregion

        #region Subdomain
        public SubdomainAddResult CreateSubdomain(string parent, string name, string homedir, string ftpusername, string ftppassword, 
                                                                                                    bool ssi = false, bool ssiHtml = false)
        {
            var add = new SubdomainAddPacket();
            add.subdomain.add.parentName = parent;
            add.subdomain.add.subdomainName = name;
            add.subdomain.add.homeDir.Value = homedir;
            add.subdomain.add.ftpUsername.Value = ftpusername;
            add.subdomain.add.ftpPassword.Value = ftppassword;
            add.subdomain.add.ssi.Value = ssi ? "true" : "false";
            add.subdomain.add.ssiHtml.Value = ssiHtml ? "true" : "false";

            return ExecuteWebRequest<SubdomainAddPacket, SubdomainAddResult>(add);
        }

        public SubdomainDeleteResult DeleteSubdomain(string name)
        {
            var del = new SubdomainDeletePacket();
            del.subdomain.del.filter.Name = name;

            return ExecuteWebRequest<SubdomainDeletePacket, SubdomainDeleteResult>(del);
        }
        #endregion

        #region Protected Dir
        public ProtectedDirAddResult CreateProtectedDir(int siteId, string name, string headerText, 
                                                                    bool ssl = false, bool nonssl = false, bool cgi = false)
        {
            if (String.IsNullOrEmpty(headerText))
                headerText = "Protected Area";

            var add = new ProtectedDirAddPacket();
            add.protectedDir.add.siteId = siteId;
            add.protectedDir.add.Name = name;
            add.protectedDir.add.Header = headerText;
            add.protectedDir.add.location.cgi.Value = cgi ? "true" : "false";
            add.protectedDir.add.location.ssl.Value = ssl ? "true" : "false";
            add.protectedDir.add.location.nonssl.Value = nonssl ? "true" : "false";

            return ExecuteWebRequest<ProtectedDirAddPacket, ProtectedDirAddResult>(add);
        }

        public ProtectedDirAddUserResult CreateProtectedDirUser(int pdid, string username, string password, string passwordType = "plain")
        {
            var add = new ProtectedDirAddUserPacket();
            add.protectedDir.addUser.Id = pdid;
            add.protectedDir.addUser.username = username;
            add.protectedDir.addUser.password = password;
            add.protectedDir.addUser.passwordType = passwordType;

            return ExecuteWebRequest<ProtectedDirAddUserPacket, ProtectedDirAddUserResult>(add);
        }
        #endregion

        #region Ftp Account
        public FtpUserAddResult AddFtpAccount(string name, string username, string password, string home, int quota)
        {
            var add = new FtpUserAddPacket();
            add.ftpUser.add.wespacename = name;
            add.ftpUser.add.username = username;
            add.ftpUser.add.password = password;
            add.ftpUser.add.home = home;
            add.ftpUser.add.quota = quota;

            return ExecuteWebRequest<FtpUserAddPacket, FtpUserAddResult>(add);
        }

        public FtpUserDelResult DeleteFtpAccount(string name, string username)
        {
            var del = new FtpUserDelPacket();
            del.ftpUser.del.filter.Name = username;
            del.ftpUser.del.filter.webspaceName = name;

            return ExecuteWebRequest<FtpUserDelPacket, FtpUserDelResult>(del);
        }
        #endregion

    }
}
