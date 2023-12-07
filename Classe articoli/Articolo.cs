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
		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			Articolo other = (Articolo)obj;

			if (Codice == other.Codice && Descrizione == other.Descrizione && Prezzo == other.Prezzo)
			{
				return true;
			}
			return false;
		}
		public virtual double Sconto(bool cartaFedelta)
		{
			if (cartaFedelta)
				ImportoScontato = Prezzo * 0.95;
			else
				ImportoScontato = Prezzo;
			return ImportoScontato;
		}
		public int Compare(Articolo other)
		{
			int ret = 0;

			if (Prezzo > other.Prezzo)
			{
				ret = 1;
			}
			else if (Prezzo < other.Prezzo)
			{
				ret = -1;
			}

			return ret;
		}
		public override string ToString()
		{
			return $"{Codice}; {Descrizione}; {Prezzo.ToString("F")}€; -; -; -; {ImportoScontato.ToString("F")}€";
		}
	}
}
