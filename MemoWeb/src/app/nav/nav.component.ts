import { Component } from '@angular/core';
import { CompteJeton } from '../models/compteJeton';
import { CompteService } from '../services/compte.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {

  
  estConnecte = false;

  constructor(private compteService: CompteService, private routeur: Router, private toastr: ToastrService){ }

  ngOnInit(): void {
    this.compteService.compteConnecte$.subscribe(compte => {
      this.estConnecte = !!compte;
    });
  }

  seDeconnecter(){
    this.routeur.navigateByUrl('/');
    this.compteService.seDeconnecter();
  }
}
