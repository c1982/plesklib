namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class DatabaseUserDelResult : IResponseResult
    {
        private ApiResponse _response;

        public DatabaseUserDelResult()
        {
            this._response = new ApiResponse();
            this.database = new DatabaseUserDelResultDatabaseNode();
        }

        [XmlElement("database")]
        public DatabaseUserDelResultDatabaseNode database { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;
        }

        public ResponseResult ToResult()
        {
            this.database.del.result.apiResponse = _response;
            return this.database.del.result;
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
