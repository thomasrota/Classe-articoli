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
		public string Codice { get; set; }
		public string Descrizione { get; set; }
		public double Prezzo { get; set; }
		public double ImportoScontato { get; set; }
		public double ImportoTotale { get; set; }

		public Articolo(string codice, string descrizione, double prezzo)
		{
			Codice = codice;
			Descrizione = descrizione;
			Prezzo = prezzo;
		}

		public virtual void Sconto(bool cartaFedelta)
		{
			if (cartaFedelta)
			{
				Prezzo *= 0.95;
			}
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

		public override void Sconto(bool cartaFedelta)
		{
			if (cartaFedelta && AnnoScadenza == DateTime.Now.Year)
				Prezzo *= 0.75;
			else if (AnnoScadenza == DateTime.Now.Year)
				Prezzo *= 0.80;
			else
				base.Sconto(cartaFedelta);
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
		public override void Sconto(bool cartaFedelta)
		{
			if (cartaFedelta && Riciclabile)
				Prezzo *= 0.85;
			else if (Riciclabile)
				Prezzo *= 0.90;
			else
				base.Sconto(cartaFedelta);
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

		public override void Sconto(bool cartaFedelta)
		{
			if (cartaFedelta && ConsumazioneDopoApertura > 0)
				Prezzo *= 0.95 - (0.1 / ConsumazioneDopoApertura);
			else if (ConsumazioneDopoApertura > 0)
				Prezzo *= 0.75;
			else
				base.Sconto(cartaFedelta);
		}
	}
}
