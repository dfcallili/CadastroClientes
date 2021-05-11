import { Sexo } from "./sexo.enum";

export class ClienteCrmall {
  id: number;
  nome: string;
  dataDeNascimento: Date;
  dataDeNascimentoString: string;
  sexo: Sexo;
  endereco: EnderecoCrMall

}

export class EnderecoCrMall {
  id: number;
  cep: string;
  logradouro: string;
  numero: number;
  complemento: string;
  bairro: string;
  uf: string;
  localidade: string;
}
