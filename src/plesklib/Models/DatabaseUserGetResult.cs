namespace maestropanel.plesklib.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class DatabaseUserGetResult
    {
        public DatabaseUserGetResult()
        {
            this.database = new DatabaseUserGetResultDatabaseNode();
        }

        [XmlElement("database")]
        public DatabaseUserGetResultDatabaseNode database { get; set; }
    }

    public class DatabaseUserGetResultDatabaseNode
    {
        public DatabaseUserGetResultDatabaseNode()
        {
            this.users = new List<DatabaseUserGetResultResultNode>().ToArray();
        }

        [XmlArray("get-db-users")]
        [XmlArrayItem("result")]
        public DatabaseUserGetResultResultNode[] users { get; set; }
    }

    public class DatabaseUserGetResultResultNode
    {
        [XmlElement("status")]
        public string status { get; set; }

        [XmlElement("filter-id")]
        public int filterId { get; set; }

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("db-id")]
        public int databaseId { get; set; }

        [XmlElement("login")]
        public string login { get; set; }
    }
}
