using System;
using System.Collections.Generic;

/*
- Proibir saques em contas com saldo menor que o solicitado;
- Exibir total gasto com tarifas nas últimas transações;
- Um cliente pode ter mais de uma conta em um mesmo banco;
- Um cliente não pode ter mais de uma conta do mesmo tipo;
- Modificar o valor da transação para ser em percentual ao invés de valor em reais;
- Clientes com saldo menor que 500 reais não poderão fazer transferências;
- Sacar valores acima de 2000 deverá ser cobrado uma taxa de 1,88%;
- As operações de depósito só poderão ser feitas entre 6 a.m. e 8 p.m.;
- Criar outro banco e transferir entre contas desses dois bancos (transferir para conta poupança e corrente);
- Proibir saques de contas poupança e investimento
*/
public class Program
{
    public static void Main(string[] args)
    {
        #region Carregar os dados
        //CRIANDO ENDEREÇOS
        var endereco1 = new Endereco("1", "rua 1", "bairro 1", "cidade 1");//pq usar var e não o tipo "Endereco"?
        var endereco2 = new Endereco("2", "rua 2", "bairro 2", "cidade 2");
        var endereco3 = new Endereco("3", "rua 3", "bairro 3", "cidade 3");

        //CRIANDO CLIENTES E ADICIONANDO ENDEREÇOS
        var cliente1 = new Cliente("Maria", "123", new DateTime(1984, 1, 10));
        cliente1.AdicionarEnderecoResidencial(endereco1);

        var cliente2 = new Cliente("Raimundo", "321", new DateTime(1984, 6, 4));
        cliente2.AdicionarEnderecoResidencial(endereco2);

        var cliente3 = new Cliente("Joana", "222", new DateTime(1995, 3, 2));
        cliente3.AdicionarEnderecoComercial(endereco3);

        //CRIANDO DOIS BANCOS DIFERENTES
        Banco Banco1 = new Banco(4439, "Banco do Brasil");
        Banco Banco2 = new Banco(5547, "Bradesco");

        //CRIANDO CONTAS
        var contaCorrente1 = new ContaCorrente(Banco1.Agencia, 101, Banco1, "ContaCorrente");
        var contaPoupanca1 = new ContaPoupanca(Banco1.Agencia, 201, Banco1, "Conta Poupança");
        var contaInvestimento1 = new ContaInvestimento(Banco1.Agencia, 301, Banco1, "Conta Investimento");

        var contaCorrente2 = new ContaCorrente(Banco2.Agencia, 101, Banco2, "ContaCorrente");
        var contaPoupanca2 = new ContaPoupanca(Banco2.Agencia, 201, Banco2, "ContaCorrente");
        var contaInvestimento2 = new ContaInvestimento(Banco2.Agencia, 301, Banco2, "ContaCorrente");
        #endregion

        #region Atribuindo os dados
        //ADICIONANDO CONTAS AOS CLIENTES
        cliente1.AdicionarConta(contaCorrente1);
        cliente1.AdicionarConta(contaPoupanca1);
        cliente1.AdicionarConta(contaInvestimento1);

        cliente2.AdicionarConta(contaCorrente2);
        cliente2.AdicionarConta(contaPoupanca2);
        cliente2.AdicionarConta(contaInvestimento2);

        //ADICIONANDO CLIENTES AOS BANCOS
        Banco1.AdicionarCliente(cliente1);
        Banco2.AdicionarCliente(cliente2);
        #endregion

        #region Saídas
        //SAÍDAS
        bool MenuPrincipal = false;
        while (MenuPrincipal == false)
        {
            Console.WriteLine("###################################################### SIMULADOR DE TRANSAÇÕES ###############################################################");
            Console.WriteLine("Insira o número do cliente sobreo qual você deseja ter acesso:");
            Console.WriteLine($"\t 1 - {cliente1.Nome}");
            Console.WriteLine($"\t 2 - {cliente2.Nome}");
            Console.Write($"Opção:");
            int SelecioneCliente = int.Parse(Console.ReadLine());
            // bool MenuSecundario = false;

            //ESCOLHEU A CLIENTE 1
            if (SelecioneCliente == 1)
            {
                IniciarOperacaoComCliente(cliente1, cliente2);
            }
            else if (SelecioneCliente == 2)
            {
                IniciarOperacaoComCliente(cliente2, cliente1);
            }
        }
        #endregion
    }

    public static void IniciarOperacaoComCliente(Cliente clienteEscolhido, Cliente outroCliente)
    {
        bool MenuSecundario = false;

        // cliente1.MostrarDadosCliente(cliente1);
        clienteEscolhido.MostrarDados();

        while (MenuSecundario == false)
        {
            Console.WriteLine("ESCOLHA A OPÇÃO DESEJADA:");
            Console.WriteLine("\t 1 - Depositar");
            Console.WriteLine("\t 2 - Sacar");
            Console.WriteLine("\t 3 - Transferir");
            Console.WriteLine("\t 4 - Verificar Saldo");
            Console.WriteLine("\t 5 - Voltar ao Menu anterior");
            Console.WriteLine("\t 6 - Encerrar");
            int operacaoSelecionada = int.Parse(Console.ReadLine());

            //MENU DEPÓSITO
            if (operacaoSelecionada == 1)
            {
                clienteEscolhido.MostrarDados();

                var horaAtual = DateTime.Now.Hour;
                if (horaAtual < 6 && horaAtual >= 20)
                {
                    Console.WriteLine("\tFORA DO HORÁRIO PERMITIDO");
                    Environment.Exit(0);
                }

                Console.WriteLine("\tAonde deseja despositar?");
                Console.WriteLine("\t 1 - Conta Corrente");
                Console.WriteLine("\t 2 - Conta Poupança");
                Console.WriteLine("\t 3 - Conta Investimento");
                int contaSelecionada = int.Parse(Console.ReadLine());

                if (contaSelecionada == 1)
                {
                    Console.Clear();
                    Console.WriteLine($"Depósito em Conta Corrente do (a) cliente {clienteEscolhido.Nome}");
                    Console.Write("Insira o valor que deseja depositar: ");
                    decimal Valor = decimal.Parse(Console.ReadLine());
                    Console.WriteLine(Valor);
                    clienteEscolhido.Contas[(int)Enums.TipoConta.ContaCorrente].Depositar(Valor, clienteEscolhido.Contas[(int)Enums.TipoConta.ContaCorrente]);
                    Console.WriteLine("Aperte 'enter' para continuar");
                    Console.ReadLine();
                    Console.Clear();

                }
                else if (contaSelecionada == 2)
                {
                    Console.Clear();
                    Console.WriteLine($"Depósito em Conta Poupança do (a) cliente {clienteEscolhido.Nome} ");
                    Console.Write("insira o valor que deseja depositar: ");
                    decimal Valor = decimal.Parse(Console.ReadLine());
                    clienteEscolhido.Contas[(int)Enums.TipoConta.ContaPoupanca].Depositar(Valor, clienteEscolhido.Contas[(int)Enums.TipoConta.ContaPoupanca]);
                    Console.WriteLine("Aperte 'enter' para continuar");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (contaSelecionada == 3)
                {
                    Console.Clear();
                    Console.WriteLine($"Depósito na Conta Investimento do (a) cliente {clienteEscolhido.Nome} ");
                    Console.Write("insira o valor que deseja depositar: ");
                    decimal Valor = decimal.Parse(Console.ReadLine());
                    clienteEscolhido.Contas[(int)Enums.TipoConta.ContaInvestimento].Depositar(Valor, clienteEscolhido.Contas[(int)Enums.TipoConta.ContaInvestimento]);
                    Console.WriteLine("Aperte 'enter' para continuar");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            //MENU SAQUE
            else if (operacaoSelecionada == 2)
            {
                Console.WriteLine("Opção de saque permitida apenas para a Conta Corrente. Deseja Continuar?");
                Console.WriteLine("\t 1 - Sim");
                Console.WriteLine("\t 2 - Não");
                int DeterminaContinuidadeSaque = int.Parse(Console.ReadLine());

                if (DeterminaContinuidadeSaque == 1)
                {
                    Console.Clear();
                    Console.WriteLine($"Saque em Conta Corrente do (a) cliente {clienteEscolhido.Nome} ");
                    Console.Write("Insira o valor que deseja sacar: ");
                    decimal Valor = decimal.Parse(Console.ReadLine());
                    clienteEscolhido.Contas[(int)Enums.TipoConta.ContaCorrente].Sacar(Valor);
                    Console.WriteLine("Aperte 'enter' para continuar");
                    Console.ReadLine();
                    Console.Clear();
                }

            }
            //MENU TRANSFERÊNCIA
            else if (operacaoSelecionada == 3)
            {
                Console.Clear();
                Console.WriteLine("De onde deseja retirar o dinheiro?");
                Console.WriteLine("\t 1 - Conta Corrente");
                Console.WriteLine("\t 2 - Conta Poupança");
                int contaSelecionadaSaida = (int.Parse(Console.ReadLine()) - 1);
                Console.WriteLine($"Depósito para o (a) cliente {outroCliente.Nome}. Qual o tipo da conta do beneficiário?");
                Console.WriteLine("\t 1 - Conta Corrente");
                Console.WriteLine("\t 2 - Conta Poupança");
                int contaSelecionadaEntrada = (int.Parse(Console.ReadLine()) - 1);

                Console.Clear();
                Console.WriteLine($"Tranferência para a {outroCliente.Contas[contaSelecionadaEntrada].Nome} do {outroCliente.Nome}");
                Console.Write("Insira o valor que deseja transferir: ");
                decimal Valor = decimal.Parse(Console.ReadLine());
                clienteEscolhido.Contas[contaSelecionadaSaida].Transferir(Valor, clienteEscolhido.Contas[contaSelecionadaSaida], outroCliente.Contas[contaSelecionadaEntrada]);
                Console.WriteLine("Aperte 'enter' para continuar");
                Console.ReadLine();
                Console.Clear();
            }
            //MENU SALDO
            else if (operacaoSelecionada == 4)
            {
                clienteEscolhido.MostrarSaldo(clienteEscolhido);
                Console.WriteLine("Aperte 'enter' para continuar");
                Console.ReadLine();
                Console.Clear();
            }
            //MENU VOLTAR AO MENU ANTERIOR
            else if (operacaoSelecionada == 5)
            {
                MenuSecundario = true;
                Console.Clear();
            }
            //ENCERRAR
            else if (operacaoSelecionada == 6)
            {
                Environment.Exit(0);
            }
        }

    }
}
