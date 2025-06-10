using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Entrega_1.Entrega_1
{
    class Conta
    {
        private double Saldo;
        private string NumeroAgencia;
        private string NumeroConta;
        private string NomeTitular;
        private Banco BancoProprietario;

        private string ultimoSaque = "Ainda não foram realizados saques nesta conta";
        public string UltimoSaque{ get { return ultimoSaque; } }
        private string ultimoDeposito = "Ainda não foram realizados depósitos nesta conta";
        public string UltimoDeposito { get { return ultimoDeposito; } }
        private string ultimaTransferencia = "Ainda não foram realizados transferências nesta conta";
        public string UltimaTransferencia { get { return ultimaTransferencia; } }

        public string GetNumeroAgencia() { return NumeroAgencia; }
        public string GetNumeroConta() { return NumeroConta; }

        public Conta(double saldo, string numeroAgencia, string numeroConta, string nomeTitular, Banco bancoProprietario)
        {
            try
            {
                if(saldo > 0)
                {
                    Saldo = Math.Round(saldo, 2);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Saldo), "O saldo inicial deve ser maior que R$ 0.00");
                }

                NumeroAgencia = numeroAgencia;
                NumeroConta = numeroConta;
                NomeTitular = nomeTitular;
                BancoProprietario = bancoProprietario;

                Console.WriteLine("\n--- Conta Criada ---");
                Console.WriteLine($"Número: {NumeroConta}");
                Console.WriteLine($"Agência: {NumeroAgencia}");
                Console.WriteLine($"Titular: {NomeTitular}");
                Console.WriteLine($"Saldo: R$ {Saldo:F2}");
                Console.WriteLine($"Banco: {BancoProprietario.GetNome()}");
                Console.WriteLine($"Código: {BancoProprietario.GetCodigo()}");
                Console.WriteLine("--------------------");

            }
            catch (ArgumentOutOfRangeException error)
            {
                Console.WriteLine($"\nOcorreu um erro ao criar a nova conta: {error.Message}");
            }
            catch (Exception error)
            {
                Console.WriteLine($"\nErro inespera ao criar nova conta: {error.Message}");
            }
        }

        public void InfoConta()
        {
            Console.WriteLine("\n--- Informações da Conta ---");
            Console.WriteLine($"Número: {NumeroConta}");
            Console.WriteLine($"Agência: {NumeroAgencia}");
            Console.WriteLine($"Titular: {NomeTitular}");
            Console.WriteLine($"Saldo: R$ {Saldo:F2}");
            Console.WriteLine($"Banco: {BancoProprietario.GetNome()}");
            Console.WriteLine($"Código: {BancoProprietario.GetCodigo()}");
            Console.WriteLine("----------------------------");
        }

        public void SaldoConta()
        {
            Console.WriteLine($"Conta: {NumeroConta} -- Agência: {NumeroAgencia}");
            Console.WriteLine("\n--------- Saldo ---------");
            Console.WriteLine($"R$ {Saldo:F2}");
            Console.WriteLine("---------------------------");
        }

        public void Depositar(double valor)
        {
            double saldoAnterior = Saldo;
            Saldo = Saldo + valor;

            ultimoDeposito = "\n--- Depósito Realizado ---\n" +
            $"Conta: {NumeroAgencia}-{NumeroConta}\n" +
            $"Saldo Anterior: R$ {saldoAnterior:F2}\n" +
            $"Valor Depositado: R$ {valor:F2}\n" +
            $"Saldo Atual: R$ {Saldo:F2}\n" +
            "--------------------------";

            Console.WriteLine(ultimoDeposito);
        }

        public void Sacar(double valor)
        {
            try
            {
                if (Saldo >= valor)
                {
                    double saldoAnterior = Saldo;
                    Saldo -= valor;

                    ultimoSaque = "\n--- Saque Realizado ---\n" +
                    $"Conta: {NumeroAgencia}-{NumeroConta}\n" +
                    $"Saldo Anterior: R$ {saldoAnterior:F2}\n" +
                    $"Valor Sacado: R$ {valor:F2}\n" +
                    $"Saldo Atual: R$ {Saldo:F2}\n" +
                    "-----------------------";

                    Console.WriteLine(ultimoSaque);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Saldo), "O valor do saque não pode ser maior que o saldo da conta");
                }
            }
            catch (ArgumentOutOfRangeException error)
            {
                Console.WriteLine($"\nOcorreu um erro ao realizar o saque: {error.Message}");
            }
            
        }

        public void RealizarTransferencia(double valor, Conta contaTransferencia)
        {
            try
            {
                if (Saldo >= valor && contaTransferencia != this)
                {
                    contaTransferencia.ReceberTransferencia(valor);

                    double saldoAnterior = Saldo;
                    Saldo -= valor;

                    ultimaTransferencia = "\n--- Transferência Realizada ---\n" +
                    $"Conta: {NumeroAgencia}-{NumeroConta}\n" +
                    $"Saldo Anterior: R$ {saldoAnterior:F2}\n" +
                    $"Valor Transferido: R$ {valor:F2}\n" +
                    $"Saldo Atual: R$ {Saldo:F2}\n" +
                    "-------------------------------";

                    Console.WriteLine(ultimaTransferencia);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Saldo), "Saldo insuficiente ou Conta inválida para transferência");
                }
            }
            catch (ArgumentOutOfRangeException error)
            {
                Console.WriteLine($"\nOcorreu um erro ao realizar a transferência: {error.Message}");
            }

        }

        public void ReceberTransferencia(double valor)
        {
            double saldoAnterior = Saldo;
            Saldo += valor;

            ultimaTransferencia = "\n--- Transferência Recebida ---\n" +
            $"Conta: {NumeroAgencia}-{NumeroConta}\n" +
            $"Saldo Anterior: R$ {saldoAnterior:F2}\n" +
            $"Valor Recebido: R$ {valor:F2}\n" +
            $"Saldo Atual: R$ {Saldo:F2}\n" +
            "------------------------------";
        }
    }
}

