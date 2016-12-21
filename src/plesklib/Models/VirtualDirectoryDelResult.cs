namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class VirtualDirectoryDelResult : IResponseResult
    {
        private ApiResponse _response;

        public VirtualDirectoryDelResult()
        {
            this._response = new ApiResponse();
            this.virtdir = new VirtualDirectoryDelVirtDirNode();
        }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;
        }

        public ResponseResult ToResult()
        {
            this.virtdir.remove.result.apiResponse = _response;
            return this.virtdir.remove.result;
        }

        [XmlElement("virtdir")]
        public VirtualDirectoryDelVirtDirNode virtdir { get; set; }
    }

    public class VirtualDirectoryDelVirtDirNode
    {
        public VirtualDirectoryDelVirtDirNode()
        {
            this.remove = new VirtualDirectoryDelResultRemoveNode();
        }

        [XmlElement("remove")]
        public VirtualDirectoryDelResultRemoveNode remove { get; set; }
    }

    public class VirtualDirectoryDelResultRemoveNode
    {
        public VirtualDirectoryDelResultRemoveNode()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")]
        public ResponseResult result { get; set; }
    }
}
