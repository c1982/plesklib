namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class DatabaseUserDelPacket
    {
        public DatabaseUserDelPacket()
        {
            this.database = new DatabaseUserDelDatabaseNode();
        }

        [XmlElement("database")]
        public DatabaseUserDelDatabaseNode database { get; set; }
    }

    public class DatabaseUserDelDatabaseNode
    {
        public DatabaseUserDelDatabaseNode()
        {
            this.del = new DatabaseUserDelDbUserNode();
        }

        [XmlElement("del-db-user")]
        public DatabaseUserDelDbUserNode del { get; set; }
    }

    public class DatabaseUserDelDbUserNode
    {
        public DatabaseUserDelDbUserNode()
        {
            this.filter = new DatabaseUserDelFilter();
        }

        [XmlElement("filter")]
        public DatabaseUserDelFilter filter { get; set; }
    }

    public class DatabaseUserDelFilter
    {
        [XmlElement("id")]
        public int userId { get; set; }

        [XmlElement("db-id ")]
        public int databaseId { get; set; }
    }
}
