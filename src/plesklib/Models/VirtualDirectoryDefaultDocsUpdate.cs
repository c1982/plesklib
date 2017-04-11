namespace maestropanel.plesklib.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class VirtualDirectoryDefaultDocsUpdatePacket
    {
        public VirtualDirectoryDefaultDocsUpdatePacket()
        {
            this.virtdir = new VirtualDirectoryDefaultDocsVirDirNode();
        }

        [XmlElement("virtdir")] 
        public VirtualDirectoryDefaultDocsVirDirNode virtdir { get; set; }

    }

    public class VirtualDirectoryDefaultDocsVirDirNode
    {
        public VirtualDirectoryDefaultDocsVirDirNode()
        {
            this.update = new VirtualDirectoryDefaultDocsUpdateNode();
        }

        [XmlElement("update")] 
        public VirtualDirectoryDefaultDocsUpdateNode update { get; set; }
    }

    public class VirtualDirectoryDefaultDocsUpdateNode
    {
        public VirtualDirectoryDefaultDocsUpdateNode()
        {
            this.Properties = new VirtualDirectoryDefaultDocsProperties();
        }

        [XmlElement("site-id")]
        public int SiteId { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("properties")] 
        public VirtualDirectoryDefaultDocsProperties Properties { get; set; }
    }

    public class VirtualDirectoryDefaultDocsProperties
    {
        public VirtualDirectoryDefaultDocsProperties()
        {
            this.DefaultDocs = new VirtualDirectoryDefaultDocsDefaultDocNode();
        }

         [XmlElement("default-doc")]
        public VirtualDirectoryDefaultDocsDefaultDocNode DefaultDocs { get; set; }
    }

    public class VirtualDirectoryDefaultDocsDefaultDocNode
    {
        public VirtualDirectoryDefaultDocsDefaultDocNode()
        {
            this.Search = new List<string>().ToArray();
        }

        [XmlElement("enabled")]
        public string Enabled { get; set; }

        [XmlElement("search")]        
        public string[] Search { get; set; }
    }

}
