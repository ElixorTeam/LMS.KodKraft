namespace LMS.Client.Source.Shared.Configs.Models;

public class OidcSettings
{
    [JsonPropertyName("Url")]
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("Realm")]
    public string Realm { get; set; } = string.Empty;

    [JsonPropertyName("ClientId")]
    public string ClientId { get; set; } = string.Empty;

    [JsonPropertyName("ClientSecret")]
    public string ClientSecret { get; set; } = string.Empty;

    public string Authority => $"{Url}/realms/{Realm}";
}