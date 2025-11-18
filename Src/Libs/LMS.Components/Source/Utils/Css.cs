namespace LMS.Components.Source.Utils;

public static class Css
{
    [Pure]
    public static string Class(params string?[] classes) => Build(classes);

    [Pure]
    public static string Class(params (string?, bool)[] classes) =>
        Build(classes.Where(x => x.Item2).Select(x => x.Item1));

    [Pure]
    public static string Class(string? always, params (string?, bool)[] classes) =>
        Build(classes.Where(x => x.Item2).Select(x => x.Item1).Prepend(always));

    private static string Build(IEnumerable<string?> items) =>
        string.Join(" ", items).Trim();
}