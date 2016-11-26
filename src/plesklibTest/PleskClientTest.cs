namespace plesklibTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using plesklib;
    using plesklib.Models;
    using System.Collections.Generic;

    [TestClass]
    public class PleskClientTest
    {
        public static readonly string HOSTNAME = "localhost";
        public static readonly string USERNAME = "admin";
        public static readonly string PASSWORD = "passw0rd";

        private PleskClient client = new PleskClient(HOSTNAME, USERNAME, PASSWORD);

        public static readonly string ADD_SITE_XML = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                                                    <packet>
                                                      <site>
                                                       <add>
                                                          <gen_setup>
                                                            <name>sample.tst</name>
                                                            <webspace-id>10</webspace-id>
                                                          </gen_setup>
                                                          <hosting>
                                                            <vrt_hst>
                                                                  <property>
                                                                    <name>fp</name>
                                                                    <value>false</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>fp_ssl</name>
                                                                    <value>false</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>fp_auth</name>
                                                                    <value>false</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>fp_admin_login</name>
                                                                    <value/>
                                                                  </property>
                                                                  <property>
                                                                    <name>fp_admin_password</name>
                                                                    <value/>
                                                                  </property>
                                                                  <property>
                                                                    <name>ssl</name>
                                                                    <value>true</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>php</name>
                                                                    <value>true</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>php_handler_id</name>
                                                                    <value>fastcgi-5.3</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>ssi</name>
                                                                    <value>false</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>cgi</name>
                                                                    <value>true</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>perl</name>
                                                                    <value>true</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>python</name>
                                                                    <value>true</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>asp</name>
                                                                    <value>false</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>miva</name>
                                                                    <value>false</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>webstat</name>
                                                                    <value>awstats</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>webstat_protected</name>
                                                                    <value>true</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>errdocs</name>
                                                                    <value>true</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>fastcgi</name>
                                                                    <value>true</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>cgi_mode</name>
                                                                    <value>webspace</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>www_root</name>
                                                                    <value>/sample</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>safe_mode</name>
                                                                    <value>off</value>
                                                                  </property>
                                                                  <property>
                                                                    <name>open_basedir</name>
                                                                    <value>{WEBSPACEROOT}{/}{:}{TMP}{/}</value>
                                                                  </property>
                                                                </vrt_hst>
                                                          </hosting>
                                                        </add>
                                                      </site>
                                                    </packet>";

        public static readonly string ADD_SITE_RESULT = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                                                    <packet version=""1.6.8.0"">
                                                      <site>
                                                        <add>
                                                          <result>
                                                            <status>ok</status>
                                                            <id>57</id>
                                                            <guid>ed5de3a1-2d73-4dfa-9cee-4609afaccf6a</guid>
                                                          </result>
                                                        </add>
                                                      </site>
                                                    </packet>";

        [TestMethod]
        public void DeserializationPacketObject()
        {

            var result = client.DeSerializeObject<SiteAddPacket>(ADD_SITE_XML);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(SiteAddPacket));
            Assert.AreEqual(result.Site.Add.GenSetup.Name, "sample.tst");
            Assert.AreEqual(result.Site.Add.GenSetup.WebSpaceId, 10);

            var virtualHostArraySize = result.Site.Add.Hosting.Properties.Length;

            Assert.AreEqual(virtualHostArraySize, 22);
        }


        [TestMethod]
        public void IResponsible_SaveResultTest()
        {
            var apiresponse = new ApiResponse();
            apiresponse.Message = "Error Message";
            apiresponse.Status = false;            

            object obJResult = new SiteAddResult();

            var a = obJResult as IResponseResult;
            a.SaveResult(apiresponse);            
            
            var result = obJResult as SiteAddResult;

            Assert.AreEqual(result.site.addResult.result.status, "error");
            Assert.AreEqual(result.site.addResult.result.ErrorText, apiresponse.Message);
            Assert.AreEqual(result.site.addResult.result.ErrorCode, 999);            
        }

        [TestMethod]
        public void AddSiteResultDeserializationTest()
        {
            var result = client.DeSerializeObject<SiteAddResult>(ADD_SITE_RESULT);

            Assert.AreEqual(result.site.addResult.result.status, "ok");
            Assert.AreEqual(result.site.addResult.result.Id, "57");
            Assert.AreEqual(result.site.addResult.result.guid, "ed5de3a1-2d73-4dfa-9cee-4609afaccf6a");
        }

        [TestMethod]
        public void Serialize_WebSpacePacket_Type_Test()
        {
            var prop = new List<HostingProperty>();
            prop.Add(new HostingProperty() { Name = "ftp_login", Value = "login" });
            prop.Add(new HostingProperty() { Name = "ftp_password", Value = "password" });

            var add = new WebspaceAddPacket();
            add.webspace.add.genSetup.name = "domain.com";
            add.webspace.add.genSetup.ipaddress = "10.6.6.5";
            add.webspace.add.hosting.Properties = prop.ToArray();

            var xml_string = client.SerializeObjectToXmlString<WebspaceAddPacket>(add);

            Assert.IsNotNull(xml_string);
        }
    }
}
