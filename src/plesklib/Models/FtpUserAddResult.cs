namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class FtpUserAddResult :IResponseResult
    {
        private ApiResponse _response;

        public FtpUserAddResult()
        {
            this._response = new ApiResponse();
            this.ftpUser = new FtpUserAddResultFtpUserNode();
        }

        [XmlElement("ftp-user")]
        public FtpUserAddResultFtpUserNode ftpUser { get; set; }

        public void SaveResult(ApiResponse response)
        {
            _response = response;            
        }

        public ResponseResult ToResult()
        {
            this.ftpUser.add.result.apiResponse = _response;
            return this.ftpUser.add.result;
        }
    }

    public class FtpUserAddResultFtpUserNode
    {
        public FtpUserAddResultFtpUserNode()
        {
            this.add = new FtpUserAddResultAddNode();
        }

        [XmlElement("add")] 
        public FtpUserAddResultAddNode add { get; set; }
    }

    public class FtpUserAddResultAddNode
    {
        public FtpUserAddResultAddNode()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")] 
        public ResponseResult result { get; set; }
    }
    
}
