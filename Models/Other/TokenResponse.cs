namespace APMApi.Models.Other
{
    public class TokenResponse
    {
        public string Token { get; set; } = null!;
        public DateTime Expires { get; set; }
    }
}