namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class VirtualDirectoryAddPacket
    {
        public VirtualDirectoryAddPacket()
        {
            this.virt = new VirtualDirectoryAddVirtNode();
        }

        [XmlElement("virtdir")] 
        public VirtualDirectoryAddVirtNode virt { get; set; }
    }


    public class VirtualDirectoryAddVirtNode
	{
        public VirtualDirectoryAddVirtNode()
        {
            this.create = new VirtualDirectoryAddCreateNode();
        }

        [XmlElement("create")] 
        public VirtualDirectoryAddCreateNode create { get; set; }
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
        public VirtualDirectoryPropertiesNode()
        {
            application = new VirtualDirectoryApplicationNode();
        }

        [XmlElement("real-path")]
        public string readlPath { get; set; }

        [XmlElement("application")]
        public VirtualDirectoryApplicationNode application { get; set; }
    }

    public class VirtualDirectoryApplicationNode
    {
        [XmlElement("enabled")]
        public string Enabled { get; set; }

        [XmlElement("parent-paths")]
        public bool parentPaths  { get; set; }

        [XmlElement("run-in-mta")]
        public bool RunInMta { get; set; }
    }
}
