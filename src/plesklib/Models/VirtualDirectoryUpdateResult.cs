namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class VirtualDirectoryUpdateResult : IResponseResult
    {
        private ApiResponse _response;

        public VirtualDirectoryUpdateResult()
        {
            this.virtdir = new VirtualDirectoryUpdateResultVirDirNode();
            this._response = new ApiResponse();
            
        }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;
        }

        public ResponseResult ToResult()
        {
            this.virtdir.update.result.apiResponse = this._response;

            return this.virtdir.update.result;
        }

        [XmlElement("virtdir")]
        public VirtualDirectoryUpdateResultVirDirNode virtdir { get; set; }
    }

    public class VirtualDirectoryUpdateResultVirDirNode
    {

        public VirtualDirectoryUpdateResultVirDirNode()
        {
            this.update = new VirtualDirectoryUpdateResultUpdateNode();
        }

        [XmlElement("update")]
        public VirtualDirectoryUpdateResultUpdateNode update { get; set; }
    }

    public class VirtualDirectoryUpdateResultUpdateNode
    {
        public VirtualDirectoryUpdateResultUpdateNode()
        {
            this.result = new ResponseResult();
        }

        [XmlElement("result")]
        public ResponseResult result { get; set; }
    }
}
