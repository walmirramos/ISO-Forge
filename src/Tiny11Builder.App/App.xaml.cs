using Microsoft.UI.Xaml;
using System.Globalization;

namespace Tiny11Builder.App;

public partial class App : Application
{
    private Window? window;
    public App()
    {
        var portuguese = CultureInfo.GetCultureInfo("pt-BR");
        CultureInfo.DefaultThreadCurrentCulture = portuguese;
        CultureInfo.DefaultThreadCurrentUICulture = portuguese;
        CultureInfo.CurrentCulture = portuguese;
        CultureInfo.CurrentUICulture = portuguese;
        Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = "pt-BR";
        InitializeComponent();
    }
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        window = new MainWindow();
        window.Activate();
    }
}
