namespace maestropanel.plesklib.Models
{
    using System.Collections.Generic;
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
            this.limits = new WebSpaceSetLimitsNode();
        }

        [XmlElement("gen_setup")]
        public WebSpaceSetGenSetupNode gensetup { get; set; }
        
        [XmlElement("limits")]
        public WebSpaceSetLimitsNode limits { get; set; }

        [XmlElement("pref")]
        public WebSpaceSetPrefNode pref { get; set; }

        [XmlElement("hosting")]
        public WebSpaceSetHostingNode hosting { get; set; }
        
    }

    public class WebSpaceSetGenSetupNode
    {
        //Allowed values: 0 (active) | 16 (disabled by Plesk Administrator) | 32 (disabled by Plesk reseller) | 64 (disabled by customer).
        [XmlElement("status")]
        public string status { get; set; }

        [XmlElement("name")]
        public string name { get; set; }
    }

    public class WebSpaceSetLimitsNode
    {
        public WebSpaceSetLimitsNode()
        {
            this.limit = new List<HostingProperty>().ToArray();
        }

        [XmlElement("overuse")]
        public string overuse { get; set; }

        [XmlArray("limit")]
        public HostingProperty[] limit { get; set; }
    }
    
    public class WebSpaceSetPrefNode
    {
        [XmlElement("www")]
        public string www { get; set; }

        [XmlElement("stat_ttl")]
        public int stat_ttl { get; set; }

        [XmlElement("outgoing-messages-domain-limit")]
        public int outgoingMsgDomainLimit { get; set; }
    }

    public class WebSpaceSetHostingNode
    {
        public WebSpaceSetHostingNode()
        {
            this.vrtHst = new WebSpaceSetHostingVrtHstNode();
            this.stdFwd = new WebSpaceSetHostingStdFwd();
            this.frmFwd = new WebSpaceSetHostingStdFwd();
        }
        
        [XmlElement("www")]
        public WebSpaceSetHostingVrtHstNode vrtHst { get; set; }

        [XmlElement("std_fwd")]
        public WebSpaceSetHostingStdFwd stdFwd { get; set; }

        [XmlElement("frm_fwd")]
        public WebSpaceSetHostingStdFwd frmFwd { get; set; }
    }

    public class WebSpaceSetHostingVrtHstNode
    {
        public WebSpaceSetHostingVrtHstNode()
        {
            this.property = new List<HostingProperty>().ToArray();
            this.ipaddress = new List<string>().ToArray();
        }

        [XmlArray("property")]
        public HostingProperty[] property { get; set; }

        [XmlArray("ip_address")]
        public string[] ipaddress { get; set; }
    }

    public class WebSpaceSetHostingStdFwd
    {
        [XmlElement("dest_url")]
        public string destUrl { get; set; }

        [XmlElement("ip_address")]
        public string ipv4addr { get; set; }

        [XmlElement("ip_address")]
        public string ipv6addr { get; set; }
    }
        
}
