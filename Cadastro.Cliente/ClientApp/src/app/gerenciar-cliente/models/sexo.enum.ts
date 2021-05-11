export enum Sexo {
  Masculino = 1,
  Feminino = 2
}

export namespace Sexo {
  export function retornarNomeFormaDeContratacao(forma: Sexo): string {
      if (forma === 1) {
        return 'Masculino';
      }

      if (forma === 2) {
        return 'Feminino';
      }
  }
}
