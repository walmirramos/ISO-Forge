# Compilar e testar

Use Windows, Git e SDK .NET 8 compatível com `global.json`. Os pacotes WinUI são restaurados pelo NuGet.

```powershell
git clone https://github.com/walmirramos/ISO-Forge.git
cd ISO-Forge
dotnet test tests/Tiny11Builder.Core.Tests/Tiny11Builder.Core.Tests.csproj
dotnet build src/Tiny11Builder.App/Tiny11Builder.App.csproj -c Release -p:Platform=x64
./scripts/package.ps1 -Architecture x64
```

Os nomes internos de projetos e namespaces são preservados. O produto compilado chama-se `ISOForge.exe`. O empacotamento gera um ZIP com dependências, verifica o manifesto de administrador e inclui avisos de terceiros. Não gera instalador.

Os testes nativos podem exigir privilégios e ferramentas DISM compatíveis. A versão x64 foi preparada nesta edição; ARM64 exige compilação e validação próprias.

Textos dinâmicos ficam em `src/Tiny11Builder.Core/Localization/pt-BR.json`. Textos estáticos ficam no XAML. Preserve os argumentos de formatação, identificadores de componentes e formatos de receitas.
