namespace KK.LMS.Source.Shared.Auth;

public class OidcSettings
{
    [JsonPropertyName("Url")]
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("Realm")]
    public string Realm { get; set; } = string.Empty;

    [JsonPropertyName("ClientId")]
    public string ClientId { get; set; } = string.Empty;

    public string Authority => $"{Url}/realms/{Realm}";
}