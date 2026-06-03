# Outdoor Notebook
## Description
Il s'agit d'un petit projet en C# qui permet d'acceder à une liste de sorties et de les trier sous difféents critères.

## Prérequis
Xunit

## Commandes
Compiler: dotnet build
Lancer les tests: dotnet test
Lancer le projet: dotnet run --project OutdoorNotebook.Console

## Structure
data contient les données enregistrées sous forme de json,
OutdoorNotebook.Console contient le code à executer avec une focntion main
OutdoorNotebook.Core contient la classe OutdoorEvent ainsique les classes de logique métier.
et OutdoorNotebook.test contient le tests.

## Ce que nous avons appris
On a apris les bases de C#, comment s'en servir pour générer du json, et utiliser des données venues de json en entrée, et le traitement de données avec LINQ.
