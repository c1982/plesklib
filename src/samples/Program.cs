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
            var client = new PleskClient("94.73.171.25", "admin", "Delidana12!");

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

            var list = new List<HostingProperty>();
            list.Add(new HostingProperty() { Name = "ftp_login", Value = "u123456" });
            list.Add(new HostingProperty() { Name = "ftp_password", Value = "Delidana12!" });


            var result = client.CreateWebSpace("demre", "demo4.com", "94.73.171.25","packet1", list);

            Console.WriteLine("Status: {0}", result.status);
            Console.WriteLine("Message: {0}", result.ErrorText);
 

            //var cdom = client.GetSite("konaklirealestate.com");
            //var b = cdom.ToResult();
            
            //Console.WriteLine("Status: {0}",b.status);
            //Console.WriteLine("Message: {0}",b.ErrorText);
            //Console.WriteLine("Id: {0}", cdom.site.receive.result.Id);

            //var s = client.GetWebSpace("konaklirealestate.com1");
            //var b = s.ToResult();

            //Console.WriteLine("Status: {0}",b.status);
            //Console.WriteLine("Message: {0}",b.ErrorText);
            //Console.WriteLine(b.apiResponse.ResponseXmlString);
            //Console.WriteLine(s.webspace.getWebSpace.result.Id);

            //var s = client.CreateAlias("konaklirealestate.com", "arkadasim.org", enableWeb:false);
            //var result = s.ToResult();

            //Console.WriteLine("Status: {0}", result.status);
            //Console.WriteLine("Message: {0}", result.ErrorText);

            //var e = client.AddFtpAccount("konaklirealestate.com", "deneme1", "Osmn12!", "/", 100);
            
            //Console.WriteLine("Status: {0}", e.status);
            //Console.WriteLine("Message: {0}", e.ErrorText);

            //var e = client.GetServicePlans();

            //var e = client.CreateCustomer("demre", "Osman12!", "aspsrc@gmail.com", "Hakan Akyol", "MaestroPanel", "istanbul avcılar", "00290002390", "239090293", "istanbul", "TR", "23232", "TR");
            
            
            
            
        }
    }
}
