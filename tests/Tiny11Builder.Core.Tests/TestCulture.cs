using System.Globalization;
using System.Runtime.CompilerServices;

namespace Tiny11Builder.Core.Tests;

internal static class TestCulture
{
    // Existing diagnostics assertions use English. Keep them reproducible on localized Windows hosts;
    // localization tests select their own culture and restore it afterward.
    [ModuleInitializer]
    internal static void Initialize()
    {
        var english = CultureInfo.GetCultureInfo("en-US");
        CultureInfo.DefaultThreadCurrentCulture = english;
        CultureInfo.DefaultThreadCurrentUICulture = english;
        CultureInfo.CurrentCulture = english;
        CultureInfo.CurrentUICulture = english;
    }
}
