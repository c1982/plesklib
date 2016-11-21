namespace plesklib.Models
{
    using System.Xml.Serialization;

    public class ResponseResult
    {
        [XmlElement("status")]
        public string status { get; set; }

        [XmlElement("errcode")]
        public int ErrorCode { get; set; }

        [XmlElement("errtext")]
        public string ErrorText { get; set; }

        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("guid")]
        public string guid { get; set; }
    }
}
