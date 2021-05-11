import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ClienteCrmall } from './models/cliente.model';
import { Router } from '@angular/router';
import { Sexo } from './models/sexo.enum';


@Component({
  selector: 'app-gerenciar-cliente',
  templateUrl: './gerenciar-cliente.component.html'
})
export class GerenciarClienteComponent {
  public clientes: ClienteCrmall[];
  private apiCliente: string;
  private http: HttpClient;
  mensagemDeErro: string = '';
  mensagemDeSucesso: string = '';
  EnumSexo: Sexo;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,
  private router: Router) {
    this.apiCliente = baseUrl + 'api/cliente';
    this.http = http;
    this.buscarClientes();

  }

  buscarClientes() {
    this.http.get<ClienteCrmall[]>(this.apiCliente).subscribe(result => {
      this.clientes = result;
    }, error => console.error(error));
  }


  exibirSexoTratato(sexo: Sexo): string {
    return Sexo.retornarNomeFormaDeContratacao(sexo);
  }

  novoCliente() {
    this.router.navigateByUrl('/cadastrar-cliente');
  }

  removerCliente(cliente: ClienteCrmall){
    this.http.delete(this.apiCliente + '/' + cliente.id).subscribe(result => {
        this.mensagemDeSucesso = 'O Cliente "' + cliente.nome + '" foi removido com sucesso.';
        this.buscarClientes();
    }, error => this.mensagemDeErro = error);
  }

  editarCliente(cliente: ClienteCrmall){
    this.router.navigate(['/editar-cliente/', cliente.id]);
  }

  fecharMensagemDeSucesso() {
    this.mensagemDeSucesso = '';
  }

  fecharMensagemDeErro() {
    this.mensagemDeErro = '';
  }
}
