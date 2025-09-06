import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MemoService {
  urlBase = "http://localhost:5050/api/Memo/"
  constructor(private http : HttpClient) { }
}
