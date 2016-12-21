namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class DatabaseAddResult : IResponseResult
    {
        private ApiResponse _response;

        public DatabaseAddResult()
        {
            this._response = new ApiResponse();
            this.database = new DatabaseAddResultDatabaseNode();
        }

        [XmlElement("database")]
        public DatabaseAddResultDatabaseNode database { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;
        }

        public ResponseResult ToResult()
        {
            this.database.add.result.apiResponse = this._response;
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
