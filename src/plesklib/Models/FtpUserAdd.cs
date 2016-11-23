namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class FtpUserAddPacket
    {
        public FtpUserAddPacket()
        {
            this.ftpUser = new FtpUserAddFtpUser();
        }

        [XmlElement("ftp-user")] 
        public FtpUserAddFtpUser ftpUser { get; set; }
    }

    public class FtpUserAddFtpUser
    {
        public FtpUserAddFtpUser()
        {
            this.add = new FtpUserAddNode();
        }
        
        [XmlElement("add")] 
        public FtpUserAddNode add { get; set; }
    }

    public class FtpUserAddNode
    {
        [XmlElement("name")] 
        public string username { get; set; }

        [XmlElement("password")] 
        public string password { get; set; }

        [XmlElement("home")] 
        public string home { get; set; }

        [XmlElement("quota")]
        public int quota { get; set; }

        [XmlElement("webspace-name")] 
        public string wespacename { get; set; }
    }
}
