import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CompteService } from './compte.service';
import { Memo } from '../models/Memo';

@Injectable({
  providedIn: 'root'
})
export class MemoService {
  urlBase = "http://localhost:5050/api/Memo/"
  constructor(private http: HttpClient, private compteService: CompteService) { }


  obtenirMemos() {
    const compte = this.compteService.compteConnecte$.value;
    if (!compte) throw new Error("Utilisateur non connecté");
    return this.http.get<Memo[]>(this.urlBase + 'Get/' + compte.nomUtilisateur)
  }

  ajouterMemo(memo: Memo) {
    const compte = this.compteService.compteConnecte$.value;
    if (!compte) throw new Error("Utilisateur non connecté");
    return this.http.post(this.urlBase + 'Ajouter/' + compte.nomUtilisateur, memo)
  }

  supprimerMemo(id: number) {
    return this.http.delete(this.urlBase + 'Supprimer/' + id)
  }
}
