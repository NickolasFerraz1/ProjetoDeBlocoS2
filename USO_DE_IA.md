# Declaração de Uso de IA

Aluno: Nickolas Alexandre de Oliveira Ferraz
Disciplina: Desenvolvimento Back-End | Projeto de Bloco TP1
Data: 17/11/2026

Ferramenta utilizada: Claude (Anthropic), como guia de estudo e revisão.

A análise do domínio, as decisões do projeto, os documentos e o código C# foram feitos por mim. A IA foi usada como apoio, conforme descrito abaixo.

## Em que a IA me ajudou

1. **Organização do projeto em etapas.** Para entender como separar o trabalho em fases e etapas (requisitos, casos de uso, diagrama, ambiente, programa e entrega), de forma mais simples de acompanhar.
2. **Revisão de cada etapa.** Eu escrevia cada parte e pedia a revisão, para saber se estava no caminho certo. A IA apontou lacunas, inconsistências (por exemplo, referências cruzadas entre regras e requisitos) e erros de digitação, e eu fiz as correções.
3. **Uso da ferramenta draw.io.** Orientação sobre como montar o diagrama de casos de uso (atores, fronteira do sistema, associações), ajustar as linhas e exportar a imagem.
4. **Sintaxe de trechos em C#.** Como estou começando em C#, pedi ajuda com a sintaxe de alguns trechos, sempre explicando o que cada um faz. O mais complicado foi a leitura e validação de datas na função `LerData` (`Program.cs`): o uso de `DateTime.TryParseExact` com o formato `dd/MM/yyyy`, `CultureInfo.InvariantCulture` e `DateTimeStyles.None`. Também recebi ajuda para entender o escopo de variáveis (declarar a variável antes do `if` e atribuir dentro dos blocos), o `switch` com texto, o tipo `string?` e a organização do menu em uma função por opção.
5. **Organização do documento.** Onde colocar cada seção no PDF, a ordem das seções, a estrutura de pastas do repositório (`docs/` e `src/`) e como identificar os arquivos.

## Outros apoios (registrados por transparência)

- **Justificativa de Escopo:** a IA redigiu um rascunho do texto, a partir das decisões e listas que eu já havia definido no documento, e eu o incluí no PDF.
- **Valores adotados nas suposições:** a IA sugeriu o valor da multa (R$ 2,00 por dia, com teto de R$ 50,00) e a igualdade de prazo e limite entre os tipos de membro. Eu adotei essas decisões.
- **Esqueletos de código:** a IA indicou a estrutura de alguns trechos (laço do menu, `switch`, função de leitura de data). A implementação das funções de negócio (prazo, atraso, multa e limite) foi escrita por mim.
- **README e mensagens de commit:** o texto do README e as sugestões de mensagem de commit foram gerados pela IA.
- **Ajustes no PDF final:** correção de autor e título nas propriedades do arquivo, do subtítulo da capa e de um erro de digitação em uma legenda, feitos pela IA por script, a meu pedido.