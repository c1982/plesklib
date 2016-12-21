namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SubdomainDeleteResult : IResponseResult
    {
        private ApiResponse _response;

        public SubdomainDeleteResult()
        {
            this._response = new ApiResponse();
            this.subdomain = new SubdomainDeleteSubdomainResult();
        }

        [XmlElement("subdomain")]
        public SubdomainDeleteSubdomainResult subdomain { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;            
        }

        public ResponseResult ToResult()
        {
            this.subdomain.del.result.apiResponse = _response;
            return this.subdomain.del.result;
        }
    }

    public class SubdomainDeleteSubdomainResult
    {
        public SubdomainDeleteSubdomainResult()
        {
            this.del = new SubdomainDeleteDelResult();
        }

        [XmlElement("del")]
        public SubdomainDeleteDelResult del { get; set; }
    }

    public class SubdomainDeleteDelResult
    {
        public SubdomainDeleteDelResult()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")]
        public ResponseResult result { get; set; }

    }
    
}
