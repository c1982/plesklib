namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class FtpUserAddResult :IResponseResult
    {
        public FtpUserAddResult()
        {
            this.ftpUser = new FtpUserAddResultFtpUserNode();
        }

        [XmlElement("ftp-user")]
        public FtpUserAddResultFtpUserNode ftpUser { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this.ftpUser.add.result = response.ToErrorResult();
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
