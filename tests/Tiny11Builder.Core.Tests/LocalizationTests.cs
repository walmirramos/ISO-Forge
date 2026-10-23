using System.Globalization;
using System.Text;
using System.Text.Json;
using Tiny11Builder.App;
using Tiny11Builder.Core;
using Xunit;

namespace Tiny11Builder.Core.Tests;

public sealed class LocalizationTests
{
    private sealed class CultureScope : IDisposable
    {
        private readonly CultureInfo culture = CultureInfo.CurrentCulture;
        private readonly CultureInfo uiCulture = CultureInfo.CurrentUICulture;
        public CultureScope(string name)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(name);
            CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo(name);
        }
        public void Dispose()
        {
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = uiCulture;
        }
    }

    [Fact]
    public void Portuguese_resources_preserve_all_format_arguments()
    {
        using var stream = typeof(UiText).Assembly.GetManifestResourceStream("Tiny11Builder.Core.Localization.pt-BR.json");
        Assert.NotNull(stream);
        var entries = JsonSerializer.Deserialize<Dictionary<string, string>>(stream)!;
        Assert.True(entries.Count > 400);
        foreach (var (source, translated) in entries)
        {
            Assert.False(string.IsNullOrWhiteSpace(translated));
            Assert.Equal(CompositeFormat.Parse(source).MinimumArgumentCount,
                CompositeFormat.Parse(translated).MinimumArgumentCount);
        }
    }

    [Fact]
    public void Formatting_uses_Brazilian_numbers_and_preserves_paths()
    {
        using var scope = new CultureScope("pt-BR");
        Assert.Equal("Etapa 2 de 7", UiText.Format($"Stage {2} of {7}"));
        Assert.Equal("Criação padrão · 1,5 minutos", UiText.Format($"{UiText.Get("Standard build")} · {1.5:N1} minutes{""}{""}"));
        Assert.Equal(@"Saída: C:\ISO\Windows 11.iso", UiText.Format($"Output: {@"C:\ISO\Windows 11.iso"}"));
        Assert.Equal("REMOÇÕES CORE Sim", UiText.Format($"CORE REMOVALS {true}"));
        Assert.Equal("COMPACTAÇÃO WIM rápido", UiText.Format($"COMPRESSION {Compression.Fast}"));
    }

    [Fact]
    public void Portuguese_choices_keep_invariant_component_identities()
    {
        using var scope = new CultureScope("pt-BR");
        var option = new OptionChoice(CleanupCatalog.Options.First(o => o.Id == "copilot-app"));
        Assert.Equal("Aplicativos Copilot", option.Title);
        Assert.Equal("Aplicativos pré-instalados", option.Category);
        Assert.Equal("copilot-app", option.Option.Id);
        Assert.Equal("Microsoft.Copilot", option.Option.Targets[0]);
        Assert.Equal("Remover recurso opcional: Printing-XPSServices-Features",
            UiText.Display("Remove optional feature: Printing-XPSServices-Features"));
        Assert.Equal("Remover Microsoft.XboxApp (Microsoft.XboxApp_1.0_x64)",
            UiText.Display("Remove Microsoft.XboxApp (Microsoft.XboxApp_1.0_x64)"));
        Assert.Equal("Unknown technical diagnostic 740", UiText.Display("Unknown technical diagnostic 740"));
    }

    [Fact]
    public void Portuguese_stage_counts_and_cancellation_still_follow_the_run_state()
    {
        using var scope = new CultureScope("pt-BR");
        var board = new BuildStageBoard();
        Assert.Equal("0 de 7 etapas concluídas", StageSummary.Describe(board));
        board.Complete();
        Assert.Equal("Todas as 7 etapas concluídas", StageSummary.Describe(board));
        var run = new OperationRun(OperationKind.Build);
        var flow = CancellationFlow.TryBegin(run)!;
        Assert.Equal("Cancelar esta criação?", flow.View.Title);
        Assert.Equal("Cancelar com segurança", CancelPrompts.ButtonLabel);
        Assert.True(flow.Confirm());
        run.Record(OperationEnd.From(OperationOutcomes.Classify(OperationKind.Build, new OperationCanceledException(), true)));
        run.Settle();
        flow.RunSettled();
        Assert.Equal(CancelStage.Ended, flow.View.Stage);
        Assert.Contains("cancelada", flow.View.Title);
        Assert.Contains("progresso salvo", flow.View.Body);
        flow.Close();
    }

    [Fact]
    public void English_fallback_and_engine_stage_keys_remain_invariant()
    {
        using var scope = new CultureScope("en-US");
        Assert.Equal("Cancel safely", CancelPrompts.ButtonLabel);
        Assert.Equal("Stage 2 of 7", UiText.Format($"Stage {2} of {7}"));
        Assert.Equal("Remove optional feature: Example", UiText.Display("Remove optional feature: Example"));
        Assert.Equal(2, BuildProgressText.Phase("Optional features"));
        Assert.Equal(-1, BuildProgressText.Phase("Recursos opcionais"));
    }
}
