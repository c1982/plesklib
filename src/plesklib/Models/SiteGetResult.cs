namespace maestropanel.plesklib.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class SiteGetResult : IResponseResult
    {
        private ApiResponse _response;

        public SiteGetResult()
        {
            this.site = new SiteGetResultSite();
        }

        [XmlElement("site")]
        public SiteGetResultSite site { get; set; }

        public void SaveResult(ApiResponse response)
        {
            _response = response;
        }

        public ResponseResult ToResult()
        {
            return _response.ToErrorResult();
        }
    }

    public class SiteGetResultSite
    {
        public SiteGetResultSite()
        {
            this.results = new List<SiteGetResultGet>().ToArray();
        }

        [XmlArray("get")]
        [XmlArrayItem("result")]
        public SiteGetResultGet[] results { get; set; }
    }

    public class SiteGetResultGet
    {
        [XmlElement("status")]
        public string status { get; set; }

        [XmlElement("filter-id")]
        public int filterId { get; set; }

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("data")]
        public SiteGetData data { get; set; }
    }

    public class SiteGetData
    {
        public SiteGetData()
        {
            this.getInfo = new SiteGetGenInfo();
            this.hosting = new SiteGetHosting();
        }

        [XmlElement("gen_info")]
        public SiteGetGenInfo getInfo { get; set; }

        [XmlElement("hosting")]
        public SiteGetHosting hosting { get; set; }
    }

    public class SiteGetGenInfo
    {
        [XmlElement("cr_date")]
        public string crDate { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("ascii-name")]
        public string asciiName { get; set; }

        [XmlElement("status")]
        public string status { get; set; }

        [XmlElement("real_size")]
        public int realSize { get; set; }

        [XmlElement("dns_ip_address")]
        public string dnsIpAddr { get; set; }

        [XmlElement("htype")]
        public string htype { get; set; }

        [XmlElement("guid")]
        public string guid { get; set; }

        [XmlElement("webspace-guid")]
        public string webspaceGuid { get; set; }

        [XmlElement("webspace-id")]
        public int webspaceId { get; set; }

        [XmlElement("description")]
        public string description { get; set; }
    }

    public class SiteGetHosting
    {
        public SiteGetHosting()
        {
            this.Properties = new List<HostingProperty>().ToArray();
        }

        [XmlArray("vrt_hst")]
        [XmlArrayItem("property")]
        public HostingProperty[] Properties { get; set; }
    }    

}
