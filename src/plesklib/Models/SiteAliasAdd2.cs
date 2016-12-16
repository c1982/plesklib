namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SiteAliasAdd2
    {
        public SiteAliasAdd2()
        {
            this.subdomain = new SiteAliasAdd2SubdomainNode();
        }

        [XmlElement("subdomain")]
        public SiteAliasAdd2SubdomainNode subdomain { get; set; }
    }

    public class SiteAliasAdd2SubdomainNode
    {
        public SiteAliasAdd2SubdomainNode()
        {
            this.add = new SiteAliasAdd2AddNode();
        }

        [XmlElement("add")]
        public SiteAliasAdd2AddNode add { get; set; }
    }

    public class SiteAliasAdd2AddNode
    {
        [XmlElement("parent")]
        public string parent { get; set; }

        [XmlElement("name")]
        public string name { get; set; }

    }
}
