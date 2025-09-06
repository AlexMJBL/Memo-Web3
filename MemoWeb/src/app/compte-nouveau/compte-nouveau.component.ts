import { Component, EventEmitter, Output } from '@angular/core';
import { Compte } from '../models/compte';
import { CompteService } from '../services/compte.service';
import { ToastrService } from 'ngx-toastr';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-compte-nouveau',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './compte-nouveau.component.html',
  styleUrl: './compte-nouveau.component.css'
})

export class CompteNouveauComponent {
  @Output() annulerInscription = new EventEmitter();

  compte: Compte = { motDePasse: '', nomUtilisateur: '' };

  constructor(private compteService: CompteService, private toastr: ToastrService, private router: Router) { }

  sInscrire() {
    if (!this.compte.nomUtilisateur || !this.compte.motDePasse) {
      this.toastr.error('Veuillez remplir tous les champs');
      return;
    }

    this.compteService.sInscrire(this.compte).subscribe({
      next: (message) => {
        this.toastr.success('Compte créé avec succèes , connectez-vous pour utiliser l\'application');
        this.annuler();
      },
      error: (erreur) => this.toastr.error(erreur.error.message)
    });
  }

  annuler() {
    this.router.navigateByUrl('/');
  }
}
