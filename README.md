# 🎬 StreamingFlix

Aplicação de console em **C# / .NET 10** que implementa as regras de negócio de um serviço de streaming fictício, acompanhada de uma suíte de **testes unitários parametrizados com xUnit**.

Projeto desenvolvido para a disciplina **Garantia da Qualidade de Software** (Gestão e Qualidade de Software), com foco em boas práticas de testes automatizados, versionamento e documentação.

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![xUnit](https://img.shields.io/badge/tests-xUnit-5E2D91)
![License](https://img.shields.io/badge/license-MIT-green)

---

## 📑 Sumário

- [Visão geral](#-visão-geral)
- [Requisitos técnicos](#-requisitos-técnicos)
- [Estrutura do projeto](#-estrutura-do-projeto)
- [Como clonar e executar a aplicação](#-como-clonar-e-executar-a-aplicação)
- [Como executar os testes unitários](#-como-executar-os-testes-unitários)
- [Cobertura dos testes parametrizados](#-cobertura-dos-testes-parametrizados)
- [Tecnologias utilizadas](#-tecnologias-utilizadas)
- [Licença](#-licença)

---

## 📖 Visão geral

O **StreamingFlix** simula o núcleo de regras de negócio de uma plataforma de streaming. Toda a lógica está concentrada na classe `PlanoStreamingService`, que oferece três funcionalidades:

| Método | Descrição |
|--------|-----------|
| `ObterClassificacaoPorQualidade(int telasSimultaneas)` | Classifica o plano conforme o número de telas simultâneas: **BÁSICO** (1 tela), **PADRÃO** (2 telas) e **PREMIUM** (4 ou mais telas). |
| `CalcularMensalidadeComDesconto(int valorBase, int mesesContratados)` | Aplica **10% de desconto** para contratos de 6 a 11 meses e **20% de desconto** para contratos de 12 meses ou mais. |
| `PodeAcessarConteudoAdulto(int idade, bool controleParentalAtivo)` | Retorna `true` somente se a idade for **maior ou igual a 18** **e** o controle parental estiver **desativado** (`false`). |

A qualidade das regras é garantida por testes unitários automatizados com **xUnit**, utilizando `[Theory]` e `[InlineData]` para validar múltiplos cenários com um único método de teste.

---

## 🛠 Requisitos técnicos

- **[.NET SDK 10.0](https://dotnet.microsoft.com/download)** (ou superior)
- **[Git](https://git-scm.com/downloads)**
- Terminal (PowerShell, CMD, Bash, Zsh etc.)
- IDE opcional: Visual Studio 2022+, VS Code (com extensão C# Dev Kit) ou JetBrains Rider

Para verificar a versão do .NET instalada:

```bash
dotnet --version
```

---

## 📂 Estrutura do projeto

```text
streaming-flix-xunit/
├── StreamingFlix.sln
├── StreamingFlix.App/
│   ├── StreamingFlix.App.csproj
│   ├── Program.cs
│   └── PlanoStreamingService.cs
├── StreamingFlix.Tests/
│   ├── StreamingFlix.Tests.csproj
│   └── PlanoStreamingServiceTests.cs
├── .gitignore
├── LICENSE
└── README.md
```

- **`StreamingFlix.App`**: projeto de console (`net10.0`) com as regras de negócio.
- **`StreamingFlix.Tests`**: projeto de testes xUnit (`net10.0`) que referencia o projeto `StreamingFlix.App`.

---

## 🚀 Como clonar e executar a aplicação

### 1. Clonar o repositório

```bash
git clone https://github.com/isaqueguimaraes/streaming-flix-xunit.git
```

### 2. Acessar a pasta do projeto

```bash
cd streaming-flix-xunit
```

### 3. Restaurar as dependências

```bash
dotnet restore
```

### 4. Compilar a solução

```bash
dotnet build
```

### 5. Executar a aplicação

```bash
dotnet run --project StreamingFlix.App
```

---

## ✅ Como executar os testes unitários

Na raiz do repositório (onde está o arquivo `StreamingFlix.sln`), execute:

```bash
dotnet test
```

Para uma saída mais detalhada, com o nome de cada cenário executado:

```bash
dotnet test --logger "console;verbosity=detailed"
```

Para executar apenas o projeto de testes:

```bash
dotnet test StreamingFlix.Tests/StreamingFlix.Tests.csproj
```

Ao final da execução, todos os cenários devem ser aprovados (**100% de sucesso**), com uma saída semelhante a:

```text
Aprovado!  – Com falha: 0, Aprovado: 9, Ignorado: 0, Total: 9
```

---

## 🧪 Cobertura dos testes parametrizados

Os testes estão implementados na classe `PlanoStreamingServiceTests`, usando os atributos `[Theory]` e `[InlineData]` do xUnit. São **3 métodos de teste** que cobrem **9 cenários** no total.

### Teste 1: Classificação de planos

Valida o método `ObterClassificacaoPorQualidade`.

| Telas simultâneas | Resultado esperado |
|:-----------------:|:------------------:|
| 1 | `BÁSICO` |
| 2 | `PADRÃO` |
| 4 | `PREMIUM` |

### Teste 2: Cálculo de desconto

Valida o método `CalcularMensalidadeComDesconto`.

| Valor base | Meses contratados | Resultado esperado | Regra aplicada |
|:----------:|:-----------------:|:------------------:|----------------|
| 50 | 1 | 50 | Sem desconto |
| 50 | 6 | 45 | 10% de desconto |
| 50 | 12 | 40 | 20% de desconto |

### Teste 3: Validação de acesso a conteúdo adulto

Valida o método `PodeAcessarConteudoAdulto`.

| Idade | Controle parental ativo | Resultado esperado | Cenário |
|:-----:|:-----------------------:|:------------------:|---------|
| 20 | `false` | `true` | Maior de idade, sem restrição |
| 20 | `true` | `false` | Maior de idade, com restrição |
| 16 | `false` | `false` | Menor de idade |

---

## 🧰 Tecnologias utilizadas

- [C#](https://learn.microsoft.com/dotnet/csharp/)
- [.NET 10](https://dotnet.microsoft.com/)
- [xUnit](https://xunit.net/)
- [Git](https://git-scm.com/) e [GitHub](https://github.com/)

---

## 📄 Licença

Este projeto está licenciado sob a **Licença MIT**. Consulte o arquivo [LICENSE](LICENSE) para mais detalhes.

---

Desenvolvido por:
[Isaque Guimarães](https://github.com/isaqueguimaraes)
[Geovane Santos](https://github.com/V4SP3R)
[Kauan de Andrade](https://github.com/KdAndrade)
