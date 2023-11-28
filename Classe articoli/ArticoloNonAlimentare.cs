using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe_articoli
{
    public class ArticoloNonAlimentare : Articolo
    {
        private bool _materialericiclabile;

        public ArticoloNonAlimentare(string codice, string descrizione, double prezzo, bool riciclabile) : base(codice, descrizione, prezzo)
        {
            Riciclabile = riciclabile;
        }

        public bool Riciclabile { get; set; }
        public override bool Equals(object obj)
        {
	        if (obj == null || GetType() != obj.GetType())
	        {
		        return false;
	        }
	        ArticoloNonAlimentare other = (ArticoloNonAlimentare)obj;

	        if (base.Equals(other) && Riciclabile == other.Riciclabile)
	        {
		        return true;
	        }
	        return false;
        }
		public override double Sconto(bool cartaFedelta)
        {
            if (cartaFedelta && Riciclabile)
                ImportoScontato = Prezzo * 0.85;
            else if (Riciclabile)
                ImportoScontato = Prezzo * 0.90;
            else
                base.Sconto(cartaFedelta);
            return ImportoScontato;
        }
        public override string[] newToString()
        {
            return new string[] { Codice, Descrizione, Prezzo.ToString("F") + "€", "-", (Riciclabile == true) ? "Sì" : "No", "-", ImportoScontato.ToString("F") + "€" };
        }
    }
}
