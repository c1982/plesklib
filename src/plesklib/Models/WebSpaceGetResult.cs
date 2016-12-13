namespace plesklib.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class WebSpaceGetResult
    {

        public WebSpaceGetResult()
        {
            this.webspace = new WebSpaceGetResultWebSpaceNode();
        }

        [XmlElement("webspace")]
        public WebSpaceGetResultWebSpaceNode webspace { get; set; }
    }

    public class WebSpaceGetResultWebSpaceNode
    {
        public WebSpaceGetResultWebSpaceNode()
        {
            this.getWebSpace = new WebSpaceGetResultGetNode();
        }

        [XmlElement("get")]
        public WebSpaceGetResultGetNode getWebSpace { get; set; }
    }

    public class WebSpaceGetResultGetNode
    {
        public WebSpaceGetResultGetNode()
        {
            this.filter = new WebSpaceGetResultFilterNode();
            this.dataset = new WebSpaceGetResultDatasetNode();
        }

        [XmlElement("filter")]
        public WebSpaceGetResultFilterNode filter { get; set; }

        [XmlElement("dataset")]
        public WebSpaceGetResultDatasetNode dataset { get; set; }
    }

    public class WebSpaceGetResultFilterNode
    {
        [XmlElement("id")]
        public int Id { get; set; }
    }

    public class WebSpaceGetResultDatasetNode
    {
        public WebSpaceGetResultDatasetNode()
        {
            this.hosting = new WebSpaceGetResultHostingNode();
        }

        [XmlElement("hosting")]
        public WebSpaceGetResultHostingNode hosting { get; set; }

    }

    public class WebSpaceGetResultHostingNode
    {
        public WebSpaceGetResultHostingNode()
        {
            this.standardForward = new WebSpaceGetResultStdFwdNode();
            this.frameForward = new WebSpaceGetResultFrmFwdNode();
            this.properties = new List<HostingProperty>().ToArray();
        }

        [XmlArray("vrt_hst")]
        [XmlArrayItem("property")]
        public HostingProperty[] properties { get; set; }

        [XmlElement("std_fwd")]
        public WebSpaceGetResultStdFwdNode standardForward { get; set; }

        [XmlElement("frm_fwd")]
        public WebSpaceGetResultFrmFwdNode frameForward { get; set; }
    }

    public class WebSpaceGetResultStdFwdNode
    {
        [XmlElement("dest_url")]
        public string destinationUrl { get; set; }
    }


    public class WebSpaceGetResultFrmFwdNode
    {
        [XmlElement("dest_url")]
        public string destinationUrl { get; set; }
    }


}
