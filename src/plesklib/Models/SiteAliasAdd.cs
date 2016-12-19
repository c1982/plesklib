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
            this.createSiteAlias = new SiteAliasAddCreateNode();
        }

        [XmlElement("create")]
        public SiteAliasAddCreateNode createSiteAlias { get; set; }
    }

    public class SiteAliasAddCreateNode
    {
        public SiteAliasAddCreateNode()
        {
            //this.pref = new SiteAliasAddPrefNode();
        }

        [XmlElement("status")]
        public string status { get; set; }

        [XmlElement("site-id")]
        public int SiteId { get; set; }

        [XmlElement("name")]
        public string AliasName { get; set; }

        //[XmlElement("ascii-name")]
        //public string asciiName { get; set; }

        //[XmlElement("pref")]
        //public SiteAliasAddPrefNode pref { get; set; }
    }

    //public class SiteAliasAddPrefNode
    //{
    //    [XmlElement("web")]
    //    public string web { get; set; }

    //    [XmlElement("mail")]
    //    public string mail { get; set; }

    //    [XmlElement("tomcat")]
    //    public string tomcat { get; set; }

    //    [XmlElement("seo-redirect")]
    //    public string seoRedirect { get; set; }
    //}
}
