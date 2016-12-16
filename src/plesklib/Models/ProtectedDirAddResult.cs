namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class ProtectedDirAddResult : IResponseResult
    {
        public ProtectedDirAddResult()
        {
            this.protectedDir = new ProtectedDirProtectedResult();
        }

        [XmlElement("protected-dir")]
        public ProtectedDirProtectedResult protectedDir { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this.protectedDir.add.result = response.ToErrorResult();
        }

        public ResponseResult ToResult()
        {
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
