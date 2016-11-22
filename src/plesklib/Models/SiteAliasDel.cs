namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SiteAliasDelPacket
    {
        public SiteAliasDelPacket()
        {
            this.site = new SiteAliasSite();
        }

        [XmlElement("site")]
        public SiteAliasSite site { get; set; }
    }

    public class SiteAliasSite
    {
        public SiteAliasSite()
        {
            this.delete = new SiteAliasDelete();
        }

        [XmlElement("delete")]
        public SiteAliasDelete delete { get; set; }
    }

    public class SiteAliasDelete
    {
        public SiteAliasDelete()
        {
            this.filter = new SiteAliasFilter();
        }

        [XmlElement("filter")]
        public SiteAliasFilter filter { get; set; }
    }

    public class SiteAliasFilter
    {
        [XmlElement("site-name")]
        public string Name { get; set; }
    }
}
