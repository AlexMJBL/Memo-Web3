import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Memo } from '../models/Memo';
import { MemoService } from '../services/memo.service';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-memo',
  standalone: true,
  imports: [DatePipe],
  templateUrl: './memo.component.html',
  styleUrl: './memo.component.css'
})
export class MemoComponent {
  @Input() memo: Memo | undefined;
  @Output() memoSupprime = new EventEmitter<number>();

  constructor(private memoService: MemoService, private toastr: ToastrService) { }

  supprimerMemo() {
    if (!this.memo) return;

    this.memoService.supprimerMemo(this.memo.id).subscribe({
      next: (response: any) => {
        this.toastr.success(response.message);
        this.memoSupprime.emit(this.memo!.id);
      },
      error: (erreur) => this.toastr.error(erreur.error?.message || 'Erreur inconnue')
    });
  }
}
