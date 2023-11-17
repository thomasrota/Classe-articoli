using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classe_articoli
{
	public partial class FormAdd : Form
	{
		public int dim;
		public bool isRiciclabile;
		public bool fidelityCard;
		public Articolo[] articoli;
		public double[] sconti;

		public FormAdd()
		{
			InitializeComponent();
			InitializeListView();
			articoli = new Articolo[100];
			sconti = new double[100];
			dim = 0;
		}

		private void buttonAggiungi_Click(object sender, EventArgs e)
		{
			if (dim < 100)
			{
				Articolo nuovoArticolo = CreaArticolo(Selection());
				if (CheckInputLengths(textBoxCodice.Text) == 1)
				{
					if (RicercaArticolo(textBoxCodice.Text) == -1)
					{
						articoli[dim] = nuovoArticolo;
						Visualizza();
						dim++;
						ClearRadioButtons();
					}
					else
						MessageBox.Show("Articolo già presente", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
					MessageBox.Show("La lunghezza del codice deve essere di 4 caratteri", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			if (dim > 100)
				MessageBox.Show("Limite massimo prodotti raggiunto", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void radioButtonAlimentare_CheckedChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void radioButtonNonAlimentare_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonNonAlimentare.Checked)
			{
				labelCons.Visible = false;
				textBoxGCons.Visible = false;
				labelAnnoScadenza.Visible = false;
				textBoxAnnoScadenza.Visible = false;
				var result = MessageBox.Show("L'articolo non alimentare è riciclabile?", "Riciclabile",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
					isRiciclabile = true;
				else
					isRiciclabile = false;
			}
		}

		private void radioButtonAlimentareFresco_CheckedChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}
		private void buttonCalc_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show("Ha la carta fedeltà?", "Fidelity Card",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
				fidelityCard = true;
			else
				fidelityCard = false;
			int cont = 0;
			double sum = 0;
			foreach (Articolo articolo in articoli)
			{
				if (articolo != null)
				{
					string[] c = articolo.ToString();
					sconti[cont] = articolo.Sconto(fidelityCard);
					cont++;
				}
			}
			Visualizza();
			for (int i = 0; i < sconti.Length; i++)
				sum += sconti[i];
			MessageBox.Show("Importo totale: " + sum.ToString("F") + "€");
		}

		#region Funzioni
		// Metodo per creare un nuovo oggetto Articolo in base al tipo specificato
		Articolo CreaArticolo(string tipo)
		{
			switch (tipo)
			{
				case "A":
					return new ArticoloAlimentare(textBoxCodice.Text, textBoxDescrizione.Text, Convert.ToDouble(textBoxPrezzo.Text), int.Parse(textBoxAnnoScadenza.Text));
				case "NA":
					return new ArticoloNonAlimentare(textBoxCodice.Text, textBoxDescrizione.Text, Convert.ToDouble(textBoxPrezzo.Text), isRiciclabile);
				case "AF":
					return new ArticoloAlimentareFresco(textBoxCodice.Text, textBoxDescrizione.Text, Convert.ToDouble(textBoxPrezzo.Text), int.Parse(textBoxGCons.Text));
				default:
					throw new ArgumentException("Tipo di articolo non valido.");
			}
		}
		private void ClearRadioButtons()
		{
			radioButtonAlimentare.Checked = false;
			radioButtonNonAlimentare.Checked = false;
			radioButtonAlimentareFresco.Checked = false;
		}
		private string Selection()
		{
			string tipo = "";
			if (radioButtonAlimentare.Checked)
				tipo = "A";
			else if (radioButtonNonAlimentare.Checked)
				tipo = "NA";
			else if (radioButtonAlimentareFresco.Checked)
				tipo = "AF";
			return tipo;
		}
		private void Visualizza()
		{
			listViewArticoli.Items.Clear();
			foreach (Articolo articolo in articoli)
			{
				if (articolo != null)
				{
					string[] c = articolo.ToString();
					string[] row = { c[0], c[1], c[2], c[3], c[4], c[5], c[6] };
					var listViewItem = new ListViewItem(row);
					listViewArticoli.Items.Add(listViewItem);
				}
			}
		}
		private string GetTipoArticolo(Articolo articolo)
		{
			if (articolo is ArticoloAlimentare && articolo is ArticoloAlimentareFresco)
			{
				return "Alimentare Fresco";
			}
			else if (articolo is ArticoloNonAlimentare)
			{
				return "Non Alimentare";
			}
			else
			{
				return "Alimentare";
			}
		}

		private int CheckInputLengths(string codice)
		{
			if (codice.Length != 4)
				return -1;
			return 1;
		}
		private int RicercaArticolo(string codice)
		{
			for (int i = 0; i < articoli.Length; i++)
			{
				if (articoli[i] != null && articoli[i].Codice == codice)
					return i;
				break;
			}
			return -1;
		}
		private void UpdateUI()
		{
			if (radioButtonAlimentare.Checked)
			{
				textBoxAnnoScadenza.Enabled = true;
				textBoxAnnoScadenza.Text = string.Empty;
				labelCons.Visible = false;
				textBoxGCons.Visible = false;
				labelAnnoScadenza.Visible = true;
				textBoxAnnoScadenza.Visible = true;
			}

			if (radioButtonAlimentareFresco.Checked)
			{
				labelAnnoScadenza.Visible = true;
				textBoxAnnoScadenza.Visible = true;
				textBoxAnnoScadenza.Text = DateTime.Now.Year.ToString();
				textBoxAnnoScadenza.Enabled = false;
				labelCons.Visible = true;
				textBoxGCons.Visible = true;
			}
		}
		private void InitializeListView()
		{
			listViewArticoli.View = View.Details;
			listViewArticoli.GridLines = true;
			listViewArticoli.Columns.Add("Codice", 100);
			listViewArticoli.Columns.Add("Descrizione", 100);
			listViewArticoli.Columns.Add("Prezzo", 100);
			listViewArticoli.Columns.Add("Anno Scadenza", 100);
			listViewArticoli.Columns.Add("Riciclabile", 100);
			listViewArticoli.Columns.Add("Da consumarsi in (numero giorni)", 100);
			listViewArticoli.Columns.Add("Importo scontato", 100);
		}
		#endregion
	}
}
