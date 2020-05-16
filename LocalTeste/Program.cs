using System;
using System.Collections.Generic;
using LocalLib.Controls;
using LocalLib.Models;

namespace LocalTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            /*List<Estado> estados = new EstadoControl().ObterTudo();
            foreach (Estado e in estados)
            {
                Console.WriteLine(e.Nome);
            }*/

            List<Cidade> cidades = new CidadeControl().ObterPorEstado(26);
            foreach (Cidade c in cidades)
            {
                Console.WriteLine(c.Nome+" / "+c.Estado.Sigla);
            }
        }
    }
}
