namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class DatabaseDelResult : IResponseResult
    {
        private ApiResponse _response;

        public DatabaseDelResult()
        {
            this._response = new ApiResponse();
            this.database = new DatabaseDelResultDatabaseNode();
        }

        [XmlElement("database")]
        public DatabaseDelResultDatabaseNode database { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;
        }

        public ResponseResult ToResult()
        {
            this.database.delDb.result.apiResponse = _response;
            return this.database.delDb.result;
        }
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
