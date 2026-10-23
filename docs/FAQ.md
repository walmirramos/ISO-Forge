# Perguntas frequentes

[Página principal](../README.md) · [Como usar](usage.md)

## Preciso instalar?

Não. Extraia o ZIP inteiro e abra `ISOForge.exe`. Não precisa instalar o SDK .NET. Mantenha as DLLs e os recursos ao lado do executável: portátil não significa um arquivo único.

## O programa traduz o Windows da ISO?

Não. A interface está em pt-BR; o idioma do Windows depende da mídia selecionada.

## Abrir o aplicativo modifica meu Windows?

Abrir o assistente não inicia a criação. As remoções são destinadas à cópia offline da imagem. A criação monta imagens, utiliza ferramentas do Windows e grava na área de trabalho e no destino escolhido.

## Por que exige administrador?

Montar e fazer manutenção de imagens do Windows exige privilégios administrativos.

## O DISM é incompatível. O que fazer?

Use ferramentas de implantação compatíveis com a mídia, disponíveis no Windows ADK. Reabra o aplicativo após disponibilizar as ferramentas.

## Posso atualizar uma instalação no modo Mínimo?

Não conte com isso. O modo remove suporte a manutenção e recuperação. Avalie Equilibrado para outros cenários e teste o resultado.

## Posso cancelar?

Sim, pelo botão Cancelar com segurança. Aguarde a operação atual. A retomada depende de progresso salvo e válido.

## O executável tem assinatura digital?

O pacote desta edição não inclui assinatura digital própria. Confira a origem e o SHA-256 publicado. Não se trata de um produto oficial da Microsoft.

## Como relatar um problema?

Informe versão do aplicativo, edição e compilação da mídia, modo e passos de reprodução no repositório. Revise os logs antes de compartilhar: podem conter caminhos locais.
