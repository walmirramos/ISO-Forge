# ISO Forge

[![Idioma](https://img.shields.io/badge/Idioma-pt--BR-0078D4)](docs/usage.md)
[![Windows 11](https://img.shields.io/badge/Windows-11-0078D4)](docs/usage.md)
[![Portátil](https://img.shields.io/badge/Execução-Portátil-28a745)](https://github.com/walmirramos/ISO-Forge/releases/latest)

**Crie sua ISO personalizada do Windows 11.** Versão em português brasileiro personalizada por **Dubbox**.

**[Acesse o site do ISO Forge](https://walmirramos.github.io/ISO-Forge/)**

[![Download](https://img.shields.io/badge/Download-Versão%20portátil-28a745)](https://github.com/walmirramos/ISO-Forge/releases/latest/download/ISOForge-0.1.1-isoforge.1-win-x64.zip)
[![Documentação](https://img.shields.io/badge/Documentação-Português-0078D4)](docs/usage.md)

## Sobre o projeto

O ISO Forge permite selecionar uma imagem do Windows 11, escolher aplicativos e componentes para remover, ajustar opções de instalação e gerar uma ISO inicializável. A interface usa **WinUI 3**, com temas claro e escuro, Mica e alto contraste.

O programa trabalha sobre uma cópia da mídia. Abrir a interface não inicia a criação automaticamente. Revise suas escolhas antes de confirmar.

## Como baixar e testar

1. [Baixe o ZIP portátil em português](https://github.com/walmirramos/ISO-Forge/releases/latest/download/ISOForge-0.1.1-isoforge.1-win-x64.zip), para PCs Intel/AMD (x64).
2. Extraia **todo o conteúdo** para uma pasta local.
3. Abra **ISOForge.exe** e confirme a solicitação de administrador do Windows.
4. Escolha o modo, selecione a imagem do Windows e confira a edição.
5. Revise as remoções, o local de trabalho e o destino da ISO antes de criar.

**Sem instalador.** O ZIP inclui o executável e suas dependências. Não é necessário instalar o SDK .NET. Mantenha as DLLs e demais arquivos ao lado do EXE; ele não é distribuído como arquivo único.

## Modos de criação

| Modo | Comportamento |
| --- | --- |
| **Equilibrado** | Usa remoções predefinidas, mantendo Windows Update, Defender e recuperação. Algumas remoções podem afetar aplicativos dependentes. |
| **Mínimo** | Reduz mais componentes, remove suporte a manutenção e recuperação e desativa o Defender. Apenas para máquinas virtuais isoladas de teste. |
| **Personalizado** | Permite escolher grupos e componentes individuais. Remoções avançadas podem afetar segurança, atualizações e inicialização. |

## Recursos

- ISO local ou pasta de instalação extraída.
- Download de ISO oficial da Microsoft, sujeito à disponibilidade do serviço.
- Seleção de edição, compactação WIM/ESD e opções de instalação.
- Modo Turbo, configurações salvas, logs e relatório.
- Retomada a partir de progresso salvo e cancelamento em pontos seguros.
- SHA-256 da ISO produzida.

## Documentação e dúvidas

- [Como usar e requisitos](docs/usage.md)
- [Modos e componentes](docs/FEATURES.md)
- [Perguntas frequentes](docs/FAQ.md)
- [Compilar e testar](docs/DEVELOPMENT.md)
- [Notas da tradução](docs/pt-BR.md)
- [Histórico de alterações](CHANGELOG.md)
- [Como contribuir](CONTRIBUTING.md)

## Antes de usar a ISO

Teste a ISO em uma máquina virtual antes de instalar em um computador. O modo Mínimo e remoções avançadas podem produzir uma imagem que não inicialize ou não aceite atualizações. A tradução da interface não altera o idioma de uma ISO existente.

## Autoria e avisos de distribuição

Personalização e documentação em português: **Dubbox**. Projeto: [walmirramos/ISO-Forge](https://github.com/walmirramos/ISO-Forge).

Os avisos de procedência e de terceiros estão preservados em [NOTICE.md](NOTICE.md) e na pasta `licenses` dos pacotes. Consulte os avisos antes de redistribuir. As mídias do Windows não acompanham o aplicativo.

## Assinatura e integridade

O executável desta edição não tem assinatura digital própria. O arquivo `.sha256` na página de download permite conferir a integridade do ZIP. Preserve os avisos de terceiros ao redistribuir.
