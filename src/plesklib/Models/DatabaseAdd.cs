namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class DatabaseAddPacket
    {
        public DatabaseAddPacket()
        {
            this.database = new DatabaseAddDatabaseNode();
        }

        [XmlElement("database")]
        public DatabaseAddDatabaseNode database { get; set; }
    }

    public class DatabaseAddDatabaseNode
    {
        public DatabaseAddDatabaseNode()
        {
            this.add = new DatabaseAddDbAddNode();
        }

        [XmlElement("add-db")]
        public DatabaseAddDbAddNode add { get; set; }
    }

    public class DatabaseAddDbAddNode
    {   
        [XmlElement("webspace-id")]
        public int webspaceid { get; set; }

        [XmlElement("name")]
        public string name { get; set; }

        [XmlElement("type")]
        public string type { get; set; }
    }
}
