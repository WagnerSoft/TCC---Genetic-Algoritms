using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAlgoritmoGenetico
{
    //Classe Responsavel por representar a sequencia binaria que representa cada individuo
    public class Aminoacido
    {
        
        int idAminoacido;
        
        public Aminoacido(int idamino)
        {
            idAminoacido = idamino;
        }
        public int GetAminoacido()
        {
            return idAminoacido;
        }
        public void SetAminoacido(int x)
        {
            idAminoacido = x;
        }
    }
}
