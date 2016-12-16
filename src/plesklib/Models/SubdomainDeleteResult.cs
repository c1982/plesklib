namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SubdomainDeleteResult : IResponseResult
    {
        public SubdomainDeleteResult()
        {
            this.subdomain = new SubdomainDeleteSubdomainResult();
        }

        [XmlElement("subdomain")]
        public SubdomainDeleteSubdomainResult subdomain { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this.subdomain.del.result = response.ToErrorResult();
        }


        public ResponseResult ToResult()
        {
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
