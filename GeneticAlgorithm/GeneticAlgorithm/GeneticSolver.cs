using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GeneticAlgorithm
{
    /*
     * Classe responsavel por executar as operações do algoritmo genetico
     */
    public class GeneticSolver
    {
        /*
         * Criação das variaveis que alimentam o programa 
         */
        Individuo[] population;// variavel responsavel por armazenar a minha população de individuos
        Individuo[] NewPopulation;// variavel responsavel por auxiliar a criação de novas gerações
        int populationNumber;// variavel responsavel por determinar o tamanho da minha população
        double crossOverRate;// variavel responsavel por determinar a porcentagem de individuos da minha população que será utilizada para cross over
        double mutationRate;// variavel que determina a taxa de individuos que sofrerá mutação
        int maxGenerations;// variavel responsavel por determinar se o algoritmo executara até um numero certo degerações
        bool stopSolver;// variavel logica responsavel por parar o algoritmo quando alguma solução ou condição de parada for encontrada
        Dictionary<int, string> Aminoacidos = new Dictionary<int, string>();
        Random Random;
        int[] gabarito;
        int Gerações;

        /* Metodo construtor que inicializa as variaveis da Classe GeneticSolver 
           O metodo recebe como parametro 4 variaveis 
           x = numero de individuos da população que será criada
           y = taxa de crossover
           z = taxa de mutação
           generations = numero de gerações que o algoritmo executara */
        public GeneticSolver(int x, double y, double z, int generations)
        {
            populationNumber = x;
            population = new Individuo[populationNumber];
            NewPopulation = new Individuo[populationNumber];
            crossOverRate = y;
            mutationRate = z;
            stopSolver = false;
            Random = new Random();
            Gerações=1;
            //inicializa um gabarito para saber qual o objetivo do algoritmo 
            gabarito = new int[50] { 13, 20, 11, 16, 15, 1, 4, 12, 17, 3, 20, 12, 1, 1, 18, 8, 12, 20, 8, 1, 9, 1, 8, 7, 19, 8, 1, 7, 1, 11, 7, 2, 13, 14, 11, 16, 14, 15, 17, 17, 12, 17, 19, 14, 15, 9, 14, 4, 11, 16 };

            // Dicionario de dados para representar os índices.
            maxGenerations = generations;
            Aminoacidos.Add(1, "A");
            Aminoacidos.Add(2, "R");
            Aminoacidos.Add(3, "N");
            Aminoacidos.Add(4, "D");
            Aminoacidos.Add(5, "C");
            Aminoacidos.Add(6, "Q");
            Aminoacidos.Add(7, "E");
            Aminoacidos.Add(8, "G");
            Aminoacidos.Add(9, "H");
            Aminoacidos.Add(10, "I");
            Aminoacidos.Add(11, "L");
            Aminoacidos.Add(12, "K");
            Aminoacidos.Add(13, "M");
            Aminoacidos.Add(14, "F");
            Aminoacidos.Add(15, "P");
            Aminoacidos.Add(16, "S");
            Aminoacidos.Add(17, "T");
            Aminoacidos.Add(18, "W");
            Aminoacidos.Add(19, "Y");
            Aminoacidos.Add(20, "V");
        }
        /* Metodo que inicia a população */
        public void startPopulation()
        {
            // For que inicializa todos os individuos da população e calcula o fitness inicial de cadas individuo.
            for (int i = 0; i < population.Length; i++)
            {
                population[i] = new Individuo(i);
                NewPopulation[i] = new Individuo(i);
                FitnesCalc(population[i]);
            }
        }
        // metodo utilizada para o calculo do fitness de cada individuo.
        public void FitnesCalc(Individuo x)
        {
            double posiçõesCorretas = 0.0;
            double resultado = 0.0;
            for (int i = 0; i < gabarito.Length; i++)
            {
                if (gabarito[i] == x.getGeneAt(i))
                    posiçõesCorretas++;
            }
            if (posiçõesCorretas == 0)
                resultado = 0.0;
            else
                resultado = (posiçõesCorretas - 1.0) / (gabarito.Length - 1);
            x.setFitness(resultado);
        }


        /* Metodo responsavel por inicializar as operações do algoritmo. */
        public void Begin()
        {
            this.startPopulation();
            while (stopSolver != true)
            {
                if (maxGenerations == 0)
                {
                    StarCrossOver();
                    AtualizaNovaGeração();
                    Gerações++;
                    imprimirMelhorindividuo();
                    VerificaParada();
                    
                }
                else if (Gerações <= maxGenerations)
                {
                    StarCrossOver();
                    AtualizaNovaGeração();
                    Gerações++;
                }
                else
                {
                    stopSolver = true;
                }
                Form activeForm = Application.OpenForms["TelaInicial"];
                ((Label)activeForm.Controls["GenerationNumber"]).Text = Gerações.ToString();
            }
        }


        /* Metodo que realiza a seleção de individuos utilizando o metodo da roleta. 
           Com base no Fitness dos individuos, Seleciona os através de uma função de seleção os individuos para o cruzamento
        */
        public Individuo SelectRollet(double x)
        {
            double SomaFitnessSorteio = 0.0;
            double ResultRamdom = 0.0;
            double somaFitnesPopulation = x;
            bool Find = false;
            Random RandomNumber = new Random();
            int i = 0;
            int j = 0;
            ResultRamdom = RandomNumber.NextDouble();
            ResultRamdom = ResultRamdom * somaFitnesPopulation;

            while (Find == false && j < population.Length)
            {
                SomaFitnessSorteio += population[j].getFitness();
                if (SomaFitnessSorteio >= ResultRamdom && population[j].verificaSeleção()== false)
                {
                    i = j;
                    Find = true; 
                }
                j++;
            }
            population[i].setSelecionadoCruzamento();
            return population[i];

        }

        /* Metodo que executa o cruzamento dos individuos da minha população*/
        public void StarCrossOver()
        {
            int TradePosition;
            int i = 0;
            Individuo Pai1;
            Individuo Pai2;
            Individuo filho = new Individuo(0);
            double S = 0.0;
            bool newPopulationFull = false;
            foreach (var item in population)
            {
                S += item.getFitness();
            }
            while (newPopulationFull == false)
            {
                Pai1 = SelectRollet(S);
                Pai2 = SelectRollet(S);

                if (crossOverRate <= Random.NextDouble())
                {
                    TradePosition = Random.Next(0, Pai1.returnTamanhoIndividuo() - 1);

                    filho = CopiarGenes(Pai1, Pai2, filho, TradePosition);

                    if (mutationRate <= Random.NextDouble())
                    {
                        filho = MutationGene(filho);
                    }
                    FitnesCalc(filho);
                    if (i < population.Length)
                    {
                        filho.setID(i);
                        NewPopulation[i] = new Individuo(filho);
                        i++;
                    }
                    else
                        newPopulationFull = true;
                }
                Pai1.setLivreCruzamento();
                Pai2.setLivreCruzamento();
            }
        }

        /* Metodo que realiza a mutação de um gene no individuo especifico*/
        public Individuo MutationGene(Individuo x)
        {
            x.setGeneAt(Random.Next(1, 20), Random.Next(0, x.returnTamanhoIndividuo() - 1));
            return x;
        }

        /* Metodo que copia os genes que serão transmitidos para os individuos filhos do cruzamento*/
        public Individuo CopiarGenes(Individuo pai1, Individuo pai2, Individuo filho, int tradePosition)
        {
            int x = 0;
            while (x < pai1.returnTamanhoIndividuo())
            {
                if (x <= tradePosition)
                {
                    filho.setGeneAt(pai1.getGeneAt(x), x);
                }
                else
                {
                    filho.setGeneAt(pai2.getGeneAt(x), x);
                }
                x++;
            }
            return filho;
        }

        /*Metodo para atualizar a nova geração de individuos com os novos individuos gerados*/
        public void AtualizaNovaGeração()
        {
            for (int i = 0; i < population.Length; i++)
            {
                population[i] = new Individuo(NewPopulation[i]);
            }
        }

        /* Metodo que imprimir os individuos do meu algoritmo*/
        public void imprimirMelhorindividuo()
        {
            string linhaLista = "";
            population.OrderBy(x => x.getFitness());
            Individuo aux = population[0];
            for (int i = 0; i < aux.returnTamanhoIndividuo(); i++)
            {
                int gene = aux.getGeneAt(i);
                linhaLista = String.Concat(linhaLista,Aminoacidos[gene]);
            }
            linhaLista = String.Concat(linhaLista, "-- " + aux.getFitness().ToString());
            Form activeForm = Application.OpenForms["TelaInicial"];
            ((ListBox)activeForm.Controls["listaMelhorIndividuo"]).Items.Add(linhaLista);
        }

        /* Metodo que verifica a parada do meu algoritmo */
        public void VerificaParada()
        {
                  
            Individuo teste = population.OrderByDescending(x=>x.getFitness()).First();            
            if (teste.getFitness() == 1)
            {
                stopSolver = true;
            }
        }

    }
}
