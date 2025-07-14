namespace CQRSAndMediatRDemo.Models
{
    public class RequestLog
    {
        public int Id { get; set; }
        public string RequestType { get; set; }
        public string RequestData { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
