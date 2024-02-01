export interface Response<T>{
    dados: T;
    mensagem: string;
    secesso: boolean;
}