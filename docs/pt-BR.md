# Tiny11 Builder em português do Brasil

Esta edição do fork traduz o assistente nativo **WinUI 3** para português do Brasil.
Mantém Mica, temas claro/escuro, alto contraste e navegação por teclado.

## Executar

1. Extraia **todo** o ZIP para uma pasta.
2. Abra `Tiny11Builder.exe` e autorize a solicitação de administrador.
3. Escolha Tiny11, Tiny11 Core ou Personalizado e selecione uma ISO do Windows.
4. Confira a edição, os componentes, a área de trabalho e o arquivo de saída.
5. Crie a imagem e teste a ISO em uma máquina virtual antes de instalar.

O pacote x64 é destinado a PCs Intel/AMD. O aplicativo inclui suas dependências;
não é necessário instalar o SDK .NET para executá-lo.

**Tiny11 Core remove o suporte a atualizações e recuperação e desativa o Defender.**
As remoções avançadas podem impedir a inicialização. As confirmações de risco
e os pontos seguros de cancelamento foram preservados.

## Tradução

O idioma desta edição é fixado em `pt-BR`. A tradução abrange a navegação, as
opções e descrições do catálogo, a revisão, os avisos do aplicativo, os estados
de progresso e os diálogos de cancelamento e recuperação. Números seguem o
formato brasileiro. Os textos dinâmicos usam o catálogo incorporado
`src/Tiny11Builder.Core/Localization/pt-BR.json`.

Identificadores de pacotes, serviços, arquivos, receitas JSON e chaves internas
de etapas permanecem invariáveis. A edição e o idioma da imagem do Windows
dependem da mídia selecionada. A tradução da interface não traduz o Windows
contido em uma ISO existente.

Saídas técnicas do DISM, exceções do sistema, detalhes de inventário fornecidos
pelo Windows e logs de diagnóstico podem permanecer no idioma original. A
documentação original em inglês acompanha o projeto.

## Desenvolvimento e validação

Use o SDK .NET 8 compatível com `global.json` em um computador Windows:

```powershell
dotnet test tests/Tiny11Builder.Core.Tests/Tiny11Builder.Core.Tests.csproj
dotnet build src/Tiny11Builder.App/Tiny11Builder.App.csproj -c Release -p:Platform=x64
```

Os testes de localização verificam argumentos de formatação, números, caminhos,
identidades técnicas, progresso e cancelamento em português, além da alternativa
em inglês. Os testes existentes fixam o idioma inglês para manter suas asserções
reproduzíveis independentemente do idioma do computador.

Na validação local desta edição: 381 testes aprovados e 26 falhas já presentes
na versão original, incluindo requisitos de privilégios administrativos e de
ferramentas DISM compatíveis. A compilação x64 passou sem erros ou avisos.

A criação e a inicialização de uma ISO real não foram validadas nesta alteração.
