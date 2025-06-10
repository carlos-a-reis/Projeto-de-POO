using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Entrega_1.Entrega_1
{
    class Banco
    {
        private string Nome;
        private int Codigo;
        private List<Conta> Contas = new List<Conta>();

        public string GetNome() { return Nome; }
        public int GetCodigo() { return Codigo; }
        public List<Conta> GetContas() { return Contas; }

        public Banco(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Console.WriteLine("\n--- Banco Criado ---");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Código: {Codigo}");
            Console.WriteLine("--------------------");

        }

        public void InfoBanco()
        {
            Console.WriteLine("\n--- Informações do Banco ---");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Código: {Codigo}");
            Console.WriteLine("----------------------------");

        }

        public Conta AbrirConta(string numeroAgencia, string numeroConta, string nomeTitular, double saldoInicial)
        {
            Conta novaConta = new Conta(saldoInicial, numeroAgencia, numeroConta, nomeTitular, this);
            Contas.Add(novaConta);

            return novaConta;
        }

        public Conta BuscarConta(string agencia, string numeroConta)
        {
            foreach (var conta in Contas)
            {
                if (conta.GetNumeroAgencia() == agencia && conta.GetNumeroConta() == numeroConta)
                {
                    conta.InfoConta();

                    return conta;
                }
            }
            Console.WriteLine("\nDesculpe, conta não encontrada");
            return null;
            
        }

        public List<Conta> ListarContas()
        {
            if (Contas.Count == 0)
            {
                Console.WriteLine("\nDesculpe, não há contas cadastradas");

                return null;
            }
            else
            {
                foreach (var conta in Contas)
                {
                    conta.InfoConta();
                }

                return Contas;
            }
        }
    }
}
