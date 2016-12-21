namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class EmailAddPacket
    {
        public EmailAddPacket()
        {
            this.mail = new EmailAddPacketMailNode();
        }

        [XmlElement("mail")]
        public EmailAddPacketMailNode mail { get; set; }
    }

    public class EmailAddPacketMailNode
    {

        public EmailAddPacketMailNode()
        {
            this.create = new EmailAddPacketCreateNode();
        }

        [XmlElement("create")]
        public EmailAddPacketCreateNode create { get; set; }
    }

    public class EmailAddPacketCreateNode
    {
        public EmailAddPacketCreateNode()
        {
            this.filter = new EmailAddPacketFilterNode();
        }

        [XmlElement("filter")]
        public EmailAddPacketFilterNode filter { get; set; }
    }

    public class EmailAddPacketFilterNode
    {
        public EmailAddPacketFilterNode()
        {
            this.mailname = new EmailAddPacketMailNameNode();
        }

        [XmlElement("site-id")]
        public int siteId { get; set; }

        [XmlElement("mailname")]
        public EmailAddPacketMailNameNode mailname { get; set; }

    }

    public class EmailAddPacketMailNameNode
    {
        public EmailAddPacketMailNameNode()
        {
            this.mailbox = new EmailAddPacketMailBoxNode();
            this.password = new EmailAddPacketPasswordNode();
        }

        [XmlElement("name")]
        public string name { get; set; }

        [XmlElement("mailbox")]
        public EmailAddPacketMailBoxNode mailbox { get; set; }

        [XmlElement("password")]
        public EmailAddPacketPasswordNode password { get; set; }

    }

    public class EmailAddPacketMailBoxNode
    {
        [XmlElement("enabled")]
        public string enabled { get; set; }

        [XmlElement("quota")]
        public int quota { get; set; }
    }

    public class EmailAddPacketPasswordNode
    {
        [XmlElement("value")]
        public string value { get; set; }

        [XmlElement("type")]
        public string type { get; set; }
    }

    
}
