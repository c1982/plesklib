namespace maestropanel.plesklib.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SiteGetResult : IResponseResult
    {
        private ApiResponse _response;

        public SiteGetResult()
        {
            _response = new ApiResponse();
            this.site = new SiteGetResultSiteNode();
        }

        [XmlElement("site")]
        public SiteGetResultSiteNode site { get; set; }

        public void SaveResult(ApiResponse response)
        {
            _response = response;
        }

        public ResponseResult ToResult()
        {
            if (this._response.Status)
                return new ResponseResult()
                {
                    apiResponse = _response,
                    ErrorCode = this.site.receive.result.errcode,
                    ErrorText = this.site.receive.result.errtext,
                    status = this.site.receive.result.status
                };
            else
                return this._response.ToErrorResult();
        }
    }

    public class SiteGetResultSiteNode
    {
        public SiteGetResultSiteNode()
        {
            this.receive = new SiteGetResultGetNode();
        }

        [XmlElement("get")]      
        public SiteGetResultGetNode receive { get; set; }
    }

    public class SiteGetResultGetNode
    {
        public SiteGetResultGetNode()
        {
            this.result = new SiteGetResultResultNode();
        }

         [XmlElement("result")]
        public SiteGetResultResultNode result { get; set; }
    }

    public class SiteGetResultResultNode
    {
        [XmlElement("status")]
        public string status { get; set; }

        [XmlElement("errcode")]
        public int errcode { get; set; }

        [XmlElement("errtext")]
        public string errtext { get; set; }

        [XmlElement("filter-id")]
        public string filterId { get; set; }

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("data")]
        public SiteGetResultDataNode data { get; set; }
    }

    public class SiteGetResultDataNode
    {
        public SiteGetResultDataNode()
        {
            this.getInfo = new SiteGetGenInfoNode();
            this.hosting = new SiteGetHostingNode();
        }

        [XmlElement("gen_info")]
        public SiteGetGenInfoNode getInfo { get; set; }

        [XmlElement("hosting")]
        public SiteGetHostingNode hosting { get; set; }
    }

    public class SiteGetGenInfoNode
    {
        [XmlElement("cr_date")]
        public string crDate { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("ascii-name")]
        public string asciiName { get; set; }

        [XmlElement("status")]
        public string status { get; set; }

        [XmlElement("real_size")]
        public int realSize { get; set; }

        [XmlElement("dns_ip_address")]
        public string dnsIpAddr { get; set; }

        [XmlElement("htype")]
        public string htype { get; set; }

        [XmlElement("guid")]
        public string guid { get; set; }

        [XmlElement("webspace-guid")]
        public string webspaceGuid { get; set; }

        [XmlElement("webspace-id")]
        public int webspaceId { get; set; }

        [XmlElement("description")]
        public string description { get; set; }
    }

    public class SiteGetHostingNode
    {
        public SiteGetHostingNode()
        {
            this.Properties = new List<HostingProperty>().ToArray();
        }

        [XmlArray("vrt_hst")]
        [XmlArrayItem("property")]
        public HostingProperty[] Properties { get; set; }
    }    

}
