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
public abstract class Conta
//classe abstrata é uma classe que serve de modelo para outras classes. Ela não pode ser instanciada.
//a classe abstrata deve conter pelo menos um método abstrato
{
    public int Agencia { get; private set; }
    public int Numero { get; private set; }
    public decimal Saldo { get; protected set; }//preciso entender esse negócio de get/set
    public decimal CustoTotal = 0;
    public int TipoConta;
    public string Nome;
    DateTime HoraTransacao;

    public Banco TipoBanco;

    public Conta(int agencia, int numero, Banco tipoBanco, string nome)
    {
        Agencia = agencia;
        TipoBanco = tipoBanco;
        Numero = numero;
        Nome = nome;
    }

    public abstract void Sacar(decimal valor);
    //O método abstrato não possui a sua implementação na classe abstrata
    //A implementação do método abstrato deve ser feita na classe filha, através da sobrescrita do método (override).
    public void Transferir(decimal valor, Conta contaSaida, Conta contaEntrada)
    {
        if (Saldo < valor)
        {
            Console.WriteLine("Saldo insuficiente para transferência.");
        }
        else
        {
            Saldo -= valor;
            contaEntrada.Saldo += valor;
            //contaEntrada.Depositar(valor, contaEntrada);
            Console.WriteLine($"Você transferiu {valor.ToString("C")}");
            Console.WriteLine($"Seu saldo é {contaSaida.Saldo.ToString("C")}");

        }

    }

    public void Depositar(decimal valor, Conta contaEntrada)
    {
        int LimiteSuperior = 20;
        int LimiteInferior = 6;
        DateTime TempoTransacao = DateTime.Now;
        int HoraTransacao = TempoTransacao.Hour;
        if (HoraTransacao > LimiteSuperior || HoraTransacao < LimiteInferior)
        {
            Console.WriteLine($"Transação apenas pode ser realizada dentro do horário de {LimiteInferior}h às {LimiteSuperior}h");
            Console.WriteLine($"Processamento: {TempoTransacao}");

        }
        else
        {
            Saldo += valor;
            Console.WriteLine("Depósito autorizado!!");
            Console.WriteLine($"Você depositou {valor.ToString("C")}");
            Console.WriteLine($"Seu saldo é {contaEntrada.Saldo.ToString("C")}");
            return;
        }

    }
}
