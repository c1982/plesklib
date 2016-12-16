namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class WebSpaceDelResult :IResponseResult
    {
        public WebSpaceDelResult()
        {
            this.webspace = new WebSpaceDelResultWebSpaceNode();
        }

        [XmlElement("webspace")] 
        public WebSpaceDelResultWebSpaceNode webspace { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this.webspace.del.result.status = response.Status ? "ok" : "error";
            this.webspace.del.result.ErrorText = response.Message;
            this.webspace.del.result.ErrorCode = 999;
        }

        public ResponseResult ToResult()
        {
            return this.webspace.del.result;
        }
    }

    public class WebSpaceDelResultWebSpaceNode
    {
        public WebSpaceDelResultWebSpaceNode()
        {
            this.del = new WebSpaceDelResultDelNode();
        }

        [XmlElement("del")] 
        public WebSpaceDelResultDelNode del { get; set; }
    }

    public class WebSpaceDelResultDelNode
    {
        public WebSpaceDelResultDelNode()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")]
        public ResponseResult result { get; set; }
    }    
}
