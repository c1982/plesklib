namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class FtpUserDelResult : IResponseResult
    {
        public FtpUserDelResult()
        {
            this.ftpUser = new FtpUserDelResultFtpUserNode();
        }
       
        [XmlElement("ftp-user")]
        public FtpUserDelResultFtpUserNode ftpUser { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this.ftpUser.del.result = response.ToErrorResult();
        }

        public ResponseResult ToResult()
        {
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
