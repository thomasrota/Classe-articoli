using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

		public FormAdd()
		{
			InitializeComponent();
			InitializeListView();
			dim = 0;
		}

		private void buttonAggiungi_Click(object sender, EventArgs e)
		{
			Articolo[] articoli = new Articolo[100];
			Articolo nuovoArticolo = CreaArticolo(Selection());
			articoli[dim] = nuovoArticolo;
			Visualizza(articoli);
			dim++;
			ClearRadioButtons();
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

		private void Visualizza(Articolo[] array)
		{
			ListViewItem newItem = new ListViewItem();
			newItem.Text = array[dim].Codice;
			newItem.SubItems.Add(array[dim].Descrizione);
			newItem.SubItems.Add(array[dim].Prezzo.ToString());
			newItem.SubItems.Add(GetTipoArticolo(array[dim]));
			listViewArticoli.Items.Add(newItem);
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

		private void UpdateUI()
		{
			if (radioButtonAlimentare.Checked)
			{
				labelCons.Visible = false;
				textBoxGCons.Visible = false;
				labelAnnoScadenza.Visible = true;
				textBoxAnnoScadenza.Visible = true;
			}

			if (radioButtonAlimentareFresco.Checked)
			{
				labelAnnoScadenza.Visible = false;
				textBoxAnnoScadenza.Visible = false;
				labelCons.Visible = true;
				textBoxGCons.Visible = true;
			}
		}

		private void InitializeListView()
		{
			listViewArticoli.View = View.Details;
			listViewArticoli.GridLines = true;
			listViewArticoli.Columns.Add("Codice", 100);
			listViewArticoli.Columns.Add("Descrizione", 150);
			listViewArticoli.Columns.Add("Prezzo", 100);
			listViewArticoli.Columns.Add("Tipo", 150);
		}
	}
}
