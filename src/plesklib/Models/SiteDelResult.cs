namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SiteDelResult : IResponseResult
    {
        public SiteDelResult()
        {
            this.site = new SiteDelSiteResult();
        }

        [XmlElement("site")]
        public SiteDelSiteResult site { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this.site.del.result = response.ToErrorResult();
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
