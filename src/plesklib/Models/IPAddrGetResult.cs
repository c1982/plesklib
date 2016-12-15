namespace maestropanel.plesklib.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class IPAddrGetResult : IResponseResult
    {
        public IPAddrGetResult()
        {
            this.ip = new IPAddrGetResultIpNode();
        }

        [XmlElement("ip")]
        public IPAddrGetResultIpNode ip { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this.ip.get.result.status = response.Status ? "ok" : "result";
            this.ip.get.result.ErrorText = response.Message;
            this.ip.get.result.ErrorCode = 999;
        }
    }

    public class IPAddrGetResultIpNode
    {
        public IPAddrGetResultIpNode()
        {
            this.get = new IPAddrGetResultGetNode();
        }

        [XmlElement("get")]
        public IPAddrGetResultGetNode get { get; set; }
    }

    public class IPAddrGetResultGetNode
    {
        public IPAddrGetResultGetNode()
        {
            this.result = new IPAddrGetResultResultNode();
        }

        [XmlElement("result")]
        public IPAddrGetResultResultNode result { get; set; }
    }

    public class IPAddrGetResultResultNode
    {
        public IPAddrGetResultResultNode()
        {
            this.ipinfo = new List<IPaddGetResultIpInfo>().ToArray();
        }

        [XmlElement("status")]
        public string status { get; set; }

        [XmlElement("errcode")]
        public int ErrorCode { get; set; }

        [XmlElement("errtext")]
        public string ErrorText { get; set; }        

        [XmlArray("addresses")]
        [XmlArrayItem("ip_info")]
        public IPaddGetResultIpInfo[] ipinfo { get; set; }

    }

    public class IPaddGetResultIpInfo
    {
        [XmlElement("ip_address")]
        public string ipaddress { get; set; }

        [XmlElement("netmask")]
        public string netmask { get; set; }

        [XmlElement("type")]
        public string iptype { get; set; }

        [XmlElement("interface")]
        public string ethinterface { get; set; }
    }
}
