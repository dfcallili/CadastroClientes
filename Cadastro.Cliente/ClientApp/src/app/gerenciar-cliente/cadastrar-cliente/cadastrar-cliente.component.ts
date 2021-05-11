import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ClienteCrmall, EnderecoCrMall } from '../models/cliente.model';
import { FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import { Sexo } from '../models/sexo.enum';
import { ActivatedRoute, Router } from '@angular/router';



@Component({
  selector: 'app-cadastrar-cliente',
  templateUrl: './cadastrar-cliente.component.html'
})
export class CadastrarClienteComponent implements OnInit {
  private apiCliente: string;
  private http: HttpClient;
  form: FormGroup;
  listaDeSexo: any[] = [
    { label: Sexo.retornarNomeFormaDeContratacao(Sexo.Masculino), value: Sexo.Masculino },
    { label: Sexo.retornarNomeFormaDeContratacao(Sexo.Feminino), value: Sexo.Feminino }
  ];

  constructor(private fb: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.apiCliente = baseUrl + 'api/cliente';
      this.http = http;
  }

  ngOnInit() {
    this.criarForm();
    const id = this.activatedRoute.snapshot.params.id;

    if (id) {
      this.carregarCliente(id);
    }
  }

  private carregarCliente(id: number) {
    this.http.get<ClienteCrmall>(this.apiCliente + '/' + id).subscribe(result => {
      this.form.get('id').setValue(result.id);
      this.form.get('nome').setValue(result.nome);
      this.form.get('sexo').setValue(result.sexo);
      this.form.get('dataDeNascimento').setValue(result.dataDeNascimentoString);
      this.form.get('cep').setValue(result.endereco.cep);
      this.form.get('numero').setValue(result.endereco.numero);
      this.form.get('localidade').setValue(result.endereco.localidade);
      this.form.get('logradouro').setValue(result.endereco.logradouro);
      this.form.get('complemento').setValue(result.endereco.complemento);
      this.form.get('bairro').setValue(result.endereco.bairro);
      this.form.get('uf').setValue(result.endereco.uf);
    });
  }

  private criarForm() {
    this.form = this.fb.group({
      id: [0],
      nome: ['', Validators.required],
      dataDeNascimento: [''],
      sexo: [''],
      cep: [''],
      localidade: [''],
      numero: ['', Validators.required],
      logradouro: [''],
      complemento: [''],
      bairro: [''],
      uf: [''],
    });
  }

  voltarParaListagem(){
    this.router.navigateByUrl('/gerenciar-cliente');
  }

  buscarCep() {
    const cep = this.form.value.cep;

    this.http.get<EnderecoCrMall>(this.montarViaCepApi(cep)).subscribe(result => {
      this.form.get('localidade').setValue(result.localidade);
      this.form.get('logradouro').setValue(result.logradouro);
      this.form.get('complemento').setValue(result.complemento);
      this.form.get('bairro').setValue(result.bairro);
      this.form.get('uf').setValue(result.uf);
      console.log(result);
    });
  }

  montarViaCepApi(cep: number): string{
    return 'https://viacep.com.br/ws/'+ cep +'/json/';
  }

  public salvar() {

    if(this.form.value.nome == '')  {
      alert('informe o nome');
      return;
    }



    if(this.form.value.sexo == '')  {
      alert('informe o sexo');
      return;
    }

    if(this.form.value.dataDeNascimento == '')  {
      alert('informe a Data de Nascimento');
      return;
    }

    if(this.form.value.cep == '')  {
      alert('informe o cep');
      return;
    }

    if(this.form.value.numero == '')  {
      alert('informe o numero');
      return;
    }

    const modelo = this.instacionarModelo();
    let body = JSON.stringify(modelo);
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    let options = new Object({ headers: headers });

    this.http.post(this.apiCliente, body, options)
      .subscribe(result => {
        this.voltarParaListagem();
      }, error => console.error(error));
  }

  private instacionarModelo(): ClienteCrmall {
    const modelo = new ClienteCrmall();
    modelo.id = this.form.value.id;
    modelo.nome = this.form.value.nome;
    modelo.dataDeNascimento = new Date(1985, 3 ,21);
    modelo.sexo = this.form.value.sexo;
    modelo.endereco = new EnderecoCrMall();
    modelo.endereco.cep = this.form.value.cep;
    modelo.endereco.localidade = this.form.value.localidade;
    modelo.endereco.bairro = this.form.value.bairro;
    modelo.endereco.complemento = this.form.value.complemento;
    modelo.endereco.uf = this.form.value.uf;
    modelo.endereco.logradouro = this.form.value.logradouro;
    modelo.endereco.numero = this.form.value.numero;
    return modelo;
  }

}
