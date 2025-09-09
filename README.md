📒 Memo-Web

Memo-Web est une application web permettant de gérer des mémos personnels. Elle est conçue avec une architecture en couches (Clean Architecture) pour assurer la séparation des responsabilités, la maintenabilité et l’extensibilité.

🚀 Fonctionnalités principales

✍️ Créer un mémo avec un titre et une description.

📑 Lister les mémos par utilisateur (compte).

🗑 Supprimer un mémo.

👤 Gestion des comptes utilisateurs (inscription et connexion).

🔐 Authentification simplifiée (retour d’un objet AuthentificationDto avec date d’émission).

✅ Validation des données avec DataAnnotations (DTOs) et validations métier dans les services.

🏗 Architecture

Le projet suit une Clean Architecture composée de plusieurs couches :

1. ApplicationCore

Contient les entités (Compte, Memo)

Contient les interfaces (ICompteService, IMemoService, IAsyncRepository)

Contient la logique métier (services comme CompteService, MemoService)

2. Infrastructure

Implémente les repositories pour l’accès aux données.

Utilise Entity Framework Core avec SQLite (ou autre provider configuré).

3. API

Fournit les contrôleurs REST (CompteController, MemoController).

Gère la validation via [ApiController] et DataAnnotations.

Sérialisation JSON pour la communication avec le front-end.

📂 Structure du projet
Memo-Web/
│
├── MemoApp.ApplicationCore/     # Couche métier et interfaces
│   ├── Entities/                # Entités principales
│   ├── Interfaces/              # Interfaces des services et repositories
│   └── Services/                # Implémentations de la logique métier
│
├── MemoApp.Infrastructure/      # Couche d’accès aux données
│   └── Repositories/            # Implémentations EF Core des interfaces
│
├── MemoApp.Api/                 # API REST (ASP.NET Core Web API)
│   ├── Controllers/             # Contrôleurs API
│   ├── DTO/                     # Objets de transfert de données
│   └── Program.cs / Startup.cs  # Configuration de l’API
│
└── README.md                    # Documentation du projet

⚙️ Prérequis

.NET 8 SDK

SQLite
 ou SQL Server (selon ta config EF Core)

(Optionnel) Postman
 ou Swagger
 pour tester l’API

▶️ Lancer l’application

Cloner le repo

git clone https://github.com/ton-compte/memo-web.git
cd memo-web


Restaurer les dépendances

dotnet restore


Appliquer les migrations EF Core

dotnet ef database update --project MemoApp.Infrastructure --startup-project MemoApp.Api


Lancer l’API

dotnet run --project MemoApp.Api


L’API sera disponible sur http://localhost:5000/api
.

📌 Endpoints principaux
🔑 Comptes

POST /api/Compte/SeConnecter → Connexion utilisateur

POST /api/Compte/EnregistrerCompte → Création de compte

📝 Mémos

POST /api/Memo/Ajouter → Ajouter un mémo

GET /api/Memo/ParCompte/{idCompte} → Récupérer les mémos d’un compte

DELETE /api/Memo/Supprimer/{id} → Supprimer un mémo

🔒 Validation & Sécurité

Les DTOs utilisent des DataAnnotations ([Required], [MaxLength]) → validation automatique côté API.

La logique métier dans les services fait une validation supplémentaire (ex. IdCompte obligatoire, mémo existant avant suppression).

Les mots de passe doivent être hashés avant stockage (exemple avec BCrypt.Net).

🧪 Tests

Les services peuvent être testés indépendamment de l’API grâce aux interfaces (ICompteService, IMemoService).
Exemple de tests possibles :

Création de mémo avec titre vide → exception.

Création de compte avec nom déjà utilisé → exception.

Récupération des mémos par compte valide → retourne liste.
