namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class ServicePlanGetPacket
    {
        public ServicePlanGetPacket()
        {
            this.servicePlan = new ServicePlanGetServicePlanNode();
        }

        [XmlElement("service-plan")]  
        public ServicePlanGetServicePlanNode servicePlan { get; set; }
    }


    public class ServicePlanGetServicePlanNode
    {
        public ServicePlanGetServicePlanNode()
        {
            this.receive = new ServicePlanGetGetNode();
        }

        [XmlElement("get")]  
        public ServicePlanGetGetNode receive { get; set; }

    }

    public class ServicePlanGetGetNode
    {
        public ServicePlanGetGetNode()
        {
            this.filter = new ServicePlanGetFilterNode();
        }

        [XmlElement("filter")]  
        public ServicePlanGetFilterNode filter { get; set; }
    }

    public class ServicePlanGetFilterNode
    {
    }
}
