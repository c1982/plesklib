namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class DatabaseAddResult : IResponseResult
    {
        public DatabaseAddResult()
        {
            this.database = new DatabaseAddResultDatabaseNode();
        }

        [XmlElement("database")]
        public DatabaseAddResultDatabaseNode database { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this.database.add.result = response.ToErrorResult();
        }

        public ResponseResult ToResult()
        {
            return this.database.add.result;
        }
    }

    public class DatabaseAddResultDatabaseNode
    {
        public DatabaseAddResultDatabaseNode()
        {
            this.add = new DatabaseAddResultAddDbNode();
        }

        [XmlElement("add-db")]
        public DatabaseAddResultAddDbNode add { get; set; }
    }

    public class DatabaseAddResultAddDbNode
    {
        public DatabaseAddResultAddDbNode()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")]
        public ResponseResult result { get; set; }
    }
}
