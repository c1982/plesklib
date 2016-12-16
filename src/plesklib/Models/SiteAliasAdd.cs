namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SiteAliasAddPacket
    {
        public SiteAliasAddPacket()
        {
            this.siteAlias = new SiteAliasAddNode();
        }

        [XmlElement("site-alias")]
        public SiteAliasAddNode siteAlias { get; set; }
    }
    
    public class SiteAliasAddNode
    {
        public SiteAliasAddNode()
        {
            this.createSiteAlias = new SiteAliasCreate();
        }

        [XmlElement("create")]
        public SiteAliasCreate createSiteAlias { get; set; }
    }

    public class SiteAliasCreate
    {
        public SiteAliasCreate()
        {
            this.pref = new SiteAliasPref();
        }

        [XmlElement("site-id")]
        public int SiteId { get; set; }

        [XmlElement("name")]
        public string AliasName { get; set; }

        [XmlElement("pref")]
        public SiteAliasPref pref { get; set; }
    }

    public class SiteAliasPref
    {
        [XmlElement("web")]
        public string web { get; set; }

        [XmlElement("mail")]
        public string mail { get; set; }

        [XmlElement("tomcat")]
        public string tomcat { get; set; }
    }
}
