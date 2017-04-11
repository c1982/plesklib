namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class VirtualDirectoryUpdatePacket
    {
        public VirtualDirectoryUpdatePacket()
        {
            this.virtdir = new VirtualDirectoryUpdateVirtDirNode();
        }

        [XmlElement("virtdir")] 
        public VirtualDirectoryUpdateVirtDirNode virtdir { get; set; }
    }

    public class VirtualDirectoryUpdateVirtDirNode
    {

        public VirtualDirectoryUpdateVirtDirNode()
        {
            this.update = new VirtualDirectoryUpdateUpdateNode();
        }

        [XmlElement("update")] 
        public VirtualDirectoryUpdateUpdateNode update { get; set; }
    }

    public class VirtualDirectoryUpdateUpdateNode
    {
        public VirtualDirectoryUpdateUpdateNode()
        {
            this.properties = new VirtualDirectoryUpdatePropertiesNode();
        }

        [XmlElement("site-id")] 
        public int SiteId { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("properties")] 
        public VirtualDirectoryUpdatePropertiesNode properties { get; set; }
    }

    public class VirtualDirectoryUpdatePropertiesNode
    {
        public VirtualDirectoryUpdatePropertiesNode()
        {
            this.application = new VirtualDirectoryUpdateApplicationNode();
        }

        public VirtualDirectoryUpdateApplicationNode application { get; set; }
    }

    public class VirtualDirectoryUpdateApplicationNode
    {
        [XmlElement("enabled")]
        public string Enabled { get; set; }
        
        [XmlElement("parent-paths")]
        public bool EnableParenPaths { get; set; }

        [XmlElement("run-in-mta")]
        public bool RunInMta { get; set; }
    }
}
