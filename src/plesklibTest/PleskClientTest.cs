namespace plesklibTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using plesklib;
    using plesklib.Models;
    using System.Collections.Generic;

    [TestClass]
    public class PleskClientTest
    {
        private readonly string HOSTNAME = "localhost";
        private readonly string USERNAME = "admin";
        private readonly string PASSWORD = "passw0rd";

        private readonly string ADD_PACKAGE_XML = @"<?xml version=""1.0"" encoding=""UTF-8""?>
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

        [TestMethod]
        public void DeserializationPacketObject()
        {
            var client = new PleskClient(HOSTNAME, USERNAME, PASSWORD);
            var packet = client.DeSerializeObject<PacketAdd>(ADD_PACKAGE_XML);

            Assert.IsNotNull(packet);
            Assert.IsInstanceOfType(packet, typeof(PacketAdd));          
            Assert.AreEqual(packet.Site.Add.GenSetup.Name, "sample.tst");
            Assert.AreEqual(packet.Site.Add.GenSetup.WebSpaceId, "10");

            var virtualHostArraySize = packet.Site.Add.Hosting.Properties.Length;

            Assert.AreEqual(virtualHostArraySize, 22);
        }

        public void AddSiteTest()
        {
            var client = new PleskClient(HOSTNAME, USERNAME, PASSWORD);

            var features = new List<HostingProperty>();
            features.Add(new HostingProperty() { Name = "", Value = "" });

            var result = client.SiteAdd("10", "domain.com", "domain.com", "p@ssw0rd", features.ToArray());

            Assert.AreEqual(result.site.addResult.result.status, "success");
        }
    }
}
