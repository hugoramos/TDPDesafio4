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

public class Banco
{
    public string Nome { get; private set; }
    public List<Cliente> ListaClientes;
    public int Agencia { get; private set; }
    public Banco(int agencia, string nome)
    {
        ListaClientes = new List<Cliente>();
        this.Agencia = agencia;
        this.Nome = nome; 
    }

    public void AdicionarCliente(Cliente cliente)
    {
        ListaClientes.Add(cliente);
    }

}