namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SiteAliasDelResult : IResponseResult
    {
        public SiteAliasDelResult()
        {
            this.siteAlias = new SiteAliasSiteResult();
        }

        [XmlElement("site-alias")]
        public SiteAliasSiteResult siteAlias { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this.siteAlias.delete.result = response.ToErrorResult();
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
