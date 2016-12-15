namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class IPAddrGetPacket
    {
        public IPAddrGetPacket()
        {
            this.ip = new IPAddrGetIpNode();
        }

        [XmlElement("ip")]
        public IPAddrGetIpNode ip { get; set; }
    }

    public class IPAddrGetIpNode
    {
        public IPAddrGetIpNode()
        {
            this.get = new IPAddrGetGetNode();
        }

        [XmlElement("get")]
        public IPAddrGetGetNode get { get; set; }
    }

    public class IPAddrGetGetNode
    {

    }
}
