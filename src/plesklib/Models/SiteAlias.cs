namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SiteAliasPacket
    {

        public SiteAliasPacket()
        {
            this.siteAlias = new SiteAlias();
        }

        [XmlElement("site-alias")]
        public SiteAlias siteAlias { get; set; }
    }
    
    public class SiteAlias
    {
        public SiteAlias()
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
