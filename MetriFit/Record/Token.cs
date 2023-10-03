using Azure.Core;
namespace MetriFit;
    public class Token
    {
        public string? AccessToken { get; set; }
        public DateTime AccessTokneExDate { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExDate { get; set; }
        public  string? role { get; set; }
    }

