namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SubdomainDeletePacket
    {
        public SubdomainDeletePacket()
        {
            this.subdomain = new SubdomainDeleteSubdomain();
        }

        [XmlElement("subdomain")]
        public SubdomainDeleteSubdomain subdomain { get; set; }
    }

    public class SubdomainDeleteSubdomain
    {
        public SubdomainDeleteSubdomain()
        {
            this.del = new SubdomainDeleteDel();
        }

        [XmlElement("del")]
        public SubdomainDeleteDel del { get; set; }
    }

    public class SubdomainDeleteDel
    {
        public SubdomainDeleteDel()
        {
            this.filter = new SubdomainDeleteFilter();
        }

        [XmlElement("filter")]
        public SubdomainDeleteFilter filter { get; set; }
    }

    public class SubdomainDeleteFilter
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
