﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classe_articoli
{
    public class ArticoloAlimentareFresco : ArticoloAlimentare
    {
        private int _consumazioneDopoApertura;

        public ArticoloAlimentareFresco(string codice, string descrizione, double prezzo, int consum) : base(codice, descrizione, prezzo, DateTime.Now.Year)
        {
            ConsumazioneDopoApertura = consum;
        }

        public int ConsumazioneDopoApertura
        {
            get { return _consumazioneDopoApertura; }
            set
            {
                if (value <= 5)
                    _consumazioneDopoApertura = value;
                else
                    MessageBox.Show("Consumazione dopo apertura non valida", "Errore!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public override string[] newToString()
        {
            return new string[] { Codice, Descrizione, Prezzo.ToString("F") + "€", AnnoScadenza.ToString(), "-", ConsumazioneDopoApertura.ToString(), ImportoScontato.ToString("F") + "€" };
        }
    }
}
