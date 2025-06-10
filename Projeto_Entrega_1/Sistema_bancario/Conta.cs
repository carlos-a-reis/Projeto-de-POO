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

        public double GetSaldo() { return Math.Round(Saldo, 2);}
        public string GetNumeroAgencia() { return NumeroAgencia; }
        public string GetNumeroConta() { return NumeroConta; }
        public string GetNomeTitular() { return NomeTitular; }

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

        public void Depositar(double valor)
        {
            double saldoAnterior = Saldo;
            Saldo = Saldo + valor;

            Console.WriteLine("\n--- Depósito Realizado ---");
            Console.WriteLine($"Conta: {NumeroAgencia}-{NumeroConta}");
            Console.WriteLine($"Saldo Anterior: R$ {saldoAnterior:F2}");
            Console.WriteLine($"Valor Depositado: R$ {valor:F2}");
            Console.WriteLine($"Saldo Atual: R$ {Saldo:F2}");
            Console.WriteLine("--------------------------");

        }

        public void Sacar(double valor)
        {
            try
            {
                if (Saldo >= valor)
                {
                    double saldoAnterior = Saldo;
                    Saldo = Saldo - valor;

                    Console.WriteLine("\n--- Saque Realizado ---");
                    Console.WriteLine($"Conta: {NumeroAgencia}-{NumeroConta}");
                    Console.WriteLine($"Saldo Anterior: R$ {saldoAnterior:F2}");
                    Console.WriteLine($"Valor Sacado: R$ {valor:F2}");
                    Console.WriteLine($"Saldo Atual: R$ {Saldo:F2}");
                    Console.WriteLine("-----------------------");
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
    }
}

