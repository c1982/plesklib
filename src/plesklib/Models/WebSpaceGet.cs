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
        }

        [XmlElement("filter")]
        public WebSpaceGetFilterNode filter { get; set; }
    }

    public class WebSpaceGetFilterNode
    {
        [XmlElement("name")]
        public string name { get; set; }
    }
}
