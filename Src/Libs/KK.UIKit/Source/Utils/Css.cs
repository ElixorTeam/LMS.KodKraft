namespace KK.UIKit.Source.Utils;

public static class Css
{
    [Pure]
    public static string Class(params string?[] classes) => Build(classes);

    [Pure]
    public static string WithPrefix(string prefix, string? classes)
    {
        if (string.IsNullOrWhiteSpace(classes))
            return string.Empty;

        return Build(
            classes
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => $"{prefix}{c}")
            );
    }

    [Pure]
    private static string Build(IEnumerable<string?> items) =>
        string.Join(" ", items).Trim();
}