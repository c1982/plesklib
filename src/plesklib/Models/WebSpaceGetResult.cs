namespace maestropanel.plesklib.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class WebSpaceGetResult : IResponseResult
    {
        private ApiResponse _response;

        public WebSpaceGetResult()
        {
            _response = new ApiResponse();
            this.webspace = new WebSpaceGetResultWebSpaceNode();
        }

        [XmlElement("webspace")]
        public WebSpaceGetResultWebSpaceNode webspace { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;
        }

        public ResponseResult ToResult()
        {
            return this._response.ToErrorResult();
        }
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
            this.result = new WebSpaceGetResultResultNode();   
        }

        [XmlElement("result")]
        public WebSpaceGetResultResultNode result { get; set; }
    }


    public class WebSpaceGetResultResultNode
    {
        public WebSpaceGetResultResultNode()
        {
            this.data = new WebSpaceGetResultDataNode();
        }

        [XmlElement("status")]
        public string status { get; set; }

        [XmlElement("filter-id")]
        public string filterId { get; set; }

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("data")]
        public WebSpaceGetResultDataNode data { get; set; }
    }


    public class WebSpaceGetResultDataNode
    {
        public WebSpaceGetResultDataNode()
        {
            this.hosting = new WebSpaceGetResultHostingNode();
            this.info = new WebSpaceGetResultGenInfoNode();
        }

        [XmlElement("gen_info")]
        public WebSpaceGetResultGenInfoNode info { get; set; }

        [XmlElement("hosting")]
        public WebSpaceGetResultHostingNode hosting { get; set; }
    }

    public class WebSpaceGetResultGenInfoNode
    {
        [XmlElement("cr_date")]
        public string createDate { get; set; }

        [XmlElement("name")]
        public string name { get; set; }

        [XmlElement("ascii-name")]
        public string aciiName { get; set; }

        [XmlElement("status")]
        public string status { get; set; }

        [XmlElement("real_size")]
        public string realSize { get; set; }

        [XmlElement("owner-login")]
        public string ownerLogin { get; set; }

        [XmlElement("dns_ip_address")]
        public string dnsIpAddr { get; set; }

        [XmlElement("htype")]
        public string htype { get; set; }

        [XmlElement("guid")]
        public string guid { get; set; }

        [XmlElement("vendor-guid")]
        public string vendorGuid { get; set; }

        [XmlElement("external-id")]
        public string externalId { get; set; }

        [XmlElement("sb-site-uuid")]
        public string sitebuilderSiteUuid { get; set; }

        [XmlElement("description")]
        public string description { get; set; }

        [XmlElement("admin-description")]
        public string adminDescription { get; set; }
    }

    public class WebSpaceGetResultHostingNode
    {
        public WebSpaceGetResultHostingNode()
        {
            //this.standardForward = new WebSpaceGetResultStdFwdNode();
            //this.frameForward = new WebSpaceGetResultFrmFwdNode();
            this.properties = new List<HostingProperty>().ToArray();
        }

        [XmlArray("vrt_hst")]
        [XmlArrayItem("property")]
        public HostingProperty[] properties { get; set; }

        //[XmlElement("std_fwd")]
        //public WebSpaceGetResultStdFwdNode standardForward { get; set; }

        //[XmlElement("frm_fwd")]
        //public WebSpaceGetResultFrmFwdNode frameForward { get; set; }
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
    
    public class WebSpaceGetResultStatsNode
    {
        [XmlElement("traffic")]
        public long traffic { get; set; }

        [XmlElement("subdom")]
        public int subdomain { get; set; }

        [XmlElement("wu")]
        public int webUsers { get; set; }

        [XmlElement("box")]
        public int mailBoxes { get; set; }

        [XmlElement("redir")]
        public int mailRedirects { get; set; }

        [XmlElement("mg")]
        public int mailGroups { get; set; }

        [XmlElement("resp")]
        public int mailResponses { get; set; }

        [XmlElement("maillists")]
        public int mailLists { get; set; }

        [XmlElement("db")]
        public int databases { get; set; }

        [XmlElement("webapps")]
        public int webapps { get; set; }

        [XmlElement("traffic_prevday")]
        public long traffic_prevday { get; set; }
    }

}
