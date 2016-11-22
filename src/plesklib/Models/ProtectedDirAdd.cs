namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class ProtectedDirAddPacket
    {
        public ProtectedDirAddPacket()
        {
            this.protectedDir = new ProtectedDirProtected();
        }

        [XmlElement("protected-dir")]
        public ProtectedDirProtected protectedDir { get; set; }
    }

    public class ProtectedDirProtected
    {
        public ProtectedDirProtected()
        {
            this.add = new ProtectedDirAdd();
        }

        [XmlElement("add")]
        public ProtectedDirAdd add { get; set; }
    }

    public class ProtectedDirAdd
    {
        public ProtectedDirAdd()
        {
            this.location = new ProtectedDirLocation();
        }

        [XmlElement("site-id")]
        public int siteId { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("header")]
        public string Header { get; set; }

        [XmlElement("location")]
        public ProtectedDirLocation location { get; set; }
    }

    public class ProtectedDirLocation
    {
        public ProtectedDirLocation()
        {
            this.ssl = new HostingProperty() { Name ="ssl" };
            this.cgi = new HostingProperty() { Name="cgi" };
            this.nonssl = new HostingProperty() { Name="nonssl" };
        }

        [XmlElement("property")]
        public HostingProperty ssl { get; set; }

        [XmlElement("property")]
        public HostingProperty nonssl { get; set; }

        [XmlElement("property")]
        public HostingProperty cgi { get; set; }
    }
}
