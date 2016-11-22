namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class ProtectedDirAddUserResult
    {
        public ProtectedDirAddUserResult()
        {
            this.protectedDir = new ProtectedDirProtectResult();
        }

        [XmlElement("protected-dir")]
        public ProtectedDirProtectResult protectedDir { get; set; }
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
