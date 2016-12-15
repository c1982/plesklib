namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class DatabaseUserGetPacket
    {
        public DatabaseUserGetPacket()
        {
            this.database = new DatabaseUserGetDatabaseNode();
        }

        [XmlElement("database")]
        public DatabaseUserGetDatabaseNode database { get; set; }
    }

    public class DatabaseUserGetDatabaseNode
    {
        public DatabaseUserGetDatabaseNode()
        {
            this.users = new DatabaseUserGetDbUsersNode();
        }

        [XmlElement("get-db-users")]
        public DatabaseUserGetDbUsersNode users { get; set; }
    }

    public class DatabaseUserGetDbUsersNode
    {
        public DatabaseUserGetDbUsersNode()
        {
            this.filter = new DatabaseUserGetFilterNode();
        }

        [XmlElement("filter")]
        public DatabaseUserGetFilterNode filter { get; set; }
    }

    public class DatabaseUserGetFilterNode
    {        
        [XmlElement("db-id")]
        public int databaseId { get; set; }
    }
}
