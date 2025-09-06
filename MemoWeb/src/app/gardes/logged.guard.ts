import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CompteService } from '../services/compte.service';


export const loggedGuard: CanActivateFn = (route, state) => {
  const compteService = inject(CompteService);
  const toastr = inject(ToastrService)
  const routeur = inject(Router)

  if (compteService.compteConnecte$.value) {
    toastr.error('La page demandée n\'est pas accessible');
    routeur.navigateByUrl('home')
    return false;
  }

  return true;

};


