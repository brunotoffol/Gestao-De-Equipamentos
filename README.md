# Gestao De Equipamentos e Chamados

# Sistema de Equipamentos e Chamados para a Academia do Programador

![](https://imgur.com/4HzlCYk.gif)

## Introdu��o

Um sistema de gest�o de equipamentos e chamados que auxilia na administra��o de invent�rio e incidentes

### Funcionalidades
* Equipamentos possuem um identificador �nico
* Cadastro de equipamentos e chamados
* Edi��o de equipamentos e chamados cadastrados
* Exclus�o de equipamentos e chamados cadastrados
* Registra as datas que foram realizados os cadastros e o tempo decorrido desde a abertura do chamado at� o dia atual


### Como utilizar:
1. Clone o reposit�rio ou baixe o c�digo fonte
2. Abre o terminal ou prompt de comando e navegue at� a pasta raiz
3. Utilize o comando abaixo para restaurar as dep�ncias do projeto

```
dotnet restore
```
4. Em seguida, compile a solu��o utilizando o comando:
```
dotnet build --configuration Release
```
5. Para Executar o projeto compilando em tempo real
```
dotnet run --project GestaoDeEquipamento.ConsoleApp
```
6. Para executar o arquivo compilado, navegue at� a pasta ./GestaoDeEquipamento.ConsoleApp/bin/Release/net8.0/ e execute o arquivo:
```
GestaoDeEquipamento.ConsoleApp.exe
```

## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compila��o e execu��o do projeto.

