namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class WebSpaceDelPacket
    {
        public WebSpaceDelPacket()
        {
            this.webspace = new WebSpaceDelWebSpaceNode();
        }

        [XmlElement("webspace")]
        public WebSpaceDelWebSpaceNode webspace { get; set; }
    }

    public class WebSpaceDelWebSpaceNode
    {
        public WebSpaceDelWebSpaceNode()
        {
            this.del = new WebSpaceDelNode();
        }

        [XmlElement("del")]  
        public WebSpaceDelNode del { get; set; }
    }

    public class WebSpaceDelNode
    {
        public WebSpaceDelNode()
        {
            this.filter = new WebSpaceFilterNode();
        }

        [XmlElement("filter")]  
        public WebSpaceFilterNode filter { get; set; }
    }

    public class WebSpaceFilterNode
    {        
        [XmlElement("name")]  
        public string Name { get; set; }
    }
}
