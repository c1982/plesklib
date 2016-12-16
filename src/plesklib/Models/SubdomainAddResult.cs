namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SubdomainAddResult : IResponseResult
    {
        public SubdomainAddResult()
        {
            this.subdomain = new SubdomainAddSubdomainResult();
        }

        [XmlElement("subdomain")]
        public SubdomainAddSubdomainResult subdomain { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this.subdomain.add.result = response.ToErrorResult();
        }

        public ResponseResult ToResult()
        {
            return this.subdomain.add.result;
        }
    }

    public class SubdomainAddSubdomainResult
    {
        public SubdomainAddSubdomainResult()
        {
            this.add = new SubdomainAddAddResult();
        }

        [XmlElement("add")]
        public SubdomainAddAddResult add { get; set; }
    }

    public class SubdomainAddAddResult
    {
        public SubdomainAddAddResult()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")]
        public ResponseResult result { get; set; }
    }
}
