namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SubdomainAddPacket
    {
        public SubdomainAddPacket()
        {
            this.subdomain = new Subdomain();
        }

        [XmlElement("subdomain")]
        public Subdomain subdomain { get; set; }
    }

    public class Subdomain
    {
        public Subdomain()
        {
            this.add = new SubdomainAdd();
        }

        [XmlElement("add")]
        public SubdomainAdd add { get; set; }
    }

    public class SubdomainAdd
    {
        public SubdomainAdd()
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
