namespace maestropanel.plesklib
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
    using System.Linq;

    public class PleskClient
    {
        private const string STATUS_OK = "ok";
        private const string STATUS_ERROR = "error";

        private string apiurl;
        private string hostname;
        private string port;
        private string username;
        private string password;
        private int connectioTimeOut;

        public PleskClient()
        {

        }

        public PleskClient(string hostname, string username, string password, string port = "8443", bool https = true, int timeout = 10000)
        {
            this.hostname = hostname;
            this.username = username;
            this.password = password;
            this.port = port;
            this.connectioTimeOut = timeout;
            
            this.apiurl = String.Format("{2}://{0}:{1}/enterprise/control/agent.php", hostname, port, https ? "https" : "http");
        }

        private void Auth(ref HttpWebRequest req)
        {
            req.Timeout = this.connectioTimeOut;
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

                response.RequestXmlString = message;
                response.ResponseXmlString = SendHttpRequest(message);

                response.error = DeSerializeObject<ApiErrorResponse>(response.ResponseXmlString);

                if(String.IsNullOrEmpty(response.error.system.status)) //No Error
                {
                    result = DeSerializeObject<Toutput>(response.ResponseXmlString);
                    if (result != null)
                    {
                        response.Message = "Api communication is successfully";
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = "Result cannot deserialize";                        
                    }
                }                
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.MessageDetails = ex.StackTrace;
            }
            
            var output = result as IResponseResult;

            if(output != null)
                output.SaveResult(response);                          

            return (Toutput)result;
        }

        public ResponseResult ConnectionTest()
        {
            var result = new ResponseResult();
            var listTest = GetIPAddressList();

            result.ErrorCode = listTest.ip.get.result.ErrorCode;
            result.ErrorText = listTest.ip.get.result.ErrorText;
            result.status = listTest.ip.get.result.status;

            return result;
        }

        #region Webspace
        public ResponseResult CreateWebSpace(string owner, string name, string ipaddr, string username, string password, List<HostingProperty> properties)
        {
            var prop = new List<HostingProperty>();
            prop.Add(new HostingProperty() { Name = "ftp_login", Value = username });
            prop.Add(new HostingProperty() { Name = "ftp_password", Value = password });

            if (properties != null)            
                prop.AddRange(properties);
            
            var add = new WebspaceAddPacket();
            add.webspace.add.genSetup.name = name;
            add.webspace.add.genSetup.ipaddress = ipaddr;
            add.webspace.add.genSetup.OwnerLogin = owner;
            add.webspace.add.hosting.Properties = prop.ToArray();
            
            return ExecuteWebRequest<WebspaceAddPacket, WebSpaceAddResult>(add).ToResult();
        }        

        public ResponseResult CreateWebSpace(string name, string ipaddr)
        {
            var add = new WebspaceAddPacket();
            add.webspace.add.genSetup.name = name;
            add.webspace.add.genSetup.ipaddress = ipaddr;

            return ExecuteWebRequest<WebspaceAddPacket, WebSpaceAddResult>(add).ToResult();
        }

        public ResponseResult CreateWebSpace(string name, string ipaddr, List<HostingProperty> properties)
        {
            var prop = new List<HostingProperty>();
            
            if (properties != null)
                prop.AddRange(properties);

            var add = new WebspaceAddPacket();
            add.webspace.add.genSetup.name = name;
            add.webspace.add.genSetup.ipaddress = ipaddr;
            add.webspace.add.hosting.Properties = prop.ToArray();

            return ExecuteWebRequest<WebspaceAddPacket, WebSpaceAddResult>(add).ToResult();
        }

        public ResponseResult CreateWebSpace(string name, string ipaddr, string planName, List<HostingProperty> properties)
        {
            var prop = new List<HostingProperty>();
            
            if (properties != null)
                prop.AddRange(properties);

            var add = new WebspaceAddPacket();
            add.webspace.add.genSetup.name = name;
            add.webspace.add.genSetup.ipaddress = ipaddr;
            add.webspace.add.genSetup.htype = "vrt_hst";
            add.webspace.add.planName = planName;
            add.webspace.add.hosting.Properties = prop.ToArray();

            return ExecuteWebRequest<WebspaceAddPacket, WebSpaceAddResult>(add).ToResult();
        }

        public ResponseResult CreateWebSpace(string customerName, string name, string ipaddr, string planName, string ftpusername, string ftppassword)
        {
            var prop = new List<HostingProperty>();
            prop.Add(new HostingProperty() { Name = "ftp_login", Value = ftpusername });
            prop.Add(new HostingProperty() { Name = "ftp_password", Value = ftppassword });

            var add = new WebspaceAddPacket();
            add.webspace.add.genSetup.name = name;
            add.webspace.add.genSetup.ipaddress = ipaddr;
            add.webspace.add.genSetup.htype = "vrt_hst";
            add.webspace.add.genSetup.OwnerLogin = customerName;
            add.webspace.add.planName = planName;
            add.webspace.add.hosting.Properties = prop.ToArray();
            
            return ExecuteWebRequest<WebspaceAddPacket, WebSpaceAddResult>(add).ToResult();
        }

        public ResponseResult DeleteWebSpace(string name)
        {
            var del = new WebSpaceDelPacket();
            del.webspace.del.filter.Name = name;

            return ExecuteWebRequest<WebSpaceDelPacket, WebSpaceDelResult>(del).ToResult();
        }

        public WebSpaceGetResult GetWebSpace(string name)
        {
            var getSpace = new WebSpaceGetPacket();
            getSpace.webspace.retrieve.filter.name = name;

            return ExecuteWebRequest<WebSpaceGetPacket, WebSpaceGetResult>(getSpace);
        }
        #endregion

        #region Customers
        public ResponseResult CreateCustomer(string username, string password, string email, string fullName, string company, string address, string phone, string fax, string city, string state, string postalCode,string country)
        {
            //var plans = GetServicePlans();
            //var package = plans.Where(m => m.name == packageName).FirstOrDefault();

            //if (package == null)
            //{
            //    var result = new ResponseResult();
            //    result.status = "error";
            //    result.ErrorText = "Package name not found";

            //    return result;
            //}

            var add = new CustomerAddPacket();            
            add.customer.add.info.status = "0";
            add.customer.add.info.LoginName = username;
            add.customer.add.info.Password = password;
            add.customer.add.info.Email = email;
            add.customer.add.info.PersonalName = fullName;
            add.customer.add.info.CompanyName = company;
            add.customer.add.info.Address = address;
            add.customer.add.info.Phone = phone;
            add.customer.add.info.PostalCoe = postalCode;
            add.customer.add.info.State = state;
            add.customer.add.info.Country = country;                        
            add.customer.add.info.Fax = fax;
            add.customer.add.info.City = city;            
            
            return ExecuteWebRequest<CustomerAddPacket, CustomerAddResult>(add).ToResult();
        }
        #endregion

        #region Service Plans
        public ServicePlanItem[] GetServicePlans()
        {
            var recieve = new ServicePlanGetPacket();
            var result =  ExecuteWebRequest<ServicePlanGetPacket, ServicePlanGetResult>(recieve);

            return result.servicePlan.results.ToArray();
        }
        #endregion

        #region Site (Domain)
        public ResponseResult CreateSite(int webspaceId, string name, List<HostingProperty> properties)
        {              
            var prop = new List<HostingProperty>();

            if (properties != null)
                prop.AddRange(properties);

            //prop.Add(new HostingProperty() { Name= "ssl", Value = sslSupport ? "true" : "false" });
            //prop.Add(new HostingProperty() { Name = "iis_app_pool", Value = dedicatedAppPool ? "true" : "false" });
            //prop.Add(new HostingProperty() { Name = "asp", Value = enableClassicAsp ? "true" : "false" });
            //prop.Add(new HostingProperty() { Name = "asp_dot_net", Value = enableDotNet ? "true" : "false" });
            //prop.Add(new HostingProperty() { Name = "ssi", Value = enableSsi ? "true" : "false" });
            //prop.Add(new HostingProperty() { Name = "php", Value = enablePhp ? "true" : "false" });
            //prop.Add(new HostingProperty() { Name = "cgi", Value = enableCgi ? "true" : "false" });
            //prop.Add(new HostingProperty() { Name = "perl", Value = enablePerl ? "true" : "false" });
            //prop.Add(new HostingProperty() { Name = "python", Value = enablePython ? "true" : "false" });
            //prop.Add(new HostingProperty() { Name = "fastcgi", Value = enableFastCgi ? "true" : "false" });
            //prop.Add(new HostingProperty() { Name = "miva", Value = enableMiva ? "true" : "false" });
            //prop.Add(new HostingProperty() { Name = "webstat", Value = Webstat }); // none | webalizer | awstats
            //prop.Add(new HostingProperty() { Name = "errdocs", Value = enableErrorDocs ? "true" : "false" });
            //prop.Add(new HostingProperty() { Name = "web_deploy", Value = enableWebDeploy ? "true" : "false" });
            
            var add = new SiteAddPacket();
            add.Site.Add.GenSetup.Name = name;
            add.Site.Add.GenSetup.WebSpaceId = webspaceId;
            add.Site.Add.Hosting.Properties = prop.ToArray();

            return ExecuteWebRequest<SiteAddPacket, SiteAddResult>(add).ToResult();            
        }

        public ResponseResult DeleteSite(string name)
        {
            var del = new SiteDelPacket();
            del.site.del.filter.Name = name;

            return ExecuteWebRequest<SiteDelPacket, SiteDelResult>(del).ToResult();
        }

        public SiteGetResult GetSite(string name)
        {
            var getsite = new SiteGetPacket();
            getsite.site.get.filter.Name = name;

            return ExecuteWebRequest<SiteGetPacket, SiteGetResult>(getsite);
        }
        #endregion

        #region Alias
        public ResponseResult CreateAlias(int siteId, string name, bool enableWeb = true, bool enableMail = false, bool enableTomcat = false, bool seoredirect = false)
        {
            var add = new SiteAliasAddPacket();
            add.siteAlias.createSiteAlias.SiteId = siteId;
            add.siteAlias.createSiteAlias.AliasName = name;
            //add.siteAlias.createSiteAlias.pref.web = enableWeb ? "1" : "0";
            //add.siteAlias.createSiteAlias.pref.mail = enableMail ? "1" : "0";
            //add.siteAlias.createSiteAlias.pref.tomcat = enableTomcat ? "1" : "0";
            //add.siteAlias.createSiteAlias.pref.seoRedirect = seoredirect ? "1" : "0";

            return ExecuteWebRequest<SiteAliasAddPacket, SiteAliasAddPacketResult>(add).ToResult();
        }

        public ResponseResult CreateAlias(string name, string aliasName, bool enableWeb = true, bool enableMail = false, bool enableTomcat = false, bool seoredirect = false)
        {
            var currentsite = GetSite(name);
            var currentSiteResult = currentsite.ToResult();

            if (currentSiteResult.status != STATUS_OK)            
                return currentSiteResult;            

            var add = new SiteAliasAddPacket();
            add.siteAlias.createSiteAlias.status = "0"; //0 (alias enabled) 1 (alias disabled) 2 (primary site disabled) 3 (alias disabled, primary site disabled) 8 (alias disabled)
            add.siteAlias.createSiteAlias.SiteId = currentsite.site.receive.result.Id;
            add.siteAlias.createSiteAlias.AliasName = aliasName;            
            //add.siteAlias.createSiteAlias.pref.web = enableWeb ? "1" : "0";
            //add.siteAlias.createSiteAlias.pref.mail = enableMail ? "1" : "0";
            //add.siteAlias.createSiteAlias.pref.tomcat = enableTomcat ? "1" : "0";
            //add.siteAlias.createSiteAlias.pref.seoRedirect = seoredirect ? "1" : "0";

            return ExecuteWebRequest<SiteAliasAddPacket, SiteAliasAddPacketResult>(add).ToResult();
        }

        public ResponseResult DeleteAlias(string name)
        {
            var del = new SiteAliasDelPacket();
            del.site.delete.filter.Name = name;

            return ExecuteWebRequest<SiteAliasDelPacket, SiteAliasDelResult>(del).ToResult();
        }
        #endregion

        #region Subdomain
        public ResponseResult CreateSubdomain(string parent, string name, string homedir, string ftpusername, string ftppassword, bool ssi = false, bool ssiHtml = false)
        {
            var add = new SubdomainAddPacket();
            add.subdomain.add.parentName = parent;
            add.subdomain.add.subdomainName = name;
            add.subdomain.add.homeDir.Value = homedir;
            add.subdomain.add.ftpUsername.Value = ftpusername;
            add.subdomain.add.ftpPassword.Value = ftppassword;
            add.subdomain.add.ssi.Value = ssi ? "true" : "false";
            add.subdomain.add.ssiHtml.Value = ssiHtml ? "true" : "false";

            return ExecuteWebRequest<SubdomainAddPacket, SubdomainAddResult>(add).ToResult();
        }

        /// <summary>
        /// Create subdomain for existing domain.
        /// </summary>
        /// <param name="parent">domain.com</param>
        /// <param name="name">sample</param>
        /// <returns></returns>
        public ResponseResult CreateSubdomain(string parent, string name)
        {
            var add = new Subdomain2AddPacket();
            add.subdomain.add.parentName = parent;
            add.subdomain.add.subdomainName = name;

            return ExecuteWebRequest<Subdomain2AddPacket, SubdomainAddResult>(add).ToResult();
        }

        public ResponseResult CreateSubdomain(string parent, string name, string homedir)
        {
            var add = new Subdomain2AddPacket();
            add.subdomain.add.parentName = parent;
            add.subdomain.add.subdomainName = name;
            add.subdomain.add.home = homedir;

            return ExecuteWebRequest<Subdomain2AddPacket, SubdomainAddResult>(add).ToResult();
        }

        public ResponseResult DeleteSubdomain(string name)
        {
            var del = new SubdomainDeletePacket();
            del.subdomain.del.filter.Name = name;

            return ExecuteWebRequest<SubdomainDeletePacket, SubdomainDeleteResult>(del).ToResult();
        }
        #endregion

        #region Protected Dir
        public ResponseResult CreateProtectedDir(int siteId, string name, string headerText, 
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

            return ExecuteWebRequest<ProtectedDirAddPacket, ProtectedDirAddResult>(add).ToResult();
        }

        public ResponseResult CreateProtectedDirUser(int pdid, string username, string password, string passwordType = "plain")
        {
            var add = new ProtectedDirAddUserPacket();
            add.protectedDir.addUser.Id = pdid;
            add.protectedDir.addUser.username = username;
            add.protectedDir.addUser.password = password;
            add.protectedDir.addUser.passwordType = passwordType;

            return ExecuteWebRequest<ProtectedDirAddUserPacket, ProtectedDirAddUserResult>(add).ToResult();
        }
        #endregion

        #region Ftp Account
        public ResponseResult AddFtpAccount(string name, string username, string password, string home, int quota)
        {
            var add = new FtpUserAddPacket();
            add.ftpUser.add.wespacename = name;
            add.ftpUser.add.username = username;
            add.ftpUser.add.password = password;
            add.ftpUser.add.home = home;
            add.ftpUser.add.quota = quota;

            return ExecuteWebRequest<FtpUserAddPacket, FtpUserAddResult>(add).ToResult();
        }

        public ResponseResult DeleteFtpAccount(string name, string username)
        {
            var del = new FtpUserDelPacket();
            del.ftpUser.del.filter.Name = username;
            del.ftpUser.del.filter.webspaceName = name;

            return ExecuteWebRequest<FtpUserDelPacket, FtpUserDelResult>(del).ToResult();
        }
        #endregion

        #region IP Addresses
        public IPAddrGetResult GetIPAddressList()
        {
            var _get = new IPAddrGetPacket();
            _get.ip.get = new IPAddrGetGetNode();

            return ExecuteWebRequest<IPAddrGetPacket, IPAddrGetResult>(_get);
        }
        #endregion

        #region Database
        public ResponseResult CreateDatabase(string name, string databaseName, string databaseType)
        {
            var add = new DatabaseAddPacket();
            add.database.add.name = databaseName;
            add.database.add.type = databaseType;

            return ExecuteWebRequest<DatabaseAddPacket, DatabaseAddResult>(add).ToResult();
        }

        public DatabaseGetResult GetDatabaseList(string name)
        {
            var getDb = new DatabaseGetPacket();
            getDb.database.getDb.filter.webspaceName = name;

            return ExecuteWebRequest<DatabaseGetPacket, DatabaseGetResult>(getDb);
        }

        public ResponseResult DeleteDatabase(string name, string databaseName)
        {
            var result = new ResponseResult();
            result.status = STATUS_ERROR;

            var list = GetDatabaseList(name);

            if (list.databaseList.Any())
            {
                var currentDb = list.databaseList.Where(m => m.result.name == databaseName).FirstOrDefault();

                if (currentDb != null)
                {
                    var del = new DatabaseDelPacket();
                    del.database.del.filter.dbid = currentDb.result.Id;

                    result = ExecuteWebRequest<DatabaseDelPacket, DatabaseDelResult>(del).ToResult();
                }
                else
                {
                    result.ErrorText = "Database not found";
                    result.ErrorCode = 999;
                }
            }
            else
            {                                
                result.ErrorText = "No databases in this domain";                
                result.ErrorCode = 999;
            }

            return result;

        }

        public ResponseResult CreateDatabaseUser(string name, string databaseName, string username, string password, string passwordType = "plain", string role = "readWrite")
        {
            var result = new ResponseResult();
            var list = GetDatabaseList(name);

            if (!list.databaseList.Any())
            {
                result.ErrorText = "No databases in this domain";
                result.ErrorCode = 999;

                return result;
            }

            var currentDb = list.databaseList.Where(m => m.result.name == databaseName).FirstOrDefault();

            if (currentDb == null)
            {
                result.ErrorText = "Database not found in this domain";
                result.ErrorCode = 999;

                return result;
            }

            var add = new DatabaseUserAddPacket();
            add.database.addUser.dbId = currentDb.result.Id;
            add.database.addUser.dbServerId = currentDb.result.dbsServerId;
            add.database.addUser.webSpaceId = currentDb.result.webSpaceId;
            add.database.addUser.login = username;
            add.database.addUser.password = password;
            add.database.addUser.passwordType = passwordType;
            add.database.addUser.role = role;

            return ExecuteWebRequest<DatabaseUserAddPacket, DatabaseUserAddResult>(add).ToResult();
        }

        public DatabaseUserGetResult GetDatabaseUserList(string name, string databaseName)
        {
            var result = new DatabaseUserGetResult();

            var list = GetDatabaseList(name);

            if (!list.databaseList.Any())                            
                return result;
            
            var currentDb = list.databaseList.Where(m => m.result.name == databaseName).FirstOrDefault();

            if (currentDb == null)            
                return result;
            
            var getuser = new DatabaseUserGetPacket();
            getuser.database.users.filter.databaseId = currentDb.result.Id;
            
            return ExecuteWebRequest<DatabaseUserGetPacket, DatabaseUserGetResult>(getuser);
        }

        public ResponseResult DeleteDatabaseUser(string name, string databaseName, string username)
        {
            var result = new ResponseResult();

            var list = GetDatabaseUserList(name, databaseName);

            if (!list.database.users.Any())
            {
                result.status = "error";
                result.ErrorCode = 999;
                result.ErrorText = "No users in this database";

                return result;
            }

            var currentUser = list.database.users.Where(m => m.login == username).FirstOrDefault();

            if (currentUser == null)
            {
                result.status = "error";
                result.ErrorCode = 999;
                result.ErrorText = "User not found";

                return result;
            }

            var deleteUser = new DatabaseUserDelPacket();
            deleteUser.database.del.filter.databaseId = currentUser.databaseId;
            deleteUser.database.del.filter.userId = currentUser.Id;

            return ExecuteWebRequest<DatabaseUserDelPacket, DatabaseUserDelResult>(deleteUser).ToResult();
        }

        public ResponseResult ChangeDatabaseUserPassword(string name, string databaseName, string username, string newpassword)
        {
            var result = new ResponseResult();
            var list = GetDatabaseUserList(name, databaseName);

            if (!list.database.users.Any())
            {                
                result.status = STATUS_ERROR;
                result.ErrorCode = 999;
                result.ErrorText = "No users in this database";

                return result;
            }

            var currentUser = list.database.users.Where(m => m.login == username).FirstOrDefault();

            if (currentUser == null)
            {
                result.status = STATUS_ERROR;
                result.ErrorCode = 999;
                result.ErrorText = "User not found";

                return result;
            }

            var changePass = new DatabaseUserSetPacket();
            changePass.database.setDbUser.databaseUserId = currentUser.Id;
            changePass.database.setDbUser.password = newpassword;

            return ExecuteWebRequest<DatabaseUserSetPacket, DatabaseUserSetResult>(changePass).ToResult();
        }
        #endregion

        #region Virtual Directory
        public ResponseResult CreateVirtualDirectory(string name, string virtualDirectoryName, string physichalPath = "")
        {
            var currentsite = GetSite(name);
            var currentSiteResult = currentsite.ToResult();

            if (currentSiteResult.status != STATUS_OK)            
                return currentSiteResult;            

            var addVirt = new VirtualDirectoryAddPacket();
            addVirt.virt.siteId = currentsite.site.receive.result.Id;
            addVirt.virt.virtualDirectoryName = virtualDirectoryName;
            addVirt.virt.properties.readlPath = String.IsNullOrEmpty(physichalPath) ? virtualDirectoryName : physichalPath;

            return ExecuteWebRequest<VirtualDirectoryAddPacket, VirtualDirectoryAddResult>(addVirt).ToResult();
        }

        public ResponseResult DeleteVirtualDirectory(string name, string virtualDirectoryName)
        {
            var currentsite = GetSite(name);
            var currentSiteResult = currentsite.ToResult();

            if (currentSiteResult.status != STATUS_OK)            
                return currentSiteResult;            

            var delVirt = new VirtualDirectoryDelPacket();
            delVirt.virtdir.remove.siteId = currentsite.site.receive.result.Id;
            delVirt.virtdir.remove.virtualDirectoryName = virtualDirectoryName;

            return ExecuteWebRequest<VirtualDirectoryDelPacket, VirtualDirectoryDelResult>(delVirt).ToResult();
        }
        #endregion

        //Mail Management

        //Dns Management
    }
}
