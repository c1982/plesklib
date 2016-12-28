namespace maestropanel.plesklib.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class WebspaceAddPacket
    {
        public WebspaceAddPacket()
        {
            this.webspace = new WebSpaceNode();
        }

        [XmlElement("webspace")]  
        public WebSpaceNode webspace { get; set; }
    }

    public class WebSpaceNode
    {
        public WebSpaceNode()
        {
            this.add = new WebSpaceAddNode();
        }

        [XmlElement("add")]  
        public WebSpaceAddNode add { get; set; }
    }

    public class WebSpaceAddNode
    {
        public WebSpaceAddNode()
        {
            this.genSetup = new WebSpaceGenSetup();
            this.hosting = new WebSpaceHostingNode();
        }

        [XmlElement("gen_setup")]  
        public WebSpaceGenSetup genSetup { get; set; }

        [XmlElement("hosting")]  
        public WebSpaceHostingNode hosting { get; set; }

        [XmlElement("plan-name")]  
        public string planName { get; set; }
    }

    public class WebSpaceGenSetup
    {
        [XmlElement("name")]
        public string name { get; set; }

        [XmlElement("ip_address")]
        public string ipaddress { get; set; }

        [XmlElement("htype")]
        public string htype  { get; set; }

        [XmlElement("owner-login")]
        public string OwnerLogin { get; set; }
    }

    public class WebSpaceHostingNode
    {
        public WebSpaceHostingNode()
        {
            this.Properties = new List<HostingProperty>().ToArray();
        }

        [XmlArray("vrt_hst")]
        [XmlArrayItem("property")]
        public HostingProperty[] Properties{ get; set; }

        //[XmlElement("ip_address")]
        //public string ipaddress { get; set; }
    }    
}
