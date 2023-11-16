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
		protected string codice;
		protected string descrizione;
		protected double prezzo;
		protected double importoScontato;
		public string Codice { get; set; }
		public string Descrizione { get; set; }
		public double Prezzo { get; set; }

		public double ImportoScontato { get; set; }

		public Articolo(string codice, string descrizione, double prezzo)
		{
			Codice = codice;
			Descrizione = descrizione;
			Prezzo = prezzo;
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
			return new string[] { Codice, Descrizione, Prezzo.ToString(), "-", "-", "-", ImportoScontato.ToString() };
		}
	}

	public class ArticoloAlimentare : Articolo
	{
		protected int annoScadenza;

		public ArticoloAlimentare(string codice, string descrizione, double prezzo, int scad) : base(codice, descrizione, prezzo)
		{
			AnnoScadenza = scad;
		}

		public int AnnoScadenza
		{
			get { return annoScadenza; }
			set
			{
				if (value < DateTime.Now.Year)
					throw new Exception("Anno scadenza non valido");
				annoScadenza = value;
			}
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
		public override string[] ToString()
		{
			return new string[] { Codice, Descrizione, Prezzo.ToString(), AnnoScadenza.ToString(), "-", "-", ImportoScontato.ToString() };
		}
	}

	public class ArticoloNonAlimentare : Articolo
	{
		private bool materialericiclabile;

		public ArticoloNonAlimentare(string codice, string descrizione, double prezzo, bool riciclabile) : base(codice, descrizione, prezzo)
		{
			Riciclabile = riciclabile;
		}

		public bool Riciclabile { get; set; }
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
		public override string[] ToString()
		{
			return new string[] { Codice, Descrizione, Prezzo.ToString(), "-", (Riciclabile == true) ? "Sì" : "No", "-", ImportoScontato.ToString() };
		}
	}

	public class ArticoloAlimentareFresco : ArticoloAlimentare
	{
		private int consumazioneDopoApertura;

		public ArticoloAlimentareFresco (string codice, string descrizione, double prezzo, int consum) : base(codice, descrizione, prezzo, DateTime.Now.Year)
		{
			ConsumazioneDopoApertura = consum;
		}

		public int ConsumazioneDopoApertura
		{
			get { return consumazioneDopoApertura; }
			set
			{
				if (value <= 5)
					consumazioneDopoApertura = value;
				else
					throw new Exception("Consumazione dopo apertura non valida");
			}
		}

		public override double Sconto(bool cartaFedelta)
		{
			if (cartaFedelta && ConsumazioneDopoApertura > 0)
				ImportoScontato = Prezzo * 0.95 - (0.1 / ConsumazioneDopoApertura);
			else if (ConsumazioneDopoApertura > 0)
				ImportoScontato = Prezzo * 0.75;
			else
				base.Sconto(cartaFedelta);
			return ImportoScontato;
		}
		public override string[] ToString()
		{
			return new string[] { Codice, Descrizione, Prezzo.ToString(), AnnoScadenza.ToString(), "-", ConsumazioneDopoApertura.ToString(), ImportoScontato.ToString() };
		}
	}
}
