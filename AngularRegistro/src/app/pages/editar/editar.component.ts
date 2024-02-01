import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Produto } from 'src/app/models/Produto';
import { ProdutoService } from 'src/app/services/produto.service';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarComponent implements OnInit {


  btnAcao: string = 'Editar';
  btnTitulo: string = 'Editar Produto!'
  produto!: Produto;

  constructor(private produtoService : ProdutoService, private route: ActivatedRoute, private router: Router){}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.produtoService.GetProduto(id).subscribe(data => {
      this.produto = data.dados;
    })
  }

  editarProduto(event: Produto) {
    this.produtoService.PutProduto(event).subscribe((data) =>{
      
      this.router.navigate(['/']);
      
    })
    }

}
