namespace maestropanel.plesklib.Models
{
    public class CustomerAddResult  :IResponseResult
    {
        private ApiResponse _response;

        public CustomerAddResult()
        {
            this._response = new ApiResponse();
            this.customer = new CustomerAddResultCustomerNode();
        }

        public void SaveResult(ApiResponse response)
        {
            this._response = response;
        }

        public ResponseResult ToResult()
        {
            this.customer.add.result.apiResponse = this._response;
            return this.customer.add.result;
        }

        public CustomerAddResultCustomerNode customer { get; set; }
    }

    public class CustomerAddResultCustomerNode
    {
        public CustomerAddResultCustomerNode()
        {
            this.add = new CustomerAddResultAddNode();
        }

        public CustomerAddResultAddNode add { get; set; }
    }

    public class CustomerAddResultAddNode
    {
        public CustomerAddResultAddNode()
        {
            this.result = new ResponseResult();
        }

        public ResponseResult result { get; set; }

    }


}
