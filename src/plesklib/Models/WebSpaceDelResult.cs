namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class WebSpaceDelResult :IResponseResult
    {
        private ApiResponse _response;

        public WebSpaceDelResult()
        {
            this._response = new ApiResponse();
            this.webspace = new WebSpaceDelResultWebSpaceNode();
        }

        [XmlElement("webspace")] 
        public WebSpaceDelResultWebSpaceNode webspace { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;
        }

        public ResponseResult ToResult()
        {
            this.webspace.del.result.apiResponse = _response;
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
