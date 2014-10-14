using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    // Classe responsavel por representar o meu individuo na população
    public class Individuo
    {
        /* Variaveis responsaveis por definir as caracteristicas do meu individuo
           individuo = representa um conjunto de genes representados por um vetor de binários
           fitness = variavel que representa o quanto este individuo é bom para a minha solução. Quanto melhor o seu fitness melhor o individuo é para o problema
         */
        int[] individuo;
        double fitness;
        Random randomNumb;
        bool selecionadoCruzamento;
        int ID;

        // Construtor da classe que inicializa as variaveis 
        public Individuo(int identificador)
        {
            // o vetor de individuos recebe um tamanho especifico de genes e cada gene é inicializado e seu fitness recebe o valor inicial 0
            individuo = new int[50];
            randomNumb = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < individuo.Length; i++)
            {

                individuo[i] = randomNumb.Next(1, 20);
            }
            fitness = 0;
            ID = identificador;
            selecionadoCruzamento = false;
        }
        public Individuo(Individuo x)
        {
            this.individuo = new int[50];
            ID = x.getID();
            fitness = x.getFitness();
            for (int i = 0; i < individuo.Length; i++)
            {
                individuo[i] = x.getGeneAt(i);
            }

        }

        // Função responsavel por retornar o fitness do individuo 
        public double getFitness()
        {
            return fitness;
        }

        // Função responsavel por alterar o valor do fitness do individuo
        public void setFitness(double newFitness)
        {
            fitness = newFitness;
        }

        // Função responsavel por retornar o gene na posição determinada pelo parametro
        public int getGeneAt(int positionAt)
        {
            return individuo[positionAt];
        }

        // Função responsavel por alterar um gene na posição determinada pelo parametro
        public void setGeneAt(int newGene, int positionAt)
        {
            individuo[positionAt] = newGene;
        }
        public int returnTamanhoIndividuo()
        {
            return individuo.Length;
        }
        public void setID(int newID)
        {
            this.ID = newID;
        }
        public int getID()
        {
            return this.ID;
        }
        public bool verificaSeleção()
        {
            return selecionadoCruzamento;
        }
        public void setSelecionadoCruzamento()
        {
            selecionadoCruzamento = true;
        }
        public void setLivreCruzamento()
        {
            selecionadoCruzamento = false;
        }
    }
}
