namespace CQRSAndMediatRDemo.Models
{
    public class ExceptionLog
    {
        public int Id { get; set; }
        public string RequestType { get; set; }
        public string RequestData { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
