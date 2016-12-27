namespace maestropanel.plesklib.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class ServicePlanGetResult :IResponseResult
    {
        private ApiResponse _response;

        public ServicePlanGetResult()
        {
            this._response = new ApiResponse();
            this.servicePlan = new ServicePlanGetResultServicePlanNode();
        }

        [XmlElement("service-plan")]
        public ServicePlanGetResultServicePlanNode servicePlan { get; set; }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;   
        }

        public ResponseResult ToResult()
        {
            return _response.ToErrorResult();
        }
    }

    public class ServicePlanGetResultServicePlanNode
    {
        public ServicePlanGetResultServicePlanNode()
        {
            this.results = new List<ServicePlanItem>().ToArray();
        }

        [XmlArray("get")]
        [XmlArrayItem("result")]
        public ServicePlanItem[] results { get; set; }        
    }

    public class ServicePlanItem
    {
        [XmlElement("status")]
        public string status { get; set; }

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string name { get; set; }

        [XmlElement("guid")]
        public string guid { get; set; }

        [XmlElement("owner-login")]
        public string owner { get; set; }
    }
 
}
