namespace Academy.Core.ApiSettings;

public class JwtSettings
{
    public string Secret { get; set; }

    public TimeSpan TokenLifetime { get; set; }
    
    public static string SectionName => "JwtSettings";
}