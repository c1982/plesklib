namespace plesklibTest
{
    using JustFakeIt;
    using maestropanel.plesklib;
    using Microsoft.VisualStudio.TestTools.UnitTesting;    
    using System.Diagnostics;

    [TestClass]
    public class PleskActionTests
    {
        private readonly int BASE_PORT = 8443;
        private PleskClient client = new PleskClient(PleskClientTest.HOSTNAME, PleskClientTest.USERNAME, PleskClientTest.PASSWORD, https:false);


        private static readonly string ADD_ALIAS_RESULT_XML = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                                                                <packet>
                                                        <site-alias>
                                                        <create>
                                                           <result>
                                                              <status>ok</status>
                                                              <id>34</id>
                                                           </result>
                                                        </create>
                                                        </site-alias>
                                                        </packet>";


        private static readonly string GET_SITE_INFORMATIONS_RESULT_XML = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                                                                        <packet version=""1.6.7.0"">
                                                                          <site>
                                                                            <get>
                                                                              <result>
                                                                                <status>ok</status>
                                                                                <filter-id>4</filter-id>
                                                                                <id>4</id>
                                                                                <data>
                                                                                  <gen_info>
                                                                                    <cr_date>2015-12-04</cr_date>
                                                                                    <name>sub.ppu12-5.demo.pp.plesk.ru</name>
                                                                                    <ascii-name>sub.ppu12-5.demo.pp.plesk.ru</ascii-name>
                                                                                    <status>0</status>
                                                                                    <real_size>0</real_size>
                                                                                    <dns_ip_address>10.58.103.100</dns_ip_address>
                                                                                    <htype>vrt_hst</htype>
                                                                                    <guid>ec38e7be-38bd-4048-8a56-3201f5fc6c81</guid>
                                                                                    <webspace-guid>39633a2d-a190-4d98-8af9-059148a5ec00</webspace-guid>
                                                                                    <sb-site-uuid/>
                                                                                    <webspace-id>1</webspace-id>
                                                                                    <description/>
                                                                                  </gen_info>
                                                                                  <hosting>
                                                                                    <vrt_hst>
                                                                                      <property>
                                                                                        <name>ftp_login</name>
                                                                                        <value>mathias.collins</value>
                                                                                      </property>                                                                        
                                                                                    </vrt_hst>
                                                                                  </hosting>
                                                                                </data>
                                                                              </result>
                                                                            </get>
                                                                          </site>
                                                                        </packet>";

        private readonly string WEBSPACE_RESULT= @"<?xml version=""1.0"" encoding=""UTF-8""?>
                                                    <packet version=""1.6.7.0"">
                                                      <webspace>
                                                        <add>
                                                          <result>
                                                            <status>ok</status>
                                                            <id>4</id>
                                                            <guid>5ff343c1-a40b-4305-8986-2f27c240db7e</guid>
                                                          </result>
                                                        </add>
                                                      </webspace>
                                                    </packet>";

        [TestMethod]
        public void Add_Site_Test()
        {
            using (var fakeServer = new FakeServer(BASE_PORT))
            {
                fakeServer.Expect.Post("/enterprise/control/agent.php", "").Returns(System.Net.HttpStatusCode.OK, PleskClientTest.ADD_SITE_RESULT);
                fakeServer.Start();

                var result = client.CreateSite(1, "domain.com", null);

                Debug.WriteLine(result.ErrorText);

                Assert.AreEqual(result.status, "ok");
                Assert.AreEqual(result.Id, "57");
                Assert.AreEqual(result.guid, "ed5de3a1-2d73-4dfa-9cee-4609afaccf6a");
            }
        }


        [TestMethod]
        public void Add_WebSpace_Test()
        {
            using (var fakeServer = new FakeServer(BASE_PORT))
            {
                fakeServer.Expect.Post("/enterprise/control/agent.php", "").Returns(System.Net.HttpStatusCode.OK, WEBSPACE_RESULT);
                fakeServer.Start();

                var result = client.CreateWebSpace("domain.com", "192.168.0.1", "ftplogin", "password", null);

                Debug.WriteLine(result.ErrorText);

                Assert.AreEqual(result.status, "ok");
                Assert.AreEqual(result.Id, "4");
                Assert.AreEqual(result.guid, "5ff343c1-a40b-4305-8986-2f27c240db7e");
            }
        }

        [TestMethod]
        public void Add_Alias_to_Site_Test()
        {
            using (var fakeServer = new FakeServer(BASE_PORT))
            {
                fakeServer.Expect.Post("/enterprise/control/agent.php", "").Returns(System.Net.HttpStatusCode.OK, ADD_ALIAS_RESULT_XML);
                fakeServer.Start();

                var result = client.CreateAlias(10, "demo.net");
                
                Assert.AreEqual(result.status, "ok");
                Assert.AreEqual(result.Id, "34");                
            }
        }

        [TestMethod]
        public void Get_Site_Informations_Test()
        {
            using (var fakeServer = new FakeServer(BASE_PORT))
            {
                fakeServer.Expect.Post("/enterprise/control/agent.php", "").Returns(System.Net.HttpStatusCode.OK, GET_SITE_INFORMATIONS_RESULT_XML);
                fakeServer.Start();

                var result = client.GetSite("domain.com");
                
                Assert.AreEqual(result.site.receive.result.status, "ok");
                Assert.AreEqual(result.site.receive.result.data.getInfo.Name, "sub.ppu12-5.demo.pp.plesk.ru");
            }
        }
    }
}
