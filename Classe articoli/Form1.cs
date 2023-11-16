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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			CloseFormsInput();
			OpenFormInput<FormAdd>();
		}

		// Funzione per aprire un form in un pannello
		private void OpenFormInput<MyForm>() where MyForm : Form, new()
		{
			Form FormInput;
			FormInput = panelContent.Controls.OfType<MyForm>().FirstOrDefault();
			if (FormInput == null)
			{
				FormInput = new MyForm();
				FormInput.TopLevel = false;
				FormInput.FormBorderStyle = FormBorderStyle.None;
				FormInput.Dock = DockStyle.Fill;
				panelContent.Controls.Add(FormInput);
				panelContent.Tag = FormInput;
				FormInput.Show();
				FormInput.BringToFront();
			}
			else
			{
				FormInput.BringToFront();
			}
		}
		// Funzione per chiudere form nel pannello
		private void CloseFormsInput()
		{
			Form FormInput = panelContent.Controls.OfType<Form>().FirstOrDefault();
			if (FormInput != null)
			{
				FormInput.Close();
			}
		}
	}
}
