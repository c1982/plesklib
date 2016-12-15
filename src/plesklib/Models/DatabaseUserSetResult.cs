namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class DatabaseUserSetResult : IResponseResult
    {
        public DatabaseUserSetResult()
        {
            this.database = new DatabaseUserSetResultDatabaseNode();
        }

        public void SaveResult(ApiResponse response)
        {
            this.database.setDbUser.result = response.ToErrorResult();
        }

        [XmlElement("database")]
        public DatabaseUserSetResultDatabaseNode database { get; set; }
    }

    public class DatabaseUserSetResultDatabaseNode
    {
        public DatabaseUserSetResultDatabaseNode()
        {
            this.setDbUser = new DatabaseUserSetResultSetDbUserNode();
        }

        [XmlElement("set-db-user")]
        public DatabaseUserSetResultSetDbUserNode setDbUser { get; set; }
    }

    public class DatabaseUserSetResultSetDbUserNode
    {
        public DatabaseUserSetResultSetDbUserNode()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")]
        public ResponseResult result { get; set; }
    }
}