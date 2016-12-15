namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class DatabaseDelResult
    {
        public DatabaseDelResult()
        {
            this.database = new DatabaseDelResultDatabaseNode();
        }

        [XmlElement("database")]
        public DatabaseDelResultDatabaseNode database { get; set; }
    }

    public class DatabaseDelResultDatabaseNode
    {
        public DatabaseDelResultDatabaseNode()
        {
            this.delDb = new DatabaseDelResultDelDbNode();
        }

        [XmlElement("del-db")]
        public DatabaseDelResultDelDbNode delDb { get; set; }
    }

    public class DatabaseDelResultDelDbNode
    {
        public DatabaseDelResultDelDbNode()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")]
        public ResponseResult result { get; set; }
    }
}
