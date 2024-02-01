import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Produto } from 'src/app/models/Produto';
import { ProdutoService } from 'src/app/services/produto.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent {

  btnAcao = "Cadastrar";
  btnTitulo = "Cadastrar produto!"

  constructor(private produtoService: ProdutoService, private router: Router){}
  
createProduto(event: Produto) {
console.log("create cadastro funcionario"+ event);
this.produtoService.CreateProdutos(event).subscribe((data) => {
  this.router.navigate(['/']);
});
}

}
