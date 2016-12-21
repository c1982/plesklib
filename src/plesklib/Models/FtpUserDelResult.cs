namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class FtpUserDelResult : IResponseResult
    {
        private ApiResponse _response;

        public FtpUserDelResult()
        {
            this._response = new ApiResponse();
            this.ftpUser = new FtpUserDelResultFtpUserNode();
        }
       
        [XmlElement("ftp-user")]
        public FtpUserDelResultFtpUserNode ftpUser { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;
        }

        public ResponseResult ToResult()
        {
            this.ftpUser.del.result.apiResponse = _response;
            return this.ftpUser.del.result;
        }
    }

    public class FtpUserDelResultFtpUserNode
    {
        public FtpUserDelResultFtpUserNode()
        {
            this.del = new FtpUserDelResultDelNode();
        }

        [XmlElement("del")] 
        public FtpUserDelResultDelNode del { get; set; }
    }

    public class FtpUserDelResultDelNode
    {
        public FtpUserDelResultDelNode()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")] 
        public ResponseResult result { get; set; }
    }

}
