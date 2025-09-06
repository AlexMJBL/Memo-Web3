import { Component } from '@angular/core';
import { Memo } from '../models/Memo';
import { MemoService } from '../services/memo.service';
import { ToastrService } from 'ngx-toastr';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-memo-nouveau',
  standalone: true,
  imports: [FormsModule, RouterModule],
  templateUrl: './memo-nouveau.component.html',
  styleUrl: './memo-nouveau.component.css'
})
export class MemoNouveauComponent {
  memo: Memo = { id: 0, titre: '', description: '' };
  constructor(private memoService: MemoService, private toastr: ToastrService, private router: Router) { }
  creerMemo() {
    if (!this.memo.titre.trim() || !this.memo.description.trim()) {
      this.toastr.error('Le titre et la description sont obligatoires');
      return;
    }


    this.memoService.ajouterMemo(this.memo).subscribe({
      next: () => {
        this.toastr.success('Mémo créé avec succès');
        this.router.navigateByUrl('/home');
      },
      error: (erreur) => this.toastr.error(erreur.error.message)
    });

  }
}

