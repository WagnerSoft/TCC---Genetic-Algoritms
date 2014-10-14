using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    public class População
    {
        private class Celula
        {
            public Individuo item;
            public Celula prox;
        }
        private Celula primeiro, ultimo, pos; // Operações 
        private int TamanhoLista;
        public População()
        { // Cria uma Lista vazia 
            this.primeiro = new Celula();
            this.pos = this.primeiro;
            this.ultimo = this.primeiro;
            this.primeiro.prox = null;
            this.TamanhoLista = 0;
        }
        public Individuo pesquisa(int chave)
        {
            if (this.vazia())
                return null;
            Celula aux = this.primeiro;
            while (aux.prox != null)
            {
                if (aux.prox.item.getID().Equals(chave))
                {
                    return aux.prox.item;
                }
                aux = aux.prox;
            } 
            return null;
        }
        public void insere(Individuo x)
        {
            this.ultimo.prox = new Celula();
            this.ultimo = this.ultimo.prox;
            this.ultimo.item = x;
            this.ultimo.prox = null;
            this.TamanhoLista++;
            
        }
        public int retira(int chave)
        {
            if (this.vazia() || (chave == null))
                throw new Exception("Erro : Lista vazia ou chave invalida");
            Celula aux = this.primeiro;
            while (aux.prox != null && !aux.prox.item.getID().Equals(chave))
                aux = aux.prox;
            if (aux.prox == null)
                return -1; // não encontrada 
            Celula q = aux.prox;
            Individuo item = q.item;
            aux.prox = q.prox;
            if (aux.prox == null) this.ultimo = aux;
            this.TamanhoLista--;
            return item.getID();
        }
        public Individuo retiraPrimeiro()
        {
            if (this.vazia()) throw new Exception("Erro : Lista vazia");
            Celula aux = this.primeiro;
            Celula q = aux.prox;
            Individuo item = q.item;
            aux.prox = q.prox;
            if (aux.prox == null) this.ultimo = aux;
            this.TamanhoLista--;
            return item;
        }
        public Individuo Primeiro()
        {
            this.pos = primeiro;
            return proximo();
        }
        public Individuo proximo()
        {
            this.pos = this.pos.prox;

            if (this.pos == null)
                return null;
            else
                return this.pos.item;
        }
        public bool vazia()
        {
            return (this.primeiro == this.ultimo);
        }
        //public void imprime()
        //{
        //    Celula aux = this.primeiro.prox;
        //    while (aux != null)
        //    {
        //        aux.item.imprimeitem();
        //        aux = aux.prox;
        //    }
        //}
        public int Tamanho()
        {
            return TamanhoLista;
        }
    }
}
