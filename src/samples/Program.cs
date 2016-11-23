namespace samples
{
    using plesklib;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var client = new PleskClient("192.168.2.136", "admin", "Osman12!");

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

            var result = client.CreateWebSpace("domdon.com", "192.168.2.136", "domdon.com", "Osman12!");

            Console.WriteLine(result.webspace.add.result.status);
            Console.WriteLine(result.webspace.add.result.ErrorText);
            Console.WriteLine(result.webspace.add.result.guid);
            Console.WriteLine(result.webspace.add.result.Id);
        }
    }
}
