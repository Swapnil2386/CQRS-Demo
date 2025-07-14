namespace CQRSAndMediatRDemo.Models
{
    public class JwtToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string UserEmail { get; set; }
    }
}
