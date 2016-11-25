namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class DatabaseGetPacket
    {
        public DatabaseGetPacket()
        {
            this.database = new DatabaseGetDbNode();
        }

        [XmlElement("database")]
        public DatabaseGetDbNode database { get; set; }
    }

    public class DatabaseGetDbNode
    {
        public DatabaseGetDbNode()
        {
            this.getDb = new DatabaseGetGetDbNode();
        }

        [XmlElement("get-db")]
        public DatabaseGetGetDbNode getDb { get; set; }
    }

    public class DatabaseGetGetDbNode
    {
        public DatabaseGetGetDbNode()
        {
            this.filter = new DatabaseGetFilterNode();
        }

        [XmlElement("filter")]
        public DatabaseGetFilterNode filter { get; set; }
    }

    public class DatabaseGetFilterNode
    {
        [XmlElement("webspace-name")]
        public string webspaceName { get; set; }
    }
    

}
