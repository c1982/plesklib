namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class VirtualDirectoryDelPacket
    {
        public VirtualDirectoryDelPacket()
        {
            this.virtdir = new VirtualDirectoryVirtDirNode();
        }

        [XmlElement("virtdir")]
        public VirtualDirectoryVirtDirNode virtdir { get; set; }
    }

    public class VirtualDirectoryVirtDirNode
    {
        public VirtualDirectoryVirtDirNode()
        {
            this.remove = new VirtualDirectoryRemoveNode();
        }

        [XmlElement("remove")]
        public VirtualDirectoryRemoveNode remove { get; set; }
    }

    public class VirtualDirectoryRemoveNode
    {
        [XmlElement("site-id")]
        public int siteId { get; set; }

        [XmlElement("name")]
        public string virtualDirectoryName { get; set; }
    }
}
