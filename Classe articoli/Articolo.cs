using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classe_articoli
{
	public class Articolo
	{
		protected string _codice;
		protected string _descrizione;
		protected double _prezzo;
		protected double _importoScontato;
		public string Codice { get; set; }
		public string Descrizione { get; set; }
		public double Prezzo { get; set; }

		public double ImportoScontato { get; set; }

		public Articolo(string codice, string descrizione, double prezzo)
		{
			Codice = codice;
			Descrizione = descrizione;
			Prezzo = prezzo;
			ImportoScontato = prezzo;
		}

		public virtual double Sconto(bool cartaFedelta)
		{
			if (cartaFedelta)
				ImportoScontato = Prezzo * 0.95;
			else
				ImportoScontato = Prezzo;
			return ImportoScontato;
		}

		public virtual string[] ToString()
		{
			return new string[] { Codice, Descrizione, Prezzo.ToString("F") + "€", "-", "-", "-", ImportoScontato.ToString("F") + "€" };
		}
	}
}
