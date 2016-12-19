namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class VirtualDirectoryAddPacket
    {
        public VirtualDirectoryAddPacket()
        {
            this.virt = new VirtualDirectoryAddCreateNode();
        }

        [XmlElement("virtdir")] 
        public VirtualDirectoryAddCreateNode virt { get; set; }
    }

    public class VirtualDirectoryAddCreateNode
    {
        public VirtualDirectoryAddCreateNode()
        {
            this.properties = new VirtualDirectoryPropertiesNode();
        }

        [XmlElement("site-id")]
        public int siteId { get; set; }

        [XmlElement("name")]
        public string virtualDirectoryName { get; set; }

        [XmlElement("properties")]
        public VirtualDirectoryPropertiesNode properties { get; set; }
    }

    public class VirtualDirectoryPropertiesNode
    {
        [XmlElement("real-path")]
        public string readlPath { get; set; }        
    }
}
