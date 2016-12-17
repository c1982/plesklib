namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class WebSpaceGetPacket
    {
        public WebSpaceGetPacket()
        {
            this.webspace = new WebSpaceGetWebSpaceNode();
        }

        [XmlElement("webspace")]
        public WebSpaceGetWebSpaceNode webspace { get; set; }
    }

    public class WebSpaceGetWebSpaceNode
    {
        public WebSpaceGetWebSpaceNode()
        {
            this.retrieve = new WebSpaceGetGetNode();
        }

        [XmlElement("get")]
        public WebSpaceGetGetNode retrieve { get; set; }
    }

    public class WebSpaceGetGetNode
    {
        public WebSpaceGetGetNode()
        {
            this.filter = new WebSpaceGetFilterNode();
            this.dataset = new WebSpaceGetDatasetNode();
        }

        [XmlElement("filter")]
        public WebSpaceGetFilterNode filter { get; set; }

        [XmlElement("dataset")]
        public WebSpaceGetDatasetNode dataset { get; set; }
    }

    public class WebSpaceGetFilterNode
    {
        [XmlElement("name")]
        public string name { get; set; }
    }

    public class WebSpaceGetDatasetNode
    {
        public WebSpaceGetDatasetNode()
        {
            this.hosting = new WebSpaceGetHostingNode();
        }

        [XmlElement("hosting")]
        public WebSpaceGetHostingNode hosting { get; set; }
    }

    public class WebSpaceGetHostingNode
    {

    }
}
