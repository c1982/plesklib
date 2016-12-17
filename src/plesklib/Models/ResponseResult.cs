namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    public class ResponseResult
    {
        [XmlElement("status")]
        public string status { get; set; }

        [XmlElement("errcode")]
        public int ErrorCode { get; set; }

        [XmlElement("errtext")]
        public string ErrorText { get; set; }

        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("guid")]
        public string guid { get; set; }

        [XmlIgnore]
        private ApiResponse _response;

        [XmlIgnore]
        public ApiResponse response
        {
            get
            {
                return this._response;
            }
            set
            {
                this._response = value;

                if (value.error != null)
                {
                    this.status = value.error.system.status;
                    this.ErrorCode = value.error.system.errorcode;
                    this.ErrorText = value.error.system.errtext;
                }
            }
        }


        public ResponseResult()
        {
            this._response = new ApiResponse();
        }


    }
}
