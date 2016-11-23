namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class FtpUserDelPacket
    {

        public FtpUserDelPacket()
        {
            this.ftpUser = new FtpUserDelUserNode();
        }

        [XmlElement("ftp-user")] 
        public FtpUserDelUserNode ftpUser { get; set; }
    }

    public class FtpUserDelUserNode
    {
        public FtpUserDelUserNode()
        {
            this.del = new FtpUserDelNode();
        }

        [XmlElement("del")] 
        public FtpUserDelNode del { get; set; }
    }

    public class FtpUserDelNode
    {
        public FtpUserDelNode()
        {
            this.filter = new FtpUserDelFilter();
        }

        [XmlElement("filter")]
        public FtpUserDelFilter filter { get; set; }
    }

    public class FtpUserDelFilter
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("webspace-name")]
        public string webspaceName { get; set; }
    }
}
