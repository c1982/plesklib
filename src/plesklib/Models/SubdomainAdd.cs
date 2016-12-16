namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SubdomainAddPacket
    {
        public SubdomainAddPacket()
        {
            this.subdomain = new SubdomainNode();
        }

        [XmlElement("subdomain")]
        public SubdomainNode subdomain { get; set; }
    }

    public class SubdomainNode
    {
        public SubdomainNode()
        {
            this.add = new SubdomainAddNode();
        }

        [XmlElement("add")]
        public SubdomainAddNode add { get; set; }
    }

    public class SubdomainAddNode
    {
        public SubdomainAddNode()
        {
            this.ftpUsername = new HostingProperty() { Name = "ftp_login" };
            this.ftpPassword = new HostingProperty() { Name = "ftp_password" };
            this.homeDir = new HostingProperty() { Name = "www_root" };
            this.ssi = new HostingProperty() { Name = "ssi" };
            this.ssiHtml = new HostingProperty() { Name = "ssi_html" };
        }

        [XmlElement("parent")]
        public string parentName { get; set; }

        [XmlElement("name")]
        public string subdomainName { get; set; }

        [XmlElement("property")]
        public HostingProperty ftpUsername { get; set; }

        [XmlElement("property")]
        public HostingProperty ftpPassword { get; set; }

        [XmlElement("property")]
        public HostingProperty homeDir { get; set; }

        [XmlElement("property")]
        public HostingProperty ssi { get; set; }

        [XmlElement("property")]
        public HostingProperty ssiHtml { get; set; }

    }
}
