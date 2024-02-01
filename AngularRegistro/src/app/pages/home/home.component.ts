import { Component, OnInit } from '@angular/core';
import { ProdutoService } from '../../services/produto.service';
import { Produto } from '../../models/Produto';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
search($event: Event) {
  const target = event?.target as HTMLInputElement;
  const value = target.value.toLocaleLowerCase();
  this.produto = this.produtoGeral.filter(produto => {
    return produto.nome.toLocaleLowerCase().includes(value);
  })
}

  produto: Produto[] = [];
  produtoGeral: Produto[] = [];

  constructor( private produtoService : ProdutoService){}

  ngOnInit(): void {
    
    this.produtoService.GetProdutos().subscribe(data =>{
      const dados = data.dados;

      this.produto = dados;
      this.produtoGeral = dados

      dados.map((item) =>{
        //console.log(item.nome);
      })
    });

  }
}
