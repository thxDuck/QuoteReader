# QuoteReader

L'objectif est de créer un lecteur de quotes d'un célèbre site de d'extraits de discutions d'internet.

# Objectifs : 
1. Maitriser l'archi MVC tout en respectant les principes SOLID
2. Effectuer des requetes HTTP côté serveur
3. Parsing du HTML pour récupérer les informations nécessaire a la création de la données Quote. 
4. Intégrer un CRUD sur les données
5. Affichage simple des quotes avec différent tris
6. Ajout d'une fonctionnalité de "Read/Unread"
7. Intégration de tests unitaires

## Parsing HTML:
Utilisation du package NuGet : (AngleSharp)[https://github.com/AngleSharp/AngleSharp] 
Avantages : licence MIT, Rapide, support de LINQ sur le DOM html 🤯
 Installation : 
 ```shell
 dotnet add package AngleSharp
 ```