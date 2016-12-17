namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    public class ApiResponse
    {
        public bool Status { get; set; }        
        public string Message { get; set; }
        public string MessageDetails { get; set; }
        public string RequestXmlString { get; set; }
        public string ResponseXmlString { get; set; }

        public ApiErrorResponse error { get; set; }

        public ApiResponse()
        {
            
        }

        public ResponseResult ToErrorResult()
        {
            return new ResponseResult() { status = this.Status ? "ok" : "error", 
                                            ErrorCode = 999, 
                                            ErrorText = this.Message, 
                                            response = this};
        }
    }

    [XmlRoot("packet")]
    public class ApiErrorResponse
    {
        public ApiErrorResponse()
        {
            this.system = new ApiErrorResponseSystemNode();
        }
        
        [XmlAttribute("version")]
        public string version { get; set; }

        [XmlElement("system")]
        public ApiErrorResponseSystemNode system { get; set; }
    }

    public class ApiErrorResponseSystemNode
    {
        [XmlElement("status")]
        public string status { get; set; }

        [XmlElement("errorcode")]
        public int errorcode { get; set; }

        [XmlElement("errtext")]
        public string errtext { get; set; }
    }
}
