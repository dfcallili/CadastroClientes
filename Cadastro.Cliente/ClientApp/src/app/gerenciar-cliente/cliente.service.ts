import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ClienteCrmall } from './models/cliente.model';


@Injectable()
export class ClienteService {
  private apiCliente: string;


  constructor(@Inject('http') public http: HttpClient,
  @Inject('BASE_URL') baseUrl: string) {
    this.apiCliente = baseUrl + "api/cliente";
  }

  listar() {
    return this.http.get<ClienteCrmall[]>(this.apiCliente);
  }

  salvar(dtoCriar: ClienteCrmall): Observable<any> {
    let body = JSON.stringify(dtoCriar);
    let headers = new Headers({ 'Content-Type': 'application/json' });

    return this.http.post(this.apiCliente, body);
  }
}
