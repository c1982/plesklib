namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SiteDelPacket
    {
        public SiteDelPacket()
        {
            this.site = new SiteDelSite();
        }

        [XmlElement("site")]
        public SiteDelSite site { get; set; }
    }

    public class SiteDelSite
    {
        public SiteDelSite()
        {
            this.del = new SiteDelDel();
        }

        [XmlElement("del")]
        public SiteDelDel del { get; set; }
    }

    public class SiteDelDel
    {
        public SiteDelDel()
        {
            this.filter = new SiteDelFilter();
        }

        [XmlElement("filter")]
        public SiteDelFilter filter { get; set; }   
    }

    public class SiteDelFilter
    {
        public string Name { get; set; }
    }
}
