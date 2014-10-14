using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TesteAlgoritmoGenetico
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
        Random Random;
        string MELHOR="";
        double FITNESSMELHOR = -1.0;
        List<int> gabarito;
        int Gerações;
        int[] Quartis = new int[4]{0,0,0,0};
        Dictionary<int, string> Dicionario = new Dictionary<int, string>();

        
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
            gabarito = new List<int> { 14,20,12,16,15,1,4,13,18,3,20,13,1,1,19,7,13,20,7,1,10,1,7,8,17,7,1,8,1,12,8,2,14,6,12,16,6,15,
                                      18,18,13,18,17,6,15,10,6,4,12,16,10,7,16,1,9,20,13,7,10,7,13,13,20,1,4,1,12,18,3,1,20,1,10,20,4,4,
                                      14,15,3,1,12,16,1,12,16,4,12,10,1,10,13,12,2,20,4,15,20,3,6,13,12,12,16,10,5,12,12,20,18,12,1,1,10,12,
                                      15,1,8,6,18,15,1,20,10,1,16,12,4,13,6,12,1,16,20,16,18,20,12,18,16,13,17,2 };

            // Dicionario de dados para representar os índices.
            Dicionario.Add(1, "A");
            Dicionario.Add(2, "R");
            Dicionario.Add(3, "N");
            Dicionario.Add(4, "D");
            Dicionario.Add(5, "C");
            Dicionario.Add(6, "F");
            Dicionario.Add(7, "G");
            Dicionario.Add(8, "E");
            Dicionario.Add(9, "Q");
            Dicionario.Add(10, "H");
            Dicionario.Add(11, "I");
            Dicionario.Add(12, "L");
            Dicionario.Add(13, "K");
            Dicionario.Add(14, "M");
            Dicionario.Add(15, "P");
            Dicionario.Add(16, "S");
            Dicionario.Add(17, "Y");
            Dicionario.Add(18, "T");
            Dicionario.Add(19, "W");
            Dicionario.Add(20, "V");


            maxGenerations = generations;

        }
   
        public void startPopulation()
        {
            // For que inicializa todos os individuos da população e calcula o fitness inicial de cadas individuo.
            for (int i = 0; i < population.Length; i++)
            {
                population[i] = new Individuo();
                NewPopulation[i] = new Individuo();
                FitnesCalc(population[i]);
            }
        }



        public void FitnesCalc(Individuo x)
        {
            double PonderaFitnessAlvo = (100.0 / this.gabarito.Count) / 100;
            int PCorretas = GetposiçõesCorretas(x);
            double PorcentagemPosições  = ((Convert.ToDouble(PCorretas) * 100) / x.returnTamanhoIndividuo())/100;
            double Diferencial = 1 - PorcentagemPosições;
            double resultado = 0.0;
            resultado = (PorcentagemPosições * PonderaFitnessAlvo)*PCorretas;

            //for (int i = 0; i < gabarito.Length; i++)
            //{
            //    if (i < x.returnTamanhoIndividuo())
            //    {
            //        if (gabarito[i] == x.getGeneAt(i))
            //            posiçõesCorretas++;
            //    }
            //}
            //if (posiçõesCorretas == 0)
            //    resultado = 0.0;
            //else
            //    resultado = (posiçõesCorretas - 1.0) / (gabarito.Length - 1);

            x.setDiferencial(Diferencial);
            x.setFitness(resultado);
        }
        public int GetposiçõesCorretas(Individuo x)
        {
            int indexTeste = 0;
            int MaxPosCorretas = 0;
            int ContagemAux = 0;

            while (indexTeste < x.returnTamanhoIndividuo())
            {
                    List<int> IndexOco = GetIndexOcorrencias(x.getGeneAt(indexTeste));
                    if (IndexOco.Count != 0)
                    {
                        foreach (var item in IndexOco)
                        {
                            if ((gabarito.Count- item ) > (x.returnTamanhoIndividuo() - indexTeste))
                            {
                                for (int j = item, k = indexTeste; k < x.returnTamanhoIndividuo(); j++, k++)
                                {
                                    if (gabarito.ElementAt(j).Equals(x.getGeneAt(k)))
                                        ContagemAux++;
                                }
                            }
                            else
                            {
                                for (int j = item, k = indexTeste; j < gabarito.Count; j++, k++)
                                {
                                    if (gabarito.ElementAt(j).Equals(x.getGeneAt(k)))
                                        ContagemAux++;
                                }
                            }
                            if (ContagemAux > MaxPosCorretas)
                                MaxPosCorretas = ContagemAux;
                            ContagemAux = 0;
                        }
                    }
                    
                indexTeste++;
                ContagemAux = 0;
            }
            return MaxPosCorretas;
        }
        public List<int> GetIndexOcorrencias(int teste)
        {
            List<int> pos = new List<int>();

            for (int i = 0; i < gabarito.Count; i++)
		    {
                if (gabarito.ElementAt(i).Equals(teste))
                    pos.Add(i);
            }
            return pos;
        }




        
        public void Begin()
        {
            this.startPopulation();
            while (stopSolver != true)
            {
                if (maxGenerations == 0)
                {
                    StarCrossOver();
                    AtualizaNovaGeração();
                    AtualizaQuartis();
                    Gerações++;
                    imprimirMelhorindividuo();
                    VerificaParada();
                    InsereImigrantes();
                    
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
            }
            Console.ReadLine();
        }
        
        public Individuo SelectIndividuo(double x)
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
                SomaFitnessSorteio += population[j].getRank();
                if (SomaFitnessSorteio >= ResultRamdom && population[j].verificaSeleção() == false)
                {
                    i = j;
                    Find = true;
                }
                j++;
            }
            population[i].setSelecionadoCruzamento();
            return population[i];

        }
        public void GerarRank()
        {
            double min = 0.9;
            double max = 1.1;

            population.OrderBy(x => x.getFitness());
            for (int i = 0; i < population.Length; i++)
            {
                population[i].setRank( Convert.ToDouble(min+((max-min)*(i/population.Length-1))));
            }
        }

        public void StarCrossOver()
        {
            int i = 0;
            Individuo Pai1;
            Individuo Pai2;
            Individuo filho = new Individuo();
            double S = 0.0;
            bool newPopulationFull = false;
            this.GerarRank();
            foreach (var item in population)
            {
                S += item.getRank();
            }

            while (i < 2)
            {
                NewPopulation[i] = new Individuo(population.OrderByDescending(x => x.getFitness()).ElementAt(i));
                i++;
            }
            //for (int j = 0; j < 50; j++)
            //{
            //    NewPopulation[i] = new Individuo();
            //    FitnesCalc(NewPopulation[i]);
            //    i++;
            //}

            while (newPopulationFull == false)
            {

                Pai1 = SelectIndividuo(S);
                Pai2 = SelectIndividuo(S);

                if (crossOverRate <= Random.NextDouble())
                {
                    filho = CopiarGenes(Pai1, Pai2, filho);

                    if (Random.NextDouble() <= mutationRate)
                    {
                        filho = MutationGene(filho);
                    }
                    FitnesCalc(filho);
                    if (i < population.Length)
                    {
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

        public Individuo MutationGene(Individuo x)
        {
            x.setGeneAt(Random.Next(1, 20), Random.Next(0, x.returnTamanhoIndividuo() - 1));
            return x;
        }
        
        public Individuo CopiarGenes(Individuo pai1, Individuo pai2, Individuo filho)
        {
            filho.getlistaAmino().Clear();
            foreach (var item in pai1.getlistaAmino())
            {
                filho.getlistaAmino().Add(item);
            }
            foreach (var item in pai2.getlistaAmino())
            {
                filho.getlistaAmino().Add(item);
            }

            return filho;
            // CrossOver de um ponto 
            //int x = 0;
            //while (x < pai1.returnTamanhoIndividuo())
            //{
            //    if (x <= tradePosition)
            //    {
            //        filho.setGeneAt(pai1.getGeneAt(x), x);
            //    }
            //    else
            //    {
            //        filho.setGeneAt(pai2.getGeneAt(x), x);
            //    }
            //    x++;
            //}

            //CrossOver uniforme de varios pontos
            //for (int i = 0; i < pai1.returnTamanhoIndividuo(); i++)
            //{
            //    if (Random.NextDouble() >= 0.5)
            //    {
            //        filho.setGeneAt(pai1.getGeneAt(i), i);
            //    }
            //    else
            //    {
            //        filho.setGeneAt(pai2.getGeneAt(i), i);
            //    }
            //}
            
        }

        public void AtualizaNovaGeração()
        {
            for (int i = 0; i < population.Length; i++)
            {
                population[i] = new Individuo(NewPopulation[i]);
            }
        }

        public void InsereImigrantes()
        {
            
            for (int i = 0; i < population.Length; i++)
			{

                if (population[i].getDiferencial() > 0.60)
                {
                    population[i] = new Individuo();
                    FitnesCalc(population[i]);
                }
            }
        }

        public void imprimirMelhorindividuo()
        {
            string tamanhoMaiorIndividuo = "";
            string linhaLista = "";
            population.OrderBy(x => x.getFitness());
            Individuo aux = population[0];
            tamanhoMaiorIndividuo = population.Max(x => x.getlistaAmino().Count).ToString();

            linhaLista = String.Concat((aux.getFitness() * 100.0).ToString(), '%');

            if (population[0].getFitness() > FITNESSMELHOR)
            {
                FITNESSMELHOR = population[0].getFitness();
                MELHOR = linhaLista;
            }
            Console.Clear();
            //Console.WriteLine(linhaLista);
            Console.WriteLine(MELHOR);
            Console.WriteLine("Tamanho do maior individuo: " + tamanhoMaiorIndividuo);
            Console.WriteLine(Gerações.ToString());
            Console.WriteLine("0% - 25% = {0}",Quartis[0]);
            Console.WriteLine("25% - 50% = {0}", Quartis[1]);
            Console.WriteLine("50% - 75% = {0}", Quartis[2]);
            Console.WriteLine("75% - 100% = {0}", Quartis[3]);

        }

        public void VerificaParada()
        {
                  
            Individuo teste = population.OrderByDescending(x=>x.getFitness()).First();            
            if (teste.getFitness() == 1)
            {
                stopSolver = true;
            }
        }

        public void AtualizaQuartis()
        {
            int q1 = 0, q2 = 0, q3 = 0, q4 = 0;
            foreach (var item in population)
            {
                if (item.getFitness() <= 0.25)
                {
                    q1++;
                }
                 if (item.getFitness() <= 0.50 && item.getFitness() > 0.25)
                {
                    q2++;
                }
                 if (item.getFitness() <= 0.75 && item.getFitness()> 0.50)
                 {
                     q3++;
                 }
                 if (item.getFitness() > 0.75)
                 {
                     q4++;
                 }
            }
            Quartis[0] = q1;
            Quartis[1] = q2;
            Quartis[2] = q3;
            Quartis[3] = q4;
        }

    }
}
