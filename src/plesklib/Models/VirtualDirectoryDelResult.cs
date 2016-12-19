namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class VirtualDirectoryDelResult : IResponseResult
    {

        public VirtualDirectoryDelResult()
        {
            this.virtdir = new VirtualDirectoryDelVirtDirNode();
        }

        public void SaveResult(ApiResponse response)
        {
            this.virtdir.remove.result.apiResponse = response;
        }

        public ResponseResult ToResult()
        {
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
