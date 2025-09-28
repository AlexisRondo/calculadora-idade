# Calculadora de Idade e Verificador de Habilitação - Turma 2TSPS

## Integrantes do Projeto

- **Alexis Rondo** - RM560384
- **Nathalia Mantovani** - RM99904  
- **Vinicius Rodrigues de Oliveira** - RM559611

## Descrição do Projeto

Este projeto é uma aplicação console desenvolvida em C# que calcula a idade de uma pessoa baseada em sua data de nascimento e verifica se ela atende aos requisitos para obter carteira de habilitação no Brasil.

### Funcionalidades Principais

- **Cálculo de Idade**: Determina a idade exata baseada na data atual do sistema
- **Verificação de Habilitação**: Informa se o usuário pode tirar carteira de habilitação (18 anos ou mais)
- **Suporte a Múltiplos Formatos**: Aceita datas nos formatos dd/mm/aaaa, dd-mm-aaaa e dd.mm.aaaa
- **Validações Robustas**: Impede entrada de datas futuras ou excessivamente antigas
- **Interface Interativa**: Permite cálculos múltiplos em uma única execução

### Tecnologias Utilizadas

- **Linguagem**: C# (.NET 8.0)
- **IDE**: Visual Studio 2022
- **Controle de Versão**: Git/GitHub

### Como Executar

1. Baixe o Zip do repositório e extraia seu conteúdo
2. No Visual Studio vá em Abrir Projeto ou Solução
3. Selecione o arquivo CalculadorIdade.csproj
4. Selecione o arquivo Program.cs e execute o projeto (F5 ou Ctrl+F5)
5. Siga as instruções na tela para inserir a data de nascimento

### Estrutura do Projeto

```
CalculadorIdade/
├── Program.cs              # Código principal da aplicação
├── CalculadorIdade.csproj  # Arquivo de configuração do projeto
└── CalculadorIdade.sln     # Arquivo da solução
```

### Exemplo de Uso

```
=== CALCULADOR DE IDADE E VERIFICADOR DE HABILITAÇÃO ===
Data atual do sistema: 28/09/2025

Formatos aceitos:
- dd/mm/aaaa (ex: 15/03/1990)
- dd-mm-aaaa (ex: 15-03-1990)
- dd.mm.aaaa (ex: 15.03.1990)
Digite sua data de nascimento: 15/03/2000

Data confirmada: 15/03/2000 (segunda-feira)

----------------------------------------
RESULTADO DO CÁLCULO
----------------------------------------
Data de nascimento: 15/03/2000
Data atual: 28/09/2025
Sua idade é: 25 anos

----------------------------------------
VERIFICAÇÃO DE HABILITAÇÃO
----------------------------------------
RESULTADO: PODE TIRAR CARTEIRA DE HABILITAÇÃO!
Você tem 25 anos e já atingiu a idade mínima de 18 anos.
```

### Recursos Implementados

- Tratamento de exceções
- Validação de entrada de dados
- Cálculo preciso de idade considerando mês e dia
- Interface de usuário intuitiva
- Confirmação visual da data interpretada
- Loop para múltiplos cálculos

---
- **Professor**: Marcel Stefan Wagner
- **Disciplina**: Advanced Business Development with .NET
- **Instituição**: FIAP - Unidade Paulista
