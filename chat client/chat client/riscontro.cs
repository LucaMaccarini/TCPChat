using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_client
{
    public partial class riscontro : Form
    {
        public riscontro(string destinatari)
        {
            InitializeComponent();
            if(destinatari=="")
            {
                this.Text = "Inviato!";
                foto.Image = Properties.Resources.inviato;
                messaggio.Text = "Messaggio Inviato";
                elenco_errori.Text = "Con successo!";
            }
            else
            {
                this.Text = "Errore!";
                foto.Image = Properties.Resources.non_inviato;
                messaggio.Text = "Errore invio messaggio";
                string[] destinatari_non_ricevuto = destinatari.Substring(1, destinatari.Length - 1).Split('|');
                if(destinatari_non_ricevuto.Length>1)
                    elenco_errori.Text = "Messaggio non inviato a: " + destinatari;
                else
                    elenco_errori.Text = "Messaggio non inviato a " + destinatari;
            }
        }

        private void messaggio_Click(object sender, EventArgs e)
        {

        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void riscontro_Load(object sender, EventArgs e)
        {

        }
    }
}
