namespace plesklib.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    [XmlRoot("packet")]
    public class SiteAddPacket
    {
        public SiteAddPacket()
        {
            this.Site = new Site();
        }

        [XmlElement("site")]        
        public Site Site { get; set; }

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
