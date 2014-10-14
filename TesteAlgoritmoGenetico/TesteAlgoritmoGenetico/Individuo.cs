using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAlgoritmoGenetico
{
    // Classe responsavel por representar o meu individuo na população
    public class Individuo
    {
        /* Variaveis responsaveis por definir as caracteristicas do meu individuo
           individuo = representa um conjunto de genes representados por um vetor de binários
           fitness = variavel que representa o quanto este individuo é bom para a minha solução. Quanto melhor o seu fitness melhor o individuo é para o problema
         */
        List<Aminoacido> CadeiaAmino;
        double fitness;
        double diferencial;
        double Rank;
        Random randomNumb;
        bool selecionadoCruzamento;

        // Construtor da classe que inicializa as variaveis 
        public Individuo()
        {
            // o vetor de individuos recebe um tamanho especifico de genes e cada gene é inicializado e seu fitness recebe o valor inicial 0
            CadeiaAmino = new List<Aminoacido>();
            randomNumb = new Random();
            Aminoacido Amino = new Aminoacido(randomNumb.Next(1, 20));
            CadeiaAmino.Add(Amino);
            fitness = 0;
            diferencial = 0;
            Rank = 0;
            selecionadoCruzamento = false;
        }
        public Individuo(Individuo x)
        {
            CadeiaAmino = new List<Aminoacido>();
            foreach (var item in x.getlistaAmino())
            {
                this.CadeiaAmino.Add(item);
            }
            fitness = x.fitness;
            this.diferencial = x.diferencial;
            Rank = x.Rank;
        }

        public double getRank()
        {
            return Rank;
        }
        public void setRank(double newRank)
        {
            Rank = newRank;
        }
        public double getDiferencial()
        {
            return diferencial;
        }
        public void setDiferencial(double newDiferencial)
        {
            diferencial = newDiferencial;
        }
        public double getFitness()
        {
            return fitness;
        }
        public void setFitness(double newFitness)
        {
            fitness = newFitness;
        }
        public int getGeneAt(int positionAt)
        {
            return CadeiaAmino.ElementAt(positionAt).GetAminoacido();
        }
        public void setGeneAt(int newGene, int positionAt)
        {
            CadeiaAmino.ElementAt(positionAt).SetAminoacido(newGene);
        }
        public int returnTamanhoIndividuo()
        {
            return CadeiaAmino.Count();
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
        public List<Aminoacido> getlistaAmino()
        {
            return CadeiaAmino;
        }
    }
}
