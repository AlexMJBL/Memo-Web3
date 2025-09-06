import { Component } from '@angular/core';
import { Memo } from '../models/Memo';
import { MemoService } from '../services/memo.service';
import { ToastrService } from 'ngx-toastr';
import { MemoComponent } from "../memo/memo.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MemoComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  memos: Memo[] = [];
  

  constructor(private memoService: MemoService, private toastr: ToastrService ) { }

  ngOnInit(): void {
    this.chargerMemos();
  }

  chargerMemos() {
    this.memoService.obtenirMemos().subscribe({
      next: (memos) => this.memos = memos,
      error: (erreur) => this.toastr.error(erreur.error.message)
    });
  }

  onMemoSupprime(id: number) {
  this.memos = this.memos.filter(m => m.id !== id);
  }

  trackById(index: number, memo: Memo) {
  return memo.id;
  }

}
