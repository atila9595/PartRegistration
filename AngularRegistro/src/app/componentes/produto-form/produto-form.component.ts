import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Produto } from 'src/app/models/Produto';

@Component({
  selector: 'app-produto-form',
  templateUrl: './produto-form.component.html',
  styleUrls: ['./produto-form.component.css']
})
export class ProdutoFormComponent implements OnInit{
  @Output() onSubmit = new EventEmitter<Produto>();
  @Input() btnAcao!: string;
  @Input() btnTitulo!: string;
  @Input() dadosProduto: Produto | null = null;

  produtoForm!: FormGroup;

  constructor(){

  }

  ngOnInit(): void {
    
    this.produtoForm = new FormGroup({
      codigo: new FormControl(this.dadosProduto ? this.dadosProduto.codigo : '',[Validators.required]),
      nome: new FormControl(this.dadosProduto ? this.dadosProduto.nome : '',[Validators.required]),
      descricao: new FormControl(this.dadosProduto ? this.dadosProduto.descricao : '',[Validators.required]),
      preco: new FormControl(this.dadosProduto ? this.dadosProduto.preco : '',[Validators.required])

    });
  }

  submit() {
    this.onSubmit.emit(this.produtoForm.value);
    
    }

}
