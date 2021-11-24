using System;
using System.Collections.Generic;
/*- Proibir saques em contas com saldo menor que o solicitado;
- Exibir total gasto com tarifas nas últimas transações;
- Um cliente pode ter mais de uma conta em um mesmo banco;
- Um cliente não pode ter mais de uma conta do mesmo tipo;
- Modificar o valor da transação para ser em percentual ao invés de valor em reais;
- Clientes com saldo menor que 500 reais não poderão fazer transferências;
- Sacar valores acima de 2000 deverá ser cobrado uma taxa de 1,88%;
- As operações de depósito só poderão ser feitas entre 6 a.m. e 8 p.m.;
- Criar outro banco e transferir entre contas desses dois bancos (transferir para conta poupança e corrente);
- Proibir saques de contas poupança e investimento*/

public class ContaCorrente : Conta
{
    public const decimal CustoSaque = 4.0m;
    public decimal CustoAdicionalSaque;
    public ContaCorrente(int agencia, int numero, Banco tipoBanco, string nome) //o que rolou na linha de baixo???
        : base(agencia, numero, tipoBanco, nome)
    {
    }
    /*O "base" pode ser usado tanto pra método, quanto pra classe construtora. Se eu quero chamar o método
    da classe construtora, tal qual, eu uso base.Sacar(). 
    Em relação ao apresentado acima, o método construtor da ContaCorrente "chamou" o método construtor da Conta
    através do ":base (parâmetro 1, parâmetro 2)"
    PERGUNTAR AO WILTON MAIS DETALHES SOBRE ISSO*/

    public override void Sacar(decimal valor)
    /*override modifica o método da classe mãe. Ele permite uma sobrescrição do método (necessário na ocasião
    visto que o método Sacar foi declarado como abstract na classe mãe (precisa de sobrescrição na classe filha
    Eu posso usar o override independente do método na classe mãe ser abstract.
    Na vdd se o método Sacar tiver sido declarado como virtual, eu já posso modificar aqui na conta corrente.
    A diferença é que declarar como abstract faz com que vc tenha obrigatoriamente que modificar em todas
    as classes filha. Declarar como virtual faz com que vc possa modificar, mas não é obrigatório*/
    {
        if (Saldo - (CustoSaque + valor) < 0)
        {
            Console.WriteLine($"Saldo insuficiente. Você está tentando sacar {valor.ToString("C")}, mas possui apenas {Saldo.ToString("C")}");

        }
        else if (Saldo - (CustoSaque + valor) > 0 && Saldo > 500 && valor > 2000)
        {
            decimal CustoAdicionalSaque = decimal.Multiply(valor,(decimal)0.018);
            Saldo -= (CustoSaque + CustoAdicionalSaque + valor);
            CustoTotal += CustoSaque + CustoAdicionalSaque;
            Console.WriteLine($"Você sacou {valor.ToString("C")} e teve custo adicional de saque de {CustoAdicionalSaque.ToString("C")}");
            Console.WriteLine($"Saldo atual da Conta Corrente = {Saldo.ToString("C")}");
        }
        else if (Saldo - (CustoSaque + valor) > 0 && Saldo > 500)
        {
            Saldo -= (CustoSaque + valor);
            CustoTotal += CustoSaque;
            Console.WriteLine($"Você sacou {valor.ToString("C")}");
            Console.WriteLine($"Saldo atual da Conta Corrente = {Saldo.ToString("C")}");
        }
        else
        {
            Console.WriteLine("Operação não foi processada. Saque apenas para saldos superiores a R$ 500");
            Console.WriteLine($"Seu saldo atual é de R$ {Saldo}");
        }
    }
}
