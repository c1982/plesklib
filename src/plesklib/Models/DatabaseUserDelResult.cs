namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class DatabaseUserDelResult : IResponseResult
    {
        public DatabaseUserDelResult()
        {
            this.database = new DatabaseUserDelResultDatabaseNode();
        }

        [XmlElement("database")]
        public DatabaseUserDelResultDatabaseNode database { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this.database.del.result = response.ToErrorResult();
        }
    }

    public class DatabaseUserDelResultDatabaseNode
    {
        public DatabaseUserDelResultDatabaseNode()
        {
            this.del = new DatabaseUserDelResultDelNode();
        }

        [XmlElement("del-db-user")]
        public DatabaseUserDelResultDelNode del { get; set; }
    }

    public class DatabaseUserDelResultDelNode
    {

        public DatabaseUserDelResultDelNode()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")]
        public ResponseResult result { get; set; }
    }
}
