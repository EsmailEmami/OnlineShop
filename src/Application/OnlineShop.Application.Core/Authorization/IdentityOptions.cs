using Microsoft.IdentityModel.Tokens;

namespace OnlineShop.Application.Core.Authorization
{
    public class IdentityOptions
    {
        public string DefaultScheme { get; set; }
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string? Audience { get; set; } = null;
        public TimeSpan ExpiresAt { get; set; } = TimeSpan.FromDays(30);
        public bool ValidateIssuer { get; set; } = true;
        public bool ValidateAudience { get; set; } = false;
        public bool ValidateLifeTime { get; set; } = true;
        public bool ValidateIssuerSigningKey { get; set; } = true;
        public IEnumerable<string>? ValidEventPaths { get; set; } = null;
    }
}