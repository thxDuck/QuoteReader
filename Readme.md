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

# Lancement du projet
Après le clone, effetcuez la commande suivante pour lancer la mise à jour de la BDD : 
```shell
dotnet ef database update
```

Lancez le projet avec F5, puis accèdez a l'url indiquée.
La route `/Quote/Details/{int Id}` permet d'accèder a une quote.
Si elle n'est pas présente dans la base de données, on récupère le HTML correspondant au numéro de la quote, puis on extrait les données du HTML.


## Parsing HTML:
Utilisation du package NuGet : (AngleSharp)[https://github.com/AngleSharp/AngleSharp] 
Avantages : licence MIT, Rapide, support de LINQ sur le DOM html 🤯
 Installation : 
 ```shell
 dotnet add package AngleSharp
 ```

 ## Main Quests : 
  - [x] Récupérer une Quote sur le Web
  - [ ] Insertion des quotes récupérées dans la BDD
  - [ ] Visuel personnalisé de la quote
  - [ ] Lecteur de quote, avec possibilité de choisir si on veux lire dansn l'ordre croissant/décroissant.
  - [ ] En mode Lecture en ordre, noter les quotes comme "Vues"
  

 ## Side Quests :   
 - [x] Utilisation de l'injection de dépendances, pour les class Services.
 - [x] Responsabilité unique (ex: HttpService doit uniquement gére les requêtes HTTP)
 - [ ] Insertion des données dans la BDD


### WIP : 
Prochaine étape : 
- Bon formatage du contenu de la quote pour gérer la couleur de l'username, et le contenu de son texte (modification du modèle)
- Insertion en BDD de la Quote