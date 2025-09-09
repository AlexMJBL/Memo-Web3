Memo-Web

Memo-Web est une application complète de gestion de mémos personnels.
Elle se compose de deux parties :

une API ASP.NET Core pour la logique métier et l’accès aux données

une application Angular comme interface utilisateur

---

Fonctionnalités

Création de comptes utilisateurs avec validation

Connexion et gestion de session

Ajout de mémos (titre et description)

Liste des mémos liés à un utilisateur

Suppression de mémos

---

Architecture
Côté backend (ASP.NET Core)

Organisation en Clean Architecture (ApplicationCore, Infrastructure, API)

Services métiers (CompteService, MemoService)

Repositories génériques via Entity Framework Core (SQLite par défaut)

Validation avec DataAnnotations et règles métier dans les services

Contrôleurs REST exposant les endpoints

Côté frontend (Angular)

Angular 17 avec Angular CLI

Services Angular (HttpClient) pour la communication avec l’API

Formulaires réactifs avec validation (titre et description requis, max 150 caractères)

Gestion de l’état utilisateur (connexion) avec LocalStorage

Routing Angular pour naviguer entre inscription, connexion et liste de mémos

---

Installation et exécution
Prérequis

.NET 8 SDK

Node.js 20+ et Angular CLI

SQLite (ou SQL Server si configuré autrement)

Lancer l’API
cd MemoApp.Api
dotnet run


L’API tourne par défaut sur http://localhost:5000/api.

Lancer le client Angular
cd memo-angular
npm install
ng serve -o


Le client tourne par défaut sur http://localhost:4200.

---

Endpoints principaux de l’API
Comptes

POST /api/Compte/EnregistrerCompte : créer un compte

POST /api/Compte/SeConnecter : se connecter

Mémos

POST /api/Memo/Ajouter : ajouter un mémo

GET /api/Memo/ParCompte/{idCompte} : obtenir les mémos d’un compte

DELETE /api/Memo/Supprimer/{id} : supprimer un mémo

---

Validation et sécurité

Les DTOs sont validés côté API avec DataAnnotations

Les services métiers appliquent une validation supplémentaire pour garantir l’intégrité des données

Les mots de passe doivent être stockés de façon sécurisée (hash avant enregistrement)



Version mobile (PWA)

Ajout de tests unitaires et d’intégration
