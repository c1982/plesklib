namespace plesklib
{
    using plesklib.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class PleskClient
    {
        private string apiurl;
        private string hostname;
        private string port;
        private string username;
        private string password;

        public PleskClient()
        {

        }

        public PleskClient(string hostname, string username, string password, string port = "8443")
        {
            this.hostname = hostname;
            this.username = username;
            this.password = password;
            this.port = port;
            
            this.apiurl = String.Format("https://{0}:{1}/enterprise/control/agent.php", hostname, port);
        }

        private void Auth(ref HttpWebRequest req)
        {
            req.Method = "POST";
            req.Headers.Add("HTTP_AUTH_LOGIN", username);
            req.Headers.Add("HTTP_AUTH_PASSWD", password);
            req.ContentType = "text/xml";
        }

        public string SerializeObjectToXmlString<T>(T TModel)
        {
            string xmlData = String.Empty;

            var encoding = new UTF8Encoding(false);    

            XmlSerializerNamespaces EmptyNameSpace = new XmlSerializerNamespaces();
            EmptyNameSpace.Add("", "");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            
            MemoryStream memoryStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, encoding);
            xmlWriter.Formatting = Formatting.Indented;

            xmlSerializer.Serialize(xmlWriter, TModel, EmptyNameSpace);

            memoryStream = (MemoryStream)xmlWriter.BaseStream;
            xmlData = encoding.GetString(memoryStream.ToArray());

            return xmlData;
        }

        public T DeSerializeObject<T>(string xmlString)
        {
            T deSerializeObject = default(T);

            var xmlSerializer = new XmlSerializer(typeof(T));

            using (var stringReader = new StringReader(xmlString))
            {
                var XR = new XmlTextReader(stringReader);
                
                if (xmlSerializer.CanDeserialize(XR))
                {
                    deSerializeObject = (T)xmlSerializer.Deserialize(XR);
                }
            }
        
            return deSerializeObject;
        }

        private string ExecuteWebRequest(string xmlRequest)
        {
            //Send
            //Get Response
            
            return String.Empty;
        }

        #region Actions
        public PacketAddResult SiteAdd(string webspaceid, string name, string username, string password, HostingProperty[] properties)
        {
            var prop = new List<HostingProperty>();
            prop.AddRange(properties);

            var result = new PacketAddResult();
            
            var add = new PacketAdd();
            add.Site.Add.GenSetup.Name = name;
            add.Site.Add.GenSetup.WebSpaceId = webspaceid;
            add.Site.Add.Hosting.Properties = prop.ToArray();

            return result;
        }
        #endregion


    }
}
