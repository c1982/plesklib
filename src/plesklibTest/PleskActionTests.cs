namespace plesklibTest
{
    using JustFakeIt;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using plesklib;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    [TestClass]
    public class PleskActionTests
    {
        private readonly int BASE_PORT = 8443;
        private PleskClient client = new PleskClient(PleskClientTest.HOSTNAME, PleskClientTest.USERNAME, PleskClientTest.PASSWORD, https:false);

        [TestMethod]
        public void SiteAdd_Test()
        {
            using (var fakeServer = new FakeServer(BASE_PORT))
            {
                fakeServer.Expect.Post("/enterprise/control/agent.php", "").Returns(System.Net.HttpStatusCode.OK, PleskClientTest.ADD_SITE_RESULT);
                fakeServer.Start();

                var result = client.SiteAdd("demo.com", "57", null);

                Debug.WriteLine(result.site.addResult.result.ErrorText);

                Assert.AreEqual(result.site.addResult.result.status, "ok");
                Assert.AreEqual(result.site.addResult.result.Id, "57");
                Assert.AreEqual(result.site.addResult.result.guid, "ed5de3a1-2d73-4dfa-9cee-4609afaccf6a");
            }
        }
    }
}
