namespace maestropanel.plesklib.Models
{
    using System.Xml.Serialization;

    [XmlRoot("packet")]
    public class CustomerAddPacket
    {
        public CustomerAddPacket()
        {
            this.customer = new CustomerAddCustomerNode();
        }

        [XmlElement("customer")]
        public CustomerAddCustomerNode customer { get; set; }
    }

    public class CustomerAddCustomerNode
    {
        public CustomerAddCustomerNode()
        {
            this.add = new CustomerAddAddNode();
        }

        [XmlElement("add")]
        public CustomerAddAddNode add { get; set; }        
    }

    public class CustomerAddAddNode
    {

        public CustomerAddAddNode()
        {
            this.info = new CustomerAddGenInfoNode();
        }

        [XmlElement("gen_info")]
        public CustomerAddGenInfoNode info { get; set; }
    }

    public class CustomerAddGenInfoNode
    {

        [XmlElement("cname")]
        public string CompanyName { get; set; }

        [XmlElement("pname")]
        public string PersonalName { get; set; }

        [XmlElement("login")]
        public string LoginName { get; set; }

        [XmlElement("passwd")]
        public string Password { get; set; }

        [XmlElement("status")]
        public string status { get; set; }

        [XmlElement("phone")]
        public string Phone { get; set; }

        [XmlElement("fax")]
        public string Fax { get; set; }

        [XmlElement("email")]
        public string Email { get; set; }

        [XmlElement("address")]
        public string Address { get; set; }

        [XmlElement("city")]
        public string City { get; set; }

        [XmlElement("state")]
        public string State { get; set; }

        [XmlElement("pcode")]
        public string PostalCoe { get; set; }

        [XmlElement("country")]
        public string Country { get; set; }
    }


}
