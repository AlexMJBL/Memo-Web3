import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, map } from 'rxjs';
import { Compte } from '../models/compte';
import { CompteJeton } from '../models/compteJeton';
@Injectable({
  providedIn: 'root'
})
export class CompteService {

  compteConnecte$ = new BehaviorSubject<CompteJeton | null>(
    JSON.parse(localStorage.getItem('compteJeton') || 'null')
  );

  urlBase = "http://localhost:5050/api/compte/"

  constructor(private http: HttpClient) { }

  seConnecter(infoConnexion: any) {
    return this.http.post(this.urlBase + 'seconnecter', infoConnexion).pipe(
      map((reponse: any) => {
        if (reponse) {
          this.compteConnecte$.next(reponse);
          localStorage.setItem('compteJeton', JSON.stringify(reponse))
        }
      }
      )
    );
  }

  seDeconnecter() {
    localStorage.removeItem('compteJeton');
    this.compteConnecte$.next(null);
  }

  sInscrire(compte: Compte) {
    return this.http.post(this.urlBase + 'EnregistrerCompte', compte)
  }

}
