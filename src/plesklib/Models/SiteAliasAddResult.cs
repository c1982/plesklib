namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SiteAliasAddPacketResult : IResponseResult
    {
        public SiteAliasAddPacketResult()
        {
            this.siteAlias = new SiteAliasAddResult();
        }

        [XmlElement("site-alias")]
        public SiteAliasAddResult siteAlias { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this.siteAlias.create.result = response.ToErrorResult();
        }

        public ResponseResult ToResult()
        {
            return this.siteAlias.create.result;
        }
    }

    public class SiteAliasAddResult 
    {
        public SiteAliasAddResult()
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
