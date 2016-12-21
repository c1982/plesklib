namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class ProtectedDirAddUserResult : IResponseResult
    {
        private ApiResponse _response;
        public ProtectedDirAddUserResult()
        {
            this._response = new ApiResponse();
            this.protectedDir = new ProtectedDirProtectResult();
        }

        [XmlElement("protected-dir")]
        public ProtectedDirProtectResult protectedDir { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;
        }

        public ResponseResult ToResult()
        {
            this.protectedDir.addUser.result.apiResponse = _response;
            return this.protectedDir.addUser.result;
        }
    }

    public class ProtectedDirProtectResult
    {
        public ProtectedDirProtectResult()
        {
            this.addUser = new ProtectedDirAddUserSubResult();
        }

        [XmlElement("add-user")]
        public ProtectedDirAddUserSubResult addUser { get; set; }
    }

    public class ProtectedDirAddUserSubResult
    {
        public ProtectedDirAddUserSubResult()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")]
        public ResponseResult result { get; set; }
    }
}
