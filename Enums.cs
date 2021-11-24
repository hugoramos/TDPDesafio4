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
public static class Enums
{
    public enum TipoConta
    {
        ContaCorrente = 0,
        ContaPoupanca = 1,
        ContaInvestimento = 2
    }

    public enum TipoBanco
    {
        Banco1 = 0,
        Banco2 = 1
    }


}