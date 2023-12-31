﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classe_articoli
{
    public class ArticoloAlimentare : Articolo
    {
        protected int _annoScadenza;

        public ArticoloAlimentare(string codice, string descrizione, double prezzo, int scad) : base(codice, descrizione, prezzo)
        {
            AnnoScadenza = scad;
        }

        public int AnnoScadenza
        {
            get { return _annoScadenza; }
            set
            {
                if (value < DateTime.Now.Year)
                    MessageBox.Show("Anno scadenza non valido", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _annoScadenza = value;
            }
        }
        public override bool Equals(object obj)
        {
	        if (obj == null || GetType() != obj.GetType())
	        {
		        return false;
	        }
	        ArticoloAlimentare other = (ArticoloAlimentare)obj;

	        if (base.Equals(other) && AnnoScadenza == other.AnnoScadenza)
	        {
		        return true;
	        }
	        return false;
        }
		public override double Sconto(bool cartaFedelta)
        {
            if (cartaFedelta && AnnoScadenza == DateTime.Now.Year)
                ImportoScontato = Prezzo * 0.75;
            else if (AnnoScadenza == DateTime.Now.Year)
                ImportoScontato = Prezzo * 0.80;
            else
                base.Sconto(cartaFedelta);
            return ImportoScontato;
        }
        public override string ToString()
        {
			return $"{Codice}; {Descrizione}; {Prezzo.ToString("F")}€; {AnnoScadenza}; -; -; {ImportoScontato.ToString("F")}€";
		}
	}
}
