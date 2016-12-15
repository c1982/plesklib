namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class DatabaseUserAddResult : IResponseResult
    {
        public DatabaseUserAddResult()
        {
            this.database = new DatabaseUserAddResultDatabaseNode();
        }

        [XmlElement("database")]
        public DatabaseUserAddResultDatabaseNode database { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this.database.addDbUser.result = response.ToErrorResult();
        }
    }

    public class DatabaseUserAddResultDatabaseNode
    {
        public DatabaseUserAddResultDatabaseNode()
        {
            this.addDbUser = new DatabaseUserAddResultAddDbUserNode();
        }

        [XmlElement("add-db-user")]
        public DatabaseUserAddResultAddDbUserNode addDbUser { get; set; }
    }

    public class DatabaseUserAddResultAddDbUserNode
    {
        public DatabaseUserAddResultAddDbUserNode()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("add-db-user")]
        public ResponseResult result { get; set; }
    }
}
