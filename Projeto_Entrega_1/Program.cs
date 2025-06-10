using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Entrega_1.Entrega_1;

namespace Projeto_Entrega_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banco bancoUVV = new Banco("UVV Bank", 157);

            while (true)
            {
                Conta contaAcesso;

                Console.WriteLine("\n------------- UVV Bank -------------");
                Console.WriteLine("Escolha uma opção (digite o número):");
                Console.WriteLine("1 - Acessar conta");
                Console.WriteLine("2 - Criar conta");
                Console.WriteLine("3 - Listar contas cadastradas");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("------------------------------------");

                int opcao1 = int.Parse(Console.ReadLine());

                if (opcao1 == 0) break;
                else if (opcao1 == 1)
                {
                    Console.WriteLine("\n--- Acesso de Conta ---");
                    Console.WriteLine("Digite o número da Agência:");
                    string agencia = Console.ReadLine();
                    Console.WriteLine("Digite o número da Conta:");
                    string conta = Console.ReadLine();
                    Console.WriteLine("-----------------------");

                    contaAcesso = bancoUVV.BuscarConta(agencia, conta);
                }
                else if (opcao1 == 2)
                {
                    Console.WriteLine("\n--- Criação de Conta ---");
                    Console.WriteLine("Digite o número da Agência:");
                    string agencia = Console.ReadLine();
                    Console.WriteLine("Digite o número da Conta:");
                    string conta = Console.ReadLine();
                    Console.WriteLine("Digite o nome do Titular:");
                    string titular = Console.ReadLine();
                    Console.WriteLine("Digite o Saldo inicial:");
                    double saldo = double.Parse(Console.ReadLine());
                    Console.WriteLine("------------------------");

                    contaAcesso = bancoUVV.AbrirConta(agencia, conta, titular, saldo);
                }
                else if (opcao1 == 3)
                {
                    bancoUVV.ListarContas();
                    continue;
                }
                else
                {
                    Console.WriteLine("\nOpção inválida. Por favor, digite um número entre 0 e 3.");
                    continue;
                }

                while (true)
                {
                    Console.WriteLine($"\n--------- Conta {contaAcesso.GetNumeroConta()} ---------");
                    Console.WriteLine("Escolha uma opção (digite o número):");
                    Console.WriteLine("1 - Visualizar saldo");
                    Console.WriteLine("2 - Realizar saque");
                    Console.WriteLine("3 - Realizar depósito");
                    Console.WriteLine("4 - Realizar transferência");
                    Console.WriteLine("5 - Visualizar último saque");
                    Console.WriteLine("6 - Visualizar último depósito");
                    Console.WriteLine("7 - Visualizar última transferência");
                    Console.WriteLine("0 - Voltar");
                    Console.WriteLine("------------------------------------");

                    int opcao2 = int.Parse(Console.ReadLine());

                    if (opcao2 == 0) break;

                    switch (opcao2)
                    {
                        case 1:
                            contaAcesso.SaldoConta();
                            break;
                        case 2:
                            Console.WriteLine("\n------------------------------");
                            Console.WriteLine($"Saldo disponivel: R$ {contaAcesso.GetSaldoConta()}");
                            Console.WriteLine("------------------------------");

                            Console.WriteLine("Digite o valor do saque:");
                            double saque = double.Parse(Console.ReadLine());

                            contaAcesso.Sacar(saque);
                            break;
                        case 3:
                            Console.WriteLine("Digite o valor do depósito:");
                            double deposito = double.Parse(Console.ReadLine());

                            contaAcesso.Depositar(deposito);
                            break;
                        case 4:
                            Console.WriteLine("\n------------------------------");
                            Console.WriteLine($"Saldo disponivel: R$ {contaAcesso.GetSaldoConta()}");
                            Console.WriteLine("------------------------------");

                            Console.WriteLine("Digite o valor da transferência:");
                            double transferencia = double.Parse(Console.ReadLine());
                            Console.WriteLine("\nDigite a agência da conta para transferência:");
                            string agenciaT = Console.ReadLine();
                            Console.WriteLine("\nDigite o número da conta para transferência:");
                            string contaT = Console.ReadLine();

                            Conta contaTranferencia = bancoUVV.BuscarConta(agenciaT, contaT);

                            contaAcesso.RealizarTransferencia(transferencia, contaTranferencia);
                            break;
                        case 5:
                            contaAcesso.GetUltimoSaque();
                            break;
                        case 6:
                            contaAcesso.GetUltimoDeposito();
                            break;
                        case 7:
                            contaAcesso.GetUltimaTransferencia();
                            break;
                        default:
                            Console.WriteLine("\nOpção inválida. Por favor, digite um número entre 0 e 7.");
                            break;
                    }
                }
            }
        }
    }
}
