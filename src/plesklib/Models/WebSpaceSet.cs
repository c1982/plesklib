namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class WebSpaceSetPacket
    {
        public WebSpaceSetPacket()
        {
            this.webspace = new WebSpaceSetWebSpaceNode();
        }

        [XmlElement("webspace")]
        public WebSpaceSetWebSpaceNode webspace { get; set; }
    }

    public class WebSpaceSetWebSpaceNode
    {
        public WebSpaceSetWebSpaceNode()
        {
            this.setvalue = new WebSpaceSetSetNode();
        }

        [XmlElement("set")]
        public WebSpaceSetSetNode setvalue { get; set; }
    }

    public class WebSpaceSetSetNode
    {
        public WebSpaceSetSetNode()
        {
            this.filter = new WebSpaceSetFilterNode();
            this.values = new WebSpaceSetValuesNode();
        }

        [XmlElement("filter")]
        public WebSpaceSetFilterNode filter { get; set; }

        [XmlElement("values")]
        public WebSpaceSetValuesNode values { get; set; }

    }

    public class WebSpaceSetFilterNode
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }

    public class WebSpaceSetValuesNode
    {
        public WebSpaceSetValuesNode()
        {
            this.gensetup = new WebSpaceSetGenSetupNode();
        }

        [XmlElement("gen_setup")]
        public WebSpaceSetGenSetupNode gensetup { get; set; }
    }

    public class WebSpaceSetGenSetupNode
    {
        //Allowed values: 0 (active) | 16 (disabled by Plesk Administrator) | 32 (disabled by Plesk reseller) | 64 (disabled by customer).
        [XmlElement("status")]
        public string status { get; set; }
    }
}
