namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class WebSpaceAddResult : IResponseResult
    {
        private ApiResponse _response;

        public WebSpaceAddResult()
        {
            this.webspace = new WebSpaceAddResultNode();
        }

        [XmlElement("webspace")]  
        public WebSpaceAddResultNode webspace { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;            
        }

        public ResponseResult ToResult()
        {
            this.webspace.add.result.apiResponse = _response;
            return this.webspace.add.result;
        }
    }

    public class WebSpaceAddResultNode
    {
        public WebSpaceAddResultNode()
        {
            this.add = new WebSpaceAddResultAddNode();
        }

        [XmlElement("add")]  
        public WebSpaceAddResultAddNode add { get; set; }
    }

    public class WebSpaceAddResultAddNode
    {
        public WebSpaceAddResultAddNode()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")]  
        public ResponseResult result { get; set; }
    }
}
