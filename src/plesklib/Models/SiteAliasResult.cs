namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SiteAliasPacketResult : IResponseResult
    {
        public SiteAliasPacketResult()
        {
            this.siteAlias = new SiteAliasResult();
        }

        [XmlElement("site-alias")]
        public SiteAliasResult siteAlias { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this.siteAlias.create.result = response.ToErrorResult();
        }
    }

    public class SiteAliasResult 
    {
        public SiteAliasResult()
        {
            this.create = new SiteAliasCreateResult();
        }
        
        [XmlElement("create")]
        public SiteAliasCreateResult create { get; set; }
    }

    public class SiteAliasCreateResult
    {
        public SiteAliasCreateResult()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")]
        public ResponseResult result { get; set; }
    }
}
