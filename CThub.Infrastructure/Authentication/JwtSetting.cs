namespace CThub.Infrastructure.Authentication;

public class JwtSetting
{
    public string Secret { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    // public int ExpiryInMinutes { get; set; }
    public const string SectionName = "JwtSettings";
}