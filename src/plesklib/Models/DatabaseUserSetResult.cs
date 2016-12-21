namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class DatabaseUserSetResult : IResponseResult
    {
        private ApiResponse _response;

        public DatabaseUserSetResult()
        {
            this._response = new ApiResponse();
            this.database = new DatabaseUserSetResultDatabaseNode();
        }

        [XmlElement("database")]
        public DatabaseUserSetResultDatabaseNode database { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;
        }
        
        public ResponseResult ToResult()
        {
            this.database.setDbUser.result.apiResponse = _response;
            return this.database.setDbUser.result;
        }
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