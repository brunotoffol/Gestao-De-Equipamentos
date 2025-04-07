# Gestao De Equipamentos e Chamados

# Sistema de Equipamentos e Chamados para a Academia do Programador

![](https://imgur.com/4HzlCYk.gif)

## Introdução

Um sistema de gestão de equipamentos e chamados que auxilia na administração de inventário e incidentes

### Funcionalidades
* Equipamentos possuem um identificador único
* Cadastro de equipamentos e chamados
* Edição de equipamentos e chamados cadastrados
* Exclusão de equipamentos e chamados cadastrados
* Registra as datas que foram realizados os cadastros e o tempo decorrido desde a abertura do chamado até o dia atual


### Como utilizar:
1. Clone o repositório ou baixe o código fonte
2. Abre o terminal ou prompt de comando e navegue até a pasta raiz
3. Utilize o comando abaixo para restaurar as depências do projeto

```
dotnet restore
```
4. Em seguida, compile a solução utilizando o comando:
```
dotnet build --configuration Release
```
5. Para Executar o projeto compilando em tempo real
```
dotnet run --project GestaoDeEquipamento.ConsoleApp
```
6. Para executar o arquivo compilado, navegue até a pasta ./GestaoDeEquipamento.ConsoleApp/bin/Release/net8.0/ e execute o arquivo:
```
GestaoDeEquipamento.ConsoleApp.exe
```

## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.

