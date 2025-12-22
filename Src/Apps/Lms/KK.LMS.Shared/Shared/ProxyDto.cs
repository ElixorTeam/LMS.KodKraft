namespace LMS.Client.Models.Shared;

public sealed record ProxyDto(
    [property: JsonPropertyName("id")] Guid Id,
    [property: JsonPropertyName("name")] string Name
);