using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    //Classe Responsavel por representar a sequencia binaria que representa cada individuo
    public class Gene
    {
        
        int[] geneticCode; // variavel que representa o codigo genetico do meu individuo
        public Gene()
        {
            // variavel responsavel por gerar um numero aleatorio para ser inserido em cada posição do vetor .. valores: 0-1
            Random Rnd = new Random();

            // Variavel responsavel por inicializar o vetor de genes
            geneticCode = new int[5];

            // para cada posição, um numero entre 0-1 é inserido aleatoriamente.
            for (int i = 0; i < geneticCode.Length; i++)
            {
                geneticCode[i] = Rnd.Next(2);
            }
     
        }

        // retorna o gene na posição representada pelo parametro 
       // public int getGeneAt(int positionOf);

        // altera o valor do gene na posição representada pelo parametro
       // public void setGeneAt(int newGene , int positionOf);
    }
}
