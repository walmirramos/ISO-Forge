# Como usar o ISO Forge

[Página principal](../README.md) · [Perguntas frequentes](FAQ.md) · [Modos e componentes](FEATURES.md)

## Requisitos

- Computador Windows x64 (Intel/AMD) para o pacote portátil x64.
- Privilégios de administrador para montagem e manutenção de imagens.
- Imagem cliente do Windows 11 22H2 ou mais recente, em x64 ou ARM64.
- Área de trabalho em NTFS: normalmente de 40 a 70 GiB livres, podendo exigir mais conforme a imagem.
- DISM compatível com a mídia. Um Windows antigo pode precisar das ferramentas de implantação de um Windows ADK mais recente.

## Executar sem instalar

Baixe o ZIP em [Releases](https://github.com/walmirramos/ISO-Forge/releases/latest), extraia tudo e abra `ISOForge.exe`. O pacote contém as dependências de execução; o SDK .NET não é necessário para usar o programa. Não mova apenas o EXE.

## 1. Escolha um modo

**Equilibrado** usa remoções predefinidas, mantendo atualizações, Defender e recuperação. **Mínimo** reduz mais componentes e remove a manutenção e a recuperação: use apenas em testes isolados. **Personalizado** permite escolher os grupos e os componentes individuais, começando sem seleções.

## 2. Selecione a imagem

Escolha uma ISO local, uma pasta de instalação extraída ou solicite uma ISO oficial à Microsoft. A disponibilidade e os idiomas dependem do serviço. Analise a imagem e selecione a edição. A criação modifica uma cópia de trabalho.

Um SHA-256 publicado pode verificar o download. Sem um hash publicado, o hash calculado identifica o arquivo, mas não comprova sozinho a autenticidade.

## 3. Confira as remoções

Grupos marcados são removidos ou desativados. Remoções individuais se somam aos grupos: para manter um componente, desmarque tanto o grupo quanto sua entrada individual. Confira as descrições; Edge/WebView2, OneDrive e capacidades de idioma podem ser necessários a aplicativos.

A lista avançada inclui itens protegidos. Remover drivers de inicialização, serviços ou arquivos essenciais pode impedir a inicialização e comprometer a segurança. A remoção direta não resolve dependências.

## 4. Configure a criação

Escolha a área de trabalho NTFS, um novo arquivo ISO de saída e a compactação:

| Opção | Uso |
| --- | --- |
| ESD de recuperação | Arquivo menor, compactação mais lenta. |
| WIM máximo | Compactação forte e manutenção posterior mais simples. |
| WIM rápido | Criação mais rápida, ISO maior. |

O modo Turbo usa mais CPU e espaço temporário para acelerar algumas operações. Outras opções incluem instalação compacta, .NET Framework 3.5 de uma fonte compatível, preferência por conta local e limpeza de dados redundantes. Algumas versões podem ignorar políticas ou continuar exigindo uma conta Microsoft.

## 5. Revise e crie

Confira edição, modo, remoções e caminhos. A criação só começa após sua confirmação. O arquivo de saída não sobrescreve uma ISO existente. Expanda as etapas para ver detalhes. Ao terminar, confira o SHA-256, os logs e o relatório.

## Cancelar, retomar e recuperar

Use **Cancelar com segurança** e aguarde a operação ativa terminar. Isso pode levar minutos. Não encerre à força enquanto uma imagem estiver montada.

**Retomar criação** verifica e continua o progresso salvo. Nem toda interrupção gera um ponto válido. As escolhas da criação são mantidas na retomada.

**Recuperar área de trabalho** limpa uma cópia interrompida quando aplicável. Selecione o `job.json` da tarefa correta. Tarefas com progresso salvo devem ser retomadas. A origem e os logs são preservados.

## Teste antes de instalar

Inicialize a ISO em uma máquina virtual. Confira instalação, rede, aplicativos e, no modo Equilibrado, atualizações, Defender e recuperação. Esta interface não certifica compatibilidade com todo hardware.
