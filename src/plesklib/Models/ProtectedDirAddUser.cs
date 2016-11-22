namespace plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class ProtectedDirAddUserPacket
    {
        public ProtectedDirAddUserPacket()
        {
            this.protectedDir = new ProtectedDirAddUserDir();
        }

        [XmlElement("protected-dir")]
        public ProtectedDirAddUserDir protectedDir { get; set; }
    }

    public class ProtectedDirAddUserDir
    {
        public ProtectedDirAddUserDir()
        {
            this.addUser = new ProtectedDirAddUser();
        }

        [XmlElement("add-user")]
        public ProtectedDirAddUser addUser { get; set; }
    }

    public class ProtectedDirAddUser
    {
        [XmlElement("pd-id")]
        public int Id { get; set; }

        [XmlElement("login")]
        public string username { get; set; }

        [XmlElement("password")]
        public string password { get; set; }

        [XmlElement("password-type")]
        public string passwordType { get; set; }
    }
}
