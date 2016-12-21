namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SiteAliasDelResult : IResponseResult
    {
        private ApiResponse _response;

        public SiteAliasDelResult()
        {
            this._response = new ApiResponse();
            this.siteAlias = new SiteAliasSiteResult();
        }

        [XmlElement("site-alias")]
        public SiteAliasSiteResult siteAlias { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;            
        }

        public ResponseResult ToResult()
        {
            this.siteAlias.delete.result.apiResponse = _response;
            return this.siteAlias.delete.result;
        }
    }

    public class SiteAliasSiteResult
    {
        public SiteAliasSiteResult()
        {
            this.delete = new SiteAliasDeleteResult();
        }

        [XmlElement("delete")]
        public SiteAliasDeleteResult delete { get; set; }
    }

    public class SiteAliasDeleteResult
    {
        public SiteAliasDeleteResult()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")]
        public ResponseResult result { get; set; }
    }
}
