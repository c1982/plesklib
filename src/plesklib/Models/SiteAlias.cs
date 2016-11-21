namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SiteAliasPacket
    {
        [XmlElement("site-alias")]
        public SiteAlias siteAlias { get; set; }
    }
    
    public class SiteAlias
    {
        [XmlElement("create")]
        public SiteAliasCreate createSiteAlias { get; set; }
    }

    public class SiteAliasCreate
    {
        [XmlElement("site-id")]
        public int SiteId { get; set; }

        [XmlElement("name")]
        public string AliasName { get; set; }
    }
}
