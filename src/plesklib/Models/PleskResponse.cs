namespace plesklib.Models
{
    public class PleskResponse
    {
        public string Status { get; set; }
        public int Errcode { get; set; }
        public string Errtext { get; set; }
        public string ResponseContent { get; set; }
    }
}
