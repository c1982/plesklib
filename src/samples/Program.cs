namespace samples
{
    using maestropanel.plesklib;    
    using maestropanel.plesklib.Models;
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            //var client = new PleskClient("192.168.2.136", "admin", "Osman12!");
            var client = new PleskClient("94.73.171.25", "admin", "00A11b00c!");

            //var result = client.CreateSite("testdom.com", 2, true, true, true, true, false, false, false, false, false, false, false, "none", true, false);

            //Console.WriteLine(result.site.addResult.result.status);

            //if (result.site.addResult.result.status == "error")
            //{
            //    Console.WriteLine(result.site.addResult.result.ErrorText);
            //}
            //else
            //{
            //    Console.WriteLine("Success");
            //    Console.WriteLine(result.site.addResult.result.guid);
            //    Console.WriteLine(result.site.addResult.result.Id);
            //}

            //var result = client.GetIPAddressList();
            //if (result.ip.get.result.status == "ok")
            //{
            //    foreach (var item in result.ip.get.result.ipinfo)
            //    {
            //        Console.WriteLine(item.ipaddress);
            //    }
            //}
            
            //var list = new List<HostingProperty>();
            //list.Add(new HostingProperty() { Name = "php", Value = "false" });
            //list.Add(new HostingProperty() { Name = "ssi", Value = "false" });
            //list.Add(new HostingProperty() { Name = "asp", Value = "true" });
            //list.Add(new HostingProperty() { Name = "asp_dot_net", Value = "false" });
            //list.Add(new HostingProperty() { Name = "cgi", Value = "true" });

            //var result = client.CreateWebSpace("demo3.com", "192.168.2.136", "demo3.com", "Osman12!", list);

            //Console.WriteLine(result.webspace.add.result.status);
            //Console.WriteLine(result.webspace.add.result.ErrorText);
            //Console.WriteLine(result.webspace.add.result.guid);
            //Console.WriteLine(result.webspace.add.result.Id);   

            //var cdom = client.GetSite("konaklirealestate.com");
            
            //Console.WriteLine(cdom.ToResult().status);
            //Console.WriteLine(cdom.ToResult().ErrorText);
            //Console.WriteLine(cdom.site.results.Length);

            //foreach (var item in cdom.site.results)
            //{
            //    Console.WriteLine(item.data.getInfo.Name);
            //}

            var s = client.GetWebSpace("konaklirealestate.com");
            var b = s.ToResult();

            Console.WriteLine(b.status);
            Console.WriteLine(b.response.RequestXmlString);
            Console.WriteLine(b.response.ResponseXmlString);

            Console.WriteLine(b.ErrorText);
            Console.WriteLine(s.webspace.getWebSpace.result.Id);
            Console.WriteLine(s.webspace.getWebSpace.result.status);
        }
    }
}
