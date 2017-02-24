namespace maestropanel.plesklib.Models
{
    using System;
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
        public ApiResponse apiResponse
        {
            get
            {
                return this._response;
            }
            set
            {                
                if (value == null)
                    return;

                this._response = value;

                if (!String.IsNullOrEmpty(value.error.system.status))
                {
                    this.status = value.error.system.status;
                    this.ErrorCode = value.error.system.errorcode;
                    this.ErrorText = value.error.system.errtext;

                    return;
                }

                if (!value.Status)
                {
                    this.status = value.Status ? "ok" : "error";
                    this.ErrorCode = 999;
                    this.ErrorText = value.Message;
                }
            }
        }


        public ResponseResult()
        {
            this._response = new ApiResponse();
        }


    }
}
