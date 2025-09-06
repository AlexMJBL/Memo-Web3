import { Component } from '@angular/core';
import { Compte } from '../models/compte';
import { CompteService } from '../services/compte.service';
import { Router, RouterModule } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  infoConnexion: Compte = { motDePasse: '', nomUtilisateur: '' };

  constructor(private compteService: CompteService, private routeur: Router, private toastr: ToastrService) { }

  seConnecter() {

    if (!this.infoConnexion.nomUtilisateur || !this.infoConnexion.motDePasse) {
      this.toastr.error('Veuillez remplir tous les champs');
      return;
    }

    this.compteService.seConnecter(this.infoConnexion).subscribe(
      {
        next: () => {
          this.routeur.navigateByUrl('/home');
        },
        error: erreur => this.toastr.error(erreur.error.message)
      });
  }
}
