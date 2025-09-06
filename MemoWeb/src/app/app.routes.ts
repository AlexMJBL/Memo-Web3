import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CompteNouveauComponent } from './compte-nouveau/compte-nouveau.component';
import { HomeComponent } from './home/home.component';
import { MemoNouveauComponent } from './memo-nouveau/memo-nouveau.component';

export const routes: Routes = [
{path: "", component: LoginComponent},
{path: "nouveauCompte", component: CompteNouveauComponent},
{path: "home", component: HomeComponent},
{path: "memo/nouveau", component : MemoNouveauComponent},
{path: "**", component : HomeComponent}
];
