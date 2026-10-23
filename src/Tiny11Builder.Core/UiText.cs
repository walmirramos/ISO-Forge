using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Tiny11Builder.Core;

/// <summary>Presentation text only. Machine identities, recipes and engine stage keys stay invariant.</summary>
public static class UiText
{
    private static bool IsPortuguese => CultureInfo.CurrentUICulture.Name.Equals("pt-BR", StringComparison.OrdinalIgnoreCase);
    private static readonly Lazy<IReadOnlyDictionary<string, string>> Portuguese = new(() =>
    {
        using var stream = typeof(UiText).Assembly.GetManifestResourceStream("Tiny11Builder.Core.Localization.pt-BR.json")
            ?? throw new InvalidOperationException("Missing pt-BR localization resource.");
        return JsonSerializer.Deserialize<Dictionary<string, string>>(stream)
            ?? throw new InvalidOperationException("Empty pt-BR localization resource.");
    });

    public static string Get(string source) =>
        IsPortuguese &&
        Portuguese.Value.TryGetValue(source, out var translated) ? translated : source;

    public static string Format(FormattableString source)
    {
        var arguments = source.GetArguments();
        if (IsPortuguese)
            arguments = arguments.Select(value => value switch
            {
                bool flag => (object)Get(flag ? "Yes" : "No"),
                Enum choice => Get(choice.ToString()),
                _ => value
            }).ToArray();
        return string.Format(CultureInfo.CurrentCulture, Get(source.Format), arguments);
    }

    // Engine messages keep their invariant keys and identities. Translate only at the display boundary.
    private static readonly Lazy<(Regex Pattern, string Translation)[]> OperationPatterns = new(() =>
        Portuguese.Value.Where(pair => pair.Key.Contains("{0}", StringComparison.Ordinal) &&
            (pair.Key.StartsWith("Remove ", StringComparison.Ordinal) ||
             pair.Key.StartsWith("Disable ", StringComparison.Ordinal) || pair.Key.StartsWith("Clean ", StringComparison.Ordinal)))
        .Select(pair => (new Regex("\\A" + Regex.Escape(pair.Key)
            .Replace("\\{0}", "(.+?)", StringComparison.Ordinal)
            .Replace("\\{1}", "(.+?)", StringComparison.Ordinal) + "\\z",
            RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(100)), pair.Value)).ToArray());

    public static string Display(string source)
    {
        if (!IsPortuguese) return source;
        if (Portuguese.Value.TryGetValue(source, out var translated)) return translated;
        foreach (var (pattern, translation) in OperationPatterns.Value)
        {
            var match = pattern.Match(source);
            if (match.Success)
                return string.Format(CultureInfo.CurrentCulture, translation,
                    match.Groups.Cast<Group>().Skip(1).Select(group => (object)group.Value).ToArray());
        }
        return source;
    }
}
