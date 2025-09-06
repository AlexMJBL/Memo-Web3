import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CompteNouveauComponent } from './compte-nouveau/compte-nouveau.component';
import { HomeComponent } from './home/home.component';
import { MemoNouveauComponent } from './memo-nouveau/memo-nouveau.component';
import { connexionGuard } from './gardes/connexion.guard';
import { loggedGuard } from './gardes/logged.guard';

export const routes: Routes = [
{path: "", component: LoginComponent, canActivate: [loggedGuard]},
{path: "nouveauCompte", component: CompteNouveauComponent, canActivate: [loggedGuard]},
{path: "home", component: HomeComponent, canActivate: [connexionGuard]},
{path: "memo/nouveau", component : MemoNouveauComponent, canActivate: [connexionGuard]},
{path: "**", component : HomeComponent, canActivate: [connexionGuard]}
];
