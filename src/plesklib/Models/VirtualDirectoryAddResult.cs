namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class VirtualDirectoryAddResult  : IResponseResult
    {
        private ApiResponse _response;
        public VirtualDirectoryAddResult()
        {
            this._response = new ApiResponse();
        }

        [XmlElement("virtdir")]
        public VirtualDirectoryAddResultVirtDirNode virtdir { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this.virtdir.create.result = response.ToErrorResult();
        }

        public ResponseResult ToResult()
        {            
            return this.virtdir.create.result;
        }
    }

    public class VirtualDirectoryAddResultVirtDirNode
    {
        public VirtualDirectoryAddResultVirtDirNode()
        {
            this.create = new VirtualDirectoryAddResultCreateNode();
        }

        [XmlElement("create")]
        public VirtualDirectoryAddResultCreateNode create { get; set; }
    }

    public class VirtualDirectoryAddResultCreateNode
    {
        public VirtualDirectoryAddResultCreateNode()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")] 
        public ResponseResult result { get; set; }
    }
}
