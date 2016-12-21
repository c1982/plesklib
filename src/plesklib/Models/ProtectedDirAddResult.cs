namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class ProtectedDirAddResult : IResponseResult
    {
        private ApiResponse _response;

        public ProtectedDirAddResult()
        {
            this._response = new ApiResponse();
            this.protectedDir = new ProtectedDirProtectedResult();
        }

        [XmlElement("protected-dir")]
        public ProtectedDirProtectedResult protectedDir { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;
        }

        public ResponseResult ToResult()
        {
            this.protectedDir.add.result.apiResponse = _response;
            return this.protectedDir.add.result;
        }
    }

    public class ProtectedDirProtectedResult
    {
        public ProtectedDirProtectedResult()
        {
            this.add = new ProtectedDirAddAddResult();
        }

        [XmlElement("add")]
        public ProtectedDirAddAddResult add { get; set; }
    }

    public class ProtectedDirAddAddResult
    {
        public ProtectedDirAddAddResult()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")]
        public ResponseResult result { get; set; }
    }
}
