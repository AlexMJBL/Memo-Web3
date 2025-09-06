import { Component } from '@angular/core';
import { Memo } from '../models/Memo';
import { MemoService } from '../services/memo.service';
import { ToastrService } from 'ngx-toastr';
import { MemoComponent } from "../memo/memo.component";
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MemoComponent, RouterLink],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  memos: Memo[] = [];


  constructor(private memoService: MemoService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.chargerMemos();
  }

  chargerMemos() {
  this.memoService.obtenirMemos().subscribe({
    next: (memos) => 
      this.memos = memos.sort((a, b) => {
        const dateA = a.dateCreation ? new Date(a.dateCreation).getTime() : 0;
        const dateB = b.dateCreation ? new Date(b.dateCreation).getTime() : 0;
        return dateA - dateB;
      }),
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
