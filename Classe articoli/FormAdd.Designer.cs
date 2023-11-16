namespace Classe_articoli
{
	partial class FormAdd
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panelTitleAdd = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.radioButtonAlimentare = new System.Windows.Forms.RadioButton();
			this.radioButtonNonAlimentare = new System.Windows.Forms.RadioButton();
			this.radioButtonAlimentareFresco = new System.Windows.Forms.RadioButton();
			this.textBoxCodice = new System.Windows.Forms.TextBox();
			this.textBoxDescrizione = new System.Windows.Forms.TextBox();
			this.textBoxPrezzo = new System.Windows.Forms.TextBox();
			this.listViewArticoli = new System.Windows.Forms.ListView();
			this.buttonAggiungi = new System.Windows.Forms.Button();
			this.labelProdType = new System.Windows.Forms.Label();
			this.labelCodiceProd = new System.Windows.Forms.Label();
			this.labelDescProd = new System.Windows.Forms.Label();
			this.labelPriceProd = new System.Windows.Forms.Label();
			this.labelAnnoScadenza = new System.Windows.Forms.Label();
			this.textBoxAnnoScadenza = new System.Windows.Forms.TextBox();
			this.labelCons = new System.Windows.Forms.Label();
			this.textBoxGCons = new System.Windows.Forms.TextBox();
			this.panelTitleAdd.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelTitleAdd
			// 
			this.panelTitleAdd.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.panelTitleAdd.Controls.Add(this.label1);
			this.panelTitleAdd.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTitleAdd.Location = new System.Drawing.Point(0, 0);
			this.panelTitleAdd.Name = "panelTitleAdd";
			this.panelTitleAdd.Size = new System.Drawing.Size(946, 91);
			this.panelTitleAdd.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Century", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(360, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(253, 33);
			this.label1.TabIndex = 0;
			this.label1.Text = "Aggiungi Articoli";
			// 
			// radioButtonAlimentare
			// 
			this.radioButtonAlimentare.AutoSize = true;
			this.radioButtonAlimentare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonAlimentare.Location = new System.Drawing.Point(355, 171);
			this.radioButtonAlimentare.Name = "radioButtonAlimentare";
			this.radioButtonAlimentare.Size = new System.Drawing.Size(116, 26);
			this.radioButtonAlimentare.TabIndex = 1;
			this.radioButtonAlimentare.TabStop = true;
			this.radioButtonAlimentare.Text = "Alimentare";
			this.radioButtonAlimentare.UseVisualStyleBackColor = true;
			this.radioButtonAlimentare.CheckedChanged += new System.EventHandler(this.radioButtonAlimentare_CheckedChanged);
			// 
			// radioButtonNonAlimentare
			// 
			this.radioButtonNonAlimentare.AutoSize = true;
			this.radioButtonNonAlimentare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonNonAlimentare.Location = new System.Drawing.Point(355, 203);
			this.radioButtonNonAlimentare.Name = "radioButtonNonAlimentare";
			this.radioButtonNonAlimentare.Size = new System.Drawing.Size(154, 26);
			this.radioButtonNonAlimentare.TabIndex = 2;
			this.radioButtonNonAlimentare.TabStop = true;
			this.radioButtonNonAlimentare.Text = "Non Alimentare";
			this.radioButtonNonAlimentare.UseVisualStyleBackColor = true;
			this.radioButtonNonAlimentare.CheckedChanged += new System.EventHandler(this.radioButtonNonAlimentare_CheckedChanged);
			// 
			// radioButtonAlimentareFresco
			// 
			this.radioButtonAlimentareFresco.AutoSize = true;
			this.radioButtonAlimentareFresco.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButtonAlimentareFresco.Location = new System.Drawing.Point(355, 235);
			this.radioButtonAlimentareFresco.Name = "radioButtonAlimentareFresco";
			this.radioButtonAlimentareFresco.Size = new System.Drawing.Size(176, 26);
			this.radioButtonAlimentareFresco.TabIndex = 3;
			this.radioButtonAlimentareFresco.TabStop = true;
			this.radioButtonAlimentareFresco.Text = "Alimentare Fresco";
			this.radioButtonAlimentareFresco.UseVisualStyleBackColor = true;
			this.radioButtonAlimentareFresco.CheckedChanged += new System.EventHandler(this.radioButtonAlimentareFresco_CheckedChanged);
			// 
			// textBoxCodice
			// 
			this.textBoxCodice.Location = new System.Drawing.Point(41, 171);
			this.textBoxCodice.Name = "textBoxCodice";
			this.textBoxCodice.Size = new System.Drawing.Size(196, 22);
			this.textBoxCodice.TabIndex = 4;
			// 
			// textBoxDescrizione
			// 
			this.textBoxDescrizione.Location = new System.Drawing.Point(41, 278);
			this.textBoxDescrizione.Name = "textBoxDescrizione";
			this.textBoxDescrizione.Size = new System.Drawing.Size(251, 22);
			this.textBoxDescrizione.TabIndex = 5;
			// 
			// textBoxPrezzo
			// 
			this.textBoxPrezzo.Location = new System.Drawing.Point(41, 375);
			this.textBoxPrezzo.Name = "textBoxPrezzo";
			this.textBoxPrezzo.Size = new System.Drawing.Size(251, 22);
			this.textBoxPrezzo.TabIndex = 6;
			// 
			// listViewArticoli
			// 
			this.listViewArticoli.HideSelection = false;
			this.listViewArticoli.Location = new System.Drawing.Point(666, 125);
			this.listViewArticoli.Name = "listViewArticoli";
			this.listViewArticoli.Size = new System.Drawing.Size(280, 320);
			this.listViewArticoli.TabIndex = 7;
			this.listViewArticoli.UseCompatibleStateImageBehavior = false;
			this.listViewArticoli.View = System.Windows.Forms.View.List;
			// 
			// buttonAggiungi
			// 
			this.buttonAggiungi.BackColor = System.Drawing.SystemColors.ControlLight;
			this.buttonAggiungi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.buttonAggiungi.Font = new System.Drawing.Font("Century", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonAggiungi.Location = new System.Drawing.Point(12, 474);
			this.buttonAggiungi.Name = "buttonAggiungi";
			this.buttonAggiungi.Size = new System.Drawing.Size(934, 91);
			this.buttonAggiungi.TabIndex = 8;
			this.buttonAggiungi.Text = "Aggiungi";
			this.buttonAggiungi.UseVisualStyleBackColor = false;
			this.buttonAggiungi.Click += new System.EventHandler(this.buttonAggiungi_Click);
			// 
			// labelProdType
			// 
			this.labelProdType.AutoSize = true;
			this.labelProdType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelProdType.Location = new System.Drawing.Point(350, 125);
			this.labelProdType.Name = "labelProdType";
			this.labelProdType.Size = new System.Drawing.Size(201, 29);
			this.labelProdType.TabIndex = 9;
			this.labelProdType.Text = "Tipo di prodotto";
			// 
			// labelCodiceProd
			// 
			this.labelCodiceProd.AutoSize = true;
			this.labelCodiceProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCodiceProd.Location = new System.Drawing.Point(36, 125);
			this.labelCodiceProd.Name = "labelCodiceProd";
			this.labelCodiceProd.Size = new System.Drawing.Size(201, 29);
			this.labelCodiceProd.TabIndex = 10;
			this.labelCodiceProd.Text = "Codice prodotto";
			// 
			// labelDescProd
			// 
			this.labelDescProd.AutoSize = true;
			this.labelDescProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelDescProd.Location = new System.Drawing.Point(36, 232);
			this.labelDescProd.Name = "labelDescProd";
			this.labelDescProd.Size = new System.Drawing.Size(256, 29);
			this.labelDescProd.TabIndex = 11;
			this.labelDescProd.Text = "Descrizione prodotto";
			// 
			// labelPriceProd
			// 
			this.labelPriceProd.AutoSize = true;
			this.labelPriceProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPriceProd.Location = new System.Drawing.Point(36, 333);
			this.labelPriceProd.Name = "labelPriceProd";
			this.labelPriceProd.Size = new System.Drawing.Size(198, 29);
			this.labelPriceProd.TabIndex = 12;
			this.labelPriceProd.Text = "Prezzo prodotto";
			// 
			// labelAnnoScadenza
			// 
			this.labelAnnoScadenza.AutoSize = true;
			this.labelAnnoScadenza.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelAnnoScadenza.Location = new System.Drawing.Point(341, 333);
			this.labelAnnoScadenza.Name = "labelAnnoScadenza";
			this.labelAnnoScadenza.Size = new System.Drawing.Size(294, 29);
			this.labelAnnoScadenza.TabIndex = 14;
			this.labelAnnoScadenza.Text = "Anno scadenza prodotto";
			this.labelAnnoScadenza.Visible = false;
			// 
			// textBoxAnnoScadenza
			// 
			this.textBoxAnnoScadenza.Location = new System.Drawing.Point(346, 379);
			this.textBoxAnnoScadenza.Name = "textBoxAnnoScadenza";
			this.textBoxAnnoScadenza.Size = new System.Drawing.Size(289, 22);
			this.textBoxAnnoScadenza.TabIndex = 13;
			this.textBoxAnnoScadenza.Visible = false;
			// 
			// labelCons
			// 
			this.labelCons.AutoSize = true;
			this.labelCons.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelCons.Location = new System.Drawing.Point(341, 333);
			this.labelCons.Name = "labelCons";
			this.labelCons.Size = new System.Drawing.Size(258, 29);
			this.labelCons.TabIndex = 15;
			this.labelCons.Text = "Giorni consumazione";
			this.labelCons.Visible = false;
			// 
			// textBoxGCons
			// 
			this.textBoxGCons.Location = new System.Drawing.Point(346, 379);
			this.textBoxGCons.Name = "textBoxGCons";
			this.textBoxGCons.Size = new System.Drawing.Size(253, 22);
			this.textBoxGCons.TabIndex = 16;
			this.textBoxGCons.Visible = false;
			// 
			// FormAdd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(946, 535);
			this.Controls.Add(this.textBoxGCons);
			this.Controls.Add(this.labelCons);
			this.Controls.Add(this.labelAnnoScadenza);
			this.Controls.Add(this.textBoxAnnoScadenza);
			this.Controls.Add(this.labelPriceProd);
			this.Controls.Add(this.labelDescProd);
			this.Controls.Add(this.labelCodiceProd);
			this.Controls.Add(this.labelProdType);
			this.Controls.Add(this.buttonAggiungi);
			this.Controls.Add(this.listViewArticoli);
			this.Controls.Add(this.textBoxPrezzo);
			this.Controls.Add(this.textBoxDescrizione);
			this.Controls.Add(this.textBoxCodice);
			this.Controls.Add(this.radioButtonAlimentareFresco);
			this.Controls.Add(this.radioButtonNonAlimentare);
			this.Controls.Add(this.radioButtonAlimentare);
			this.Controls.Add(this.panelTitleAdd);
			this.Name = "FormAdd";
			this.Text = "FormAdd";
			this.panelTitleAdd.ResumeLayout(false);
			this.panelTitleAdd.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panelTitleAdd;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radioButtonAlimentare;
		private System.Windows.Forms.RadioButton radioButtonNonAlimentare;
		private System.Windows.Forms.RadioButton radioButtonAlimentareFresco;
		private System.Windows.Forms.TextBox textBoxCodice;
		private System.Windows.Forms.TextBox textBoxDescrizione;
		private System.Windows.Forms.TextBox textBoxPrezzo;
		private System.Windows.Forms.ListView listViewArticoli;
		private System.Windows.Forms.Button buttonAggiungi;
		private System.Windows.Forms.Label labelProdType;
		private System.Windows.Forms.Label labelCodiceProd;
		private System.Windows.Forms.Label labelDescProd;
		private System.Windows.Forms.Label labelPriceProd;
		private System.Windows.Forms.Label labelAnnoScadenza;
		private System.Windows.Forms.TextBox textBoxAnnoScadenza;
		private System.Windows.Forms.Label labelCons;
		private System.Windows.Forms.TextBox textBoxGCons;
	}
}