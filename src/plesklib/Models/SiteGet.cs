namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SiteGetPacket
    {
        public SiteGetPacket()
        {
            this.site = new SiteGetSite();
        }

        [XmlElement("site")]
        public SiteGetSite site { get; set; }
    }

    public class SiteGetSite
    {
        public SiteGetSite()
        {
            this.get = new SiteGet();
        }

        [XmlElement("get")]
        public SiteGet get { get; set; }
    }

    public class SiteGet
    {

        public SiteGet()
        {
            this.filter = new SiteGetFilter();
            this.dataset = new SiteGetDataSet();
        }

        [XmlElement("filter")]
        public SiteGetFilter filter { get; set; }

        [XmlElement("dataset")]
        public SiteGetDataSet dataset { get; set; }
    }

    public class SiteGetFilter
    {        
        [XmlElement("name")]
        public string Name { get; set; }
    }

    public class SiteGetDataSet
    {
        [XmlElement("hosting")]
        public string Hosting { get; set; }
    }
}
