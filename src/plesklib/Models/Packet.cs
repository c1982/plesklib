namespace plesklib.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    [XmlRoot("packet")]
    public class PacketAdd
    {
        public PacketAdd()
        {
            this.Site = new Site();
        }

        [XmlElement("site")]        
        public Site Site { get; set; }

    }

    [XmlRoot("packet")]
    public class PacketAddResult
    {
        public PacketAddResult()
        {
            this.site = new SiteResult() { addResult = new AddResult { result = new ResponseResult { } } };
        }

        [XmlElement("site")]
        public SiteResult site { get; set; }
    }

    public class SiteResult
    {
        public SiteResult()
        {
            this.addResult = new AddResult();
        }

        [XmlElement("add")]
        public AddResult addResult { get; set; }
    }

    public class AddResult
    {
        public AddResult()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("add")]
        public ResponseResult result { get; set; }
    }


    public class ResponseResult
    {
        [XmlElement("status")]
        public string status { get; set; }

        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("guid")]
        public string guid { get; set; }
    }

    public class Site
    {
        public Site()
        {
            this.Add = new AddSite();
        }

        [XmlElement("add")]
        public AddSite Add { get; set; }
    }

    public class AddSite
    {
        public AddSite()
        {
            this.Hosting = new Hosting();
            this.GenSetup = new GenSetup();
        }

        [XmlElement("gen_setup")]
        public GenSetup GenSetup { get; set; }

        [XmlElement("hosting")]
        public Hosting Hosting { get; set; }
    }

    public class GenSetup
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("webspace-id")]
        public string WebSpaceId { get; set; }
    }

    public class Hosting
    {
        [XmlArray("vrt_hst")]
        [XmlArrayItem("property")]
        public HostingProperty[] Properties { get; set; }
        
        public Hosting()
        {
            Properties = new List<HostingProperty>().ToArray();
        }
    }

    public class HostingProperty
    {
        [XmlElement("name")]
        public string Name{ get; set; }

        [XmlElement("value")]
        public string Value { get; set; }
    }
}
