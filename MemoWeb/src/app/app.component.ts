import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { CompteService } from './services/compte.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  estConnecte = false;

  constructor(private compteService: CompteService, private routeur: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.compteService.compteConnecte$.subscribe(compte => {
      this.estConnecte = !!compte;
    });
  }

  seDeconnecter() {
    this.routeur.navigateByUrl('/');
    this.compteService.seDeconnecter();
  }
}
