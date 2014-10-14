using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAlgoritmoGenetico
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneticSolver inicio = new GeneticSolver(3000, 0.70, 0.05, 0);
            inicio.Begin();
        }
    }
}
