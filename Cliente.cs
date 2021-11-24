using System;
using System.Collections.Generic;
/*Desafios*Proibir saques em contas com saldo menor que o solicitado;
Exibir total gasto com tarifas nas últimas transações;
Um cliente pode ter mais de uma conta em um mesmo banco;
Um cliente não pode ter mais de uma conta do mesmo tipo;
Modificar o valor da transação para ser em percentual ao invés de valor em reais;
Clientes com saldo menor que 500 reais não poderão fazer transferências;
Sacar valores acima de 2000 deverá ser cobrado uma taxa de 1,88%;
As operações de depósito só poderão ser feitas entre 6 a.m. e 8 p.m.;*/

public class Cliente
{
    public string Nome { get; private set; }
    public string Cpf { get; private set; }
    public DateTime DataNascimento { get; set; }
    public Endereco EnderecoComercial { get; private set; }
    public Endereco EnderecoResidencial { get; set; }
    public List<Conta> Contas;
    bool TesteContaCorrente = true, TesteContaPoupanca = true, TesteContaInvestimento = true;

    public Cliente(string nome, string cpf, DateTime dataNascimento)
    {
        Nome = nome;
        Cpf = cpf;
        DataNascimento = dataNascimento;
        Contas = new List<Conta>();
    }
    public void AdicionarEnderecoResidencial(Endereco enderecoResidencial)
    {
        EnderecoResidencial = enderecoResidencial;
    }
    public void AdicionarEnderecoComercial(Endereco enderecoComercial)
    {
        EnderecoComercial = enderecoComercial;
    }
    public void AdicionarConta(Conta conta)
    {
        Contas.Add(conta);
    }
    // public void MostrarDadosCliente(Cliente cliente)
    // {
    //     Console.Clear();
    //     Console.WriteLine("############################################# DADOS DO CLIENTE #############################################");
    //     Console.WriteLine("\tNome: " + cliente.Nome);
    //     Console.WriteLine($"\tEndereço Residencial: {cliente.EnderecoResidencial.Rua},{cliente.EnderecoResidencial.Numero}, {cliente.EnderecoResidencial.Bairro}, {cliente.EnderecoResidencial.Cidade}. ");
    //     Console.WriteLine("############################################# CONTAS DO CLIENTE #############################################");
    //     for (int i = 0; i < Contas.Count; i++)
    //     {
    //         Console.WriteLine($"\tTipo de conta:{Contas[i].Nome}");
    //         Console.WriteLine($"\t\tAgência: {Contas[i].Agencia}");
    //         Console.WriteLine($"\t\tNúmero: {Contas[i].Numero}");
    //         Console.WriteLine($"\t\tBanco: {Contas[i].TipoBanco.Nome}");
    //     }
    // }
    public void MostrarSaldo(Cliente cliente)
    {
        Console.Clear();
        Console.WriteLine("############################################# SALDO DISPONÍVEL DO CLIENTE ################################################");
        Console.WriteLine($"Saldo da Conta Corrente = {cliente.Contas[(int)Enums.TipoConta.ContaCorrente].Saldo.ToString("C")}");
        Console.WriteLine($"Saldo da Conta Poupanca = {cliente.Contas[(int)Enums.TipoConta.ContaPoupanca].Saldo.ToString("C")}");
        Console.WriteLine($"Saldo da Conta Investimento = {cliente.Contas[(int)Enums.TipoConta.ContaInvestimento].Saldo.ToString("C")}");

    }

    public void MostrarDados()
    {
        Console.Clear();
        Console.WriteLine("############################################# DADOS DO CLIENTE #############################################");
        Console.WriteLine("\tNome: " + this.Nome);
        Console.WriteLine($"\tEndereço Residencial: {this.EnderecoResidencial.Rua},{this.EnderecoResidencial.Numero}, {this.EnderecoResidencial.Bairro}, {this.EnderecoResidencial.Cidade}. ");
        Console.WriteLine("############################################# CONTAS DO CLIENTE #############################################");
        for (int i = 0; i < Contas.Count; i++)
        {
            Console.WriteLine($"\tTipo de conta:{Contas[i].Nome}");
            Console.WriteLine($"\t\tAgência: {Contas[i].Agencia}");
            Console.WriteLine($"\t\tNúmero: {Contas[i].Numero}");
            Console.WriteLine($"\t\tBanco: {Contas[i].TipoBanco.Nome}");
        }
    }

}
