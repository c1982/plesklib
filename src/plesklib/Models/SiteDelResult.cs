namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SiteDelResult : IResponseResult
    {
        private ApiResponse _response;

        public SiteDelResult()
        {
            this._response = new ApiResponse();
            this.site = new SiteDelSiteResult();
        }

        [XmlElement("site")]
        public SiteDelSiteResult site { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;            
        }

        public ResponseResult ToResult()
        {
            this.site.del.result.apiResponse = _response;
            return this.site.del.result;
        }
    }

    public class SiteDelSiteResult
    {
        public SiteDelSiteResult()
        {
            this.del = new SiteDelDelResult();
        }

        [XmlElement("del")]
        public SiteDelDelResult del { get; set; }
    }

    public class SiteDelDelResult
    {
        public SiteDelDelResult()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")]
        public ResponseResult result { get; set; }
    }
}
