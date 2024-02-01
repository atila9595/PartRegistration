import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Response } from '../models/Response';
import { Produto } from '../models/Produto';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  private apiUrl = `${environment.apiUrl}/Produto`

  constructor( private http: HttpClient) {
    
   }
   GetProdutos() : Observable<Response<Produto[]>>{
    return this.http.get<Response<Produto[]>>(this.apiUrl);
  }
}


