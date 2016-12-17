namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SiteGetPacket
    {
        public SiteGetPacket()
        {
            this.site = new SiteGetSiteNode();
        }

        [XmlElement("site")]
        public SiteGetSiteNode site { get; set; }
    }

    public class SiteGetSiteNode
    {
        public SiteGetSiteNode()
        {
            this.get = new SiteGetNode();
        }

        [XmlElement("get")]
        public SiteGetNode get { get; set; }
    }

    public class SiteGetNode
    {

        public SiteGetNode()
        {
            this.filter = new SiteGetFilterNode();
            this.dataset = new SiteGetDataSetNode();
        }

        [XmlElement("filter")]
        public SiteGetFilterNode filter { get; set; }

        [XmlElement("dataset")]
        public SiteGetDataSetNode dataset { get; set; }
    }

    public class SiteGetFilterNode
    {        
        [XmlElement("name")]
        public string Name { get; set; }
    }

    public class SiteGetDataSetNode
    {
        public SiteGetDataSetNode()
        {
            this.Hosting = new SiteGetDataSetHostingNode();
        }

        [XmlElement("hosting")]
        public SiteGetDataSetHostingNode Hosting { get; set; }
    }

    public class SiteGetDataSetHostingNode
    {

    }


}
