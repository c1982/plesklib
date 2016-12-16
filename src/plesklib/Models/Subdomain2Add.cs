namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class Subdomain2AddPacket
    {
        public Subdomain2AddPacket()
        {
            this.subdomain = new Subdomain2Node();
        }

        [XmlElement("subdomain")]
        public Subdomain2Node subdomain { get; set; }
    }

    public class Subdomain2Node
    {
        public Subdomain2Node()
        {
            this.add = new Subdomain2AddNode();
        }

        [XmlElement("add")]
        public Subdomain2AddNode add { get; set; }
    }

    public class Subdomain2AddNode
    {
        public Subdomain2AddNode()
        {

        }

        [XmlElement("parent")]
        public string parentName { get; set; }

        [XmlElement("name")]
        public string subdomainName { get; set; }

    }
}
