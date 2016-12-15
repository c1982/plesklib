namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class Subdomain2AddPacket
    {
        public Subdomain2AddPacket()
        {
            this.subdomain = new Subdomain();
        }

        [XmlElement("subdomain")]
        public Subdomain subdomain { get; set; }
    }

    public class Subdomain2
    {
        public Subdomain2()
        {
            this.add = new Subdomain2Add();
        }

        [XmlElement("add")]
        public Subdomain2Add add { get; set; }
    }

    public class Subdomain2Add
    {
        public Subdomain2Add()
        {

        }

        [XmlElement("parent")]
        public string parentName { get; set; }

        [XmlElement("name")]
        public string subdomainName { get; set; }

    }
}
