namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SiteAliasAddPacketResult : IResponseResult
    {
        private ApiResponse _response;

        public SiteAliasAddPacketResult()
        {
            this.siteAlias = new SiteAliasAddResultSiteAliasNode();
        }

        [XmlElement("site-alias")]
        public SiteAliasAddResultSiteAliasNode siteAlias { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;
        }

        public ResponseResult ToResult()
        {
            this.siteAlias.create.result.apiResponse = this._response;                        
            return this.siteAlias.create.result;
        }
    }

    public class SiteAliasAddResultSiteAliasNode
    {
        public SiteAliasAddResultSiteAliasNode()
        {
            this.create = new SiteAliasAddCreateResultNode();
        }
        
        [XmlElement("create")]
        public SiteAliasAddCreateResultNode create { get; set; }
    }

    public class SiteAliasAddCreateResultNode
    {
        public SiteAliasAddCreateResultNode()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")]
        public ResponseResult result { get; set; }
    }
}
