namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class DatabaseDelPacket
    {
        public DatabaseDelPacket()
        {
            this.database = new DatabaseDelDatabaseNode();
        }

        [XmlElement("database")]
        public DatabaseDelDatabaseNode database { get; set; }
    }

    public class DatabaseDelDatabaseNode
    {
        public DatabaseDelDatabaseNode()
        {
            this.del = new DatabaseDelDelDbNode();
        }

        [XmlElement("del-db")]
        public DatabaseDelDelDbNode del { get; set; }
    }

    public class DatabaseDelDelDbNode
    {
        public DatabaseDelDelDbNode()
        {
            this.filter = new DatabaseDelFilterNode();
        }

        [XmlElement("filter")]
        public DatabaseDelFilterNode filter { get; set; }
    }

    public class DatabaseDelFilterNode
    {
        [XmlElement("db-id")]
        public int dbid { get; set; }
    }
}
