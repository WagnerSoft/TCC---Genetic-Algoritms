using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgorithm
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            int w;
            double x, y;
            w =Convert.ToInt32( QuantidadeIndividuos.Text.Trim());
            x =Convert.ToDouble(TaxaCruzamento.Text.Trim());
            y =Convert.ToDouble( TaxaMutacao.Text.Trim());

            GeneticSolver inicio = new GeneticSolver(w, x, y, 0 );
            inicio.Begin();
        }
    }
}
