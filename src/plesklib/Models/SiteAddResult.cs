namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SiteAddResult : IResponseResult
    {
        public SiteAddResult()
        {
            this.site = new SiteResult() { addResult = new AddResult { result = new ResponseResult { } } };
        }

        [XmlElement("site")]
        public SiteResult site { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this.site.addResult.result = response.ToErrorResult();
        }
    }

    public class SiteResult
    {
        public SiteResult()
        {
            this.addResult = new AddResult();
        }

        [XmlElement("add")]
        public AddResult addResult { get; set; }
    }

    public class AddResult
    {
        public AddResult()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")]
        public ResponseResult result { get; set; }
    }
}
