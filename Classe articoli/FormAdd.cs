using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
		public Scontrino scontrino;
		public string path;
		public FormAdd()
		{
			InitializeComponent();
			InitializeListView();
			articoli = new Articolo[100];
			scontrino = new Scontrino(articoli);
			dim = 0;
			buttonCalc.Enabled = true;
            ToolTip toolTip1 = new ToolTip();
			toolTip1.ShowAlways = true;
			toolTip1.SetToolTip(buttonCalc, "Calcola totale. Tasto cliccabile solamente una volta.");
			path = @"scontrino.txt";
		}

        private void buttonAggiungi_Click(object sender, EventArgs e)
		{
			Articolo nuovoArticolo = CreaArticolo(Selection());
			if (CheckInputLengths(textBoxCodice.Text) == 1)
			{
				if (RicercaArticolo(textBoxCodice.Text) == -1)
				{
					scontrino.Aggiunta(dim, nuovoArticolo);
					Visualizza();
					dim++;
					ClearRadioButtons();
					RemoveAddedTextboxes();
					UpdateInputs();
				}
				else
					MessageBox.Show("Articolo già presente", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
				MessageBox.Show("La lunghezza del codice deve essere di 4 caratteri", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
			Thread.Sleep(1000);
			var sort = MessageBox.Show("Vuoi ordinare lo scontrino per ordine di prezzo?", "Ordinamento",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (sort == DialogResult.Yes)
			{
				Sort(true);
				Visualizza();
			}
			Thread.Sleep(500);
			var result = MessageBox.Show("Ha la carta fedeltà?", "Fidelity Card",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
				fidelityCard = true;
			else
				fidelityCard = false;
			Visualizza(); 
			SalvaScontrino();
			MessageBox.Show("Scontrino salvato in \"scontrino.txt\".", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
			MessageBox.Show("Importo totale: " + scontrino.Totale(fidelityCard).ToString("F") + "€", "Spesa Totale", MessageBoxButtons.OK, MessageBoxIcon.Information);
			buttonCalc.Enabled = false;
		}

		#region Funzioni
		private void Sort( bool sYn)
		{
			int i = 0, j = 0;
			Articolo temp = null;
			while (articoli[i + 1] != null)
			{
				while (articoli[j + 1] != null)
				{
					if (articoli[j + 1].Compare(articoli[j]) == 1)
					{
						temp = articoli[j];
						articoli[j] = articoli[j + 1];
						articoli[j + 1] = temp;
					}
					j++;
				}
				j = 0;
				i++;
			}
		}

		private void SalvaScontrino()
		{
			StreamWriter sw = new StreamWriter(path);
			sw.WriteLine("Codice; Descrizione; Prezzo; Anno Scadenza; Riciclabile; Da consumarsi in (numero giorni); Importo scontato");
			foreach (Articolo articolo in articoli)
			{
				if (articolo != null)
				{
					sw.WriteLine(articolo.ToString());
				}
			}
			sw.WriteLine("\n\nTotale: " + scontrino.Totale(fidelityCard).ToString("F") + "€");
			sw.Close();
		}
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
					string[] c = (articolo.ToString().Split(';'));
					string[] row = { c[0], c[1], c[2], c[3], c[4], c[5], c[6] };
					var listViewItem = new ListViewItem(row);
					listViewArticoli.Items.Add(listViewItem);
				}
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
		private void UpdateInputs()
		{
			textBoxCodice.Text = (int.Parse(textBoxCodice.Text) < 1000) ? (int.Parse(textBoxCodice.Text) + 1).ToString("0000") : string.Empty;
			textBoxDescrizione.Text = string.Empty;
			textBoxPrezzo.Text = string.Empty;
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
		private void RemoveAddedTextboxes()
		{
			labelAnnoScadenza.Visible = false;
			textBoxAnnoScadenza.Visible = false;
			labelCons.Visible = false;
			textBoxGCons.Visible = false;
		}
        #endregion
    }
}
