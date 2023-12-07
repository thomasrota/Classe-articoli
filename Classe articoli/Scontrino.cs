using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Classe_articoli
{
    public class Scontrino
    {
        private Articolo[] _articolos;
        
        public Articolo[] Articolos
        {
            get { return _articolos; }
            set { _articolos = value; }
        }

        public Scontrino()
        {
            Articolos = new Articolo[0];
        }

        public Scontrino(Articolo[] articoli)
        {
            Articolos = articoli;
        }
        public void Aggiunta(int dim, Articolo nuovoArticolo)
        {
            if (dim < 100)
                Articolos[dim] = nuovoArticolo;
            else
                new ArgumentOutOfRangeException("dim", "Dimensione massima raggiunta");
        }
        public double Totale(bool fidelityCard)
        {
            double[] prices = new double[Articolos.Length]; 
            double tot = 0;
            for (int i = 0;i < Articolos.Length; i++)
            {
                prices[i] = Articolos[i].Sconto(fidelityCard);
                tot += prices[i];
            }
            return tot;
        }
        public override string ToString()
        {
            string s = string.Empty;
            for (int i = 0; i < Articolos.Length; i++)
            {
                s = Articolos[i].ToString() + '\n';
            }
            return s;
        }
    }
}
