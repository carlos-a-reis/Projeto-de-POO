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
            Conta contaNova = bancoUVV.AbrirConta("457", "000014-2", "Carlos Augusto", 500);
        }
    }
}
