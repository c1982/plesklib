namespace maestropanel.plesklib.Models
{
    public class ApiResponse
    {
        public bool Status { get; set; }        
        public string Message { get; set; }
        public string MessageDetails { get; set; }
        public string ResponseXmlString { get; set; }

        public ResponseResult ToErrorResult()
        {
            return new ResponseResult() { status = this.Status ? "ok" : "error", 
                                            ErrorCode = 999, 
                                            ErrorText = this.Message};
        }
    }
}
