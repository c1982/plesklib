namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class DatabaseUserAddResult : IResponseResult
    {
        private ApiResponse _response;

        public DatabaseUserAddResult()
        {
            this._response = new ApiResponse();
            this.database = new DatabaseUserAddResultDatabaseNode();
        }

        [XmlElement("database")]
        public DatabaseUserAddResultDatabaseNode database { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;
        }

        public ResponseResult ToResult()
        {
            this.database.addDbUser.result.apiResponse = _response;
            return this.database.addDbUser.result;
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
