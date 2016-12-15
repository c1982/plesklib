namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class DatabaseUserAddPacket
    {
        public DatabaseUserAddPacket()
        {
            this.database = new DatabaseUserAddDatabaseNode();
        }

        [XmlElement("database")]
        public DatabaseUserAddDatabaseNode database { get; set; }
    }

    public class DatabaseUserAddDatabaseNode
    {

        [XmlElement("add-db-user")]
        public DatabaseUserAddAddDbUserNode addUser { get; set; }
    }

    public class DatabaseUserAddAddDbUserNode
    {
        [XmlElement("db-id")]
        public int dbId { get; set; }

        [XmlElement("add-db-user")]
        public int webSpaceId { get; set; }

        [XmlElement("add-db-user")]
        public int dbServerId { get; set; }

        [XmlElement("login")]
        public string login { get; set; }

        [XmlElement("password")]
        public string password { get; set; }

        [XmlElement("password-type")]
        public string passwordType { get; set; }

        [XmlElement("role")]
        public string role { get; set; }
    }
}
