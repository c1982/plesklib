namespace maestropanel.plesklib.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class DatabaseUserSetPacket
    {
        public DatabaseUserSetPacket()
        {
            this.database = new DatabaseUserSetDatabaseNode();
        }

        [XmlElement("database")]
        public DatabaseUserSetDatabaseNode database { get; set; }
    }

    public class DatabaseUserSetDatabaseNode
    {
        public DatabaseUserSetDatabaseNode()
        {
            this.setDbUser = new DatabaseUserSetDatabaseUserNode();
        }

        [XmlElement("set-db-user")]
        public DatabaseUserSetDatabaseUserNode setDbUser { get; set; }
    }

    public class DatabaseUserSetDatabaseUserNode
    {
        public DatabaseUserSetDatabaseUserNode()
        {
            this.accessList = new List<string>().ToArray();
            this.aclList = new List<string>().ToArray();
        }


        [XmlElement("id")]
        public int databaseUserId { get; set; }

        [XmlElement("password")]
        public string password { get; set; }

        [XmlArray("acl")]
        [XmlArrayItem("host")]
        public string[] aclList { get; set; }

        [XmlArray("allow-access-from")]
        [XmlArrayItem("ip-address")]
        public string[] accessList { get; set; }

        [XmlElement("role")]
        public string role { get; set; }
    }
}