namespace TestApiApp.Options
{
    public class BearerTokenOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string IssuerSigningKey { get; set; }

        public double Expiration { get; set; } = TimeSpan.FromHours(12d).TotalHours;
    }
}
