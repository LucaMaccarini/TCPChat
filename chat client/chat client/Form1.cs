using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_client
{

    public partial class Form1 : Form
    {
        List<string> list_utenti_connessi = new List<string>();
        TcpClient cliente;
        string nome;
        public Form1(string utente, TcpClient appoggio)
        {
            InitializeComponent();
            nome = utente;
            this.Text = "utente: " + nome;
            cliente = appoggio;
        }


        void scrivi(string valore)
        {
            try
            {
                Byte[] sendBytes = null;
                NetworkStream networkStream = cliente.GetStream();
                sendBytes = Encoding.ASCII.GetBytes(valore);
                networkStream.Write(sendBytes, 0, sendBytes.Length);
            }
            catch
            {
                aggiornamento_automatico.Stop();
                MessageBox.Show("Il client non sta comunicando con il server");
                Application.Exit();
            }
        }

        string leggi()
        {
            string dati_ricevuti="";
            try
            {
                byte[] bytesFrom = new byte[cliente.ReceiveBufferSize];
                NetworkStream networkStream = cliente.GetStream();
                int num_bytesFrom;

                num_bytesFrom = networkStream.Read(bytesFrom, 0, cliente.ReceiveBufferSize);
                dati_ricevuti = Encoding.ASCII.GetString(bytesFrom, 0, num_bytesFrom);   
            }
            catch
            {
                aggiornamento_automatico.Stop();
                MessageBox.Show("Il client non sta comunicando con il server");
                Application.Exit();
            }
            return dati_ricevuti;
        }

        void rimuovi_contatto(string nome_da_rimuovere, Panel pannello_padre)
        {
            bool tolto = false;
            Panel precedente=null, rimuovere=null;
            Point appoggio =new Point();
            foreach (Panel corrente in pannello_padre.Controls.OfType<Panel>())
            {
                if(precedente!=null)
                    tolto = true;

                
                if ( !tolto && Convert.ToString(corrente.Tag) == nome_da_rimuovere)
                {
                    precedente = corrente;
                    rimuovere = corrente;
                }
                if(tolto)
                {
                    appoggio = corrente.Location;
                    corrente.Location = precedente.Location;
                    precedente.Location = appoggio;
                }
            }
            pannello_padre.Controls.Remove(rimuovere);
            pannello_padre.Refresh();
        }
    
        void aggiungi_contatto(string _nome, Panel pannello_padre)
        {
            Panel ultimo;

            Panel pannello = new Panel();
            pannello.DoubleClick += new EventHandler(aggiungi_destinatari);
            pannello.MouseEnter += new EventHandler(colora_mouse_enter);
            pannello.MouseLeave += new EventHandler(decolora_mouse_leave);
            Label nome = new Label();
            nome.Width = 185;
            //nome.BorderStyle=BorderStyle.FixedSingle;
            nome.Tag = _nome;
            nome.BackColor = Color.Transparent;
            nome.Font = new Font("Sans Serif", 9);
            nome.DoubleClick += new EventHandler(aggiungi_destinatari);
            nome.MouseEnter += new EventHandler(colora_mouse_enter);
            nome.MouseLeave += new EventHandler(decolora_mouse_leave);
            PictureBox immagine = new PictureBox();
            immagine.Tag = _nome;
            immagine.DoubleClick += new EventHandler(aggiungi_destinatari);
            immagine.MouseEnter += new EventHandler(colora_mouse_enter);
            immagine.MouseLeave += new EventHandler(decolora_mouse_leave);

            immagine.Image = Properties.Resources.foto_profilo;
            immagine.Width = 30;
            immagine.Height =30;
            immagine.SizeMode = PictureBoxSizeMode.StretchImage;
            immagine.BorderStyle = BorderStyle.FixedSingle;

            nome.Text = _nome;
            nome.Location = new Point(38,6);
            pannello.Controls.Add(nome);

            pannello.Controls.Add(immagine);

          
            
            pannello.Width = 234;
            pannello.Height = 32;
            pannello.BorderStyle = BorderStyle.FixedSingle;
            pannello.Tag = _nome;

            if (pannello_padre.Controls.OfType<Panel>().Count() > 0)
            {
                ultimo = pannello_padre.Controls.OfType<Panel>().Last();
                Point punti_per_posizionare = ultimo.Location;
                punti_per_posizionare.Y += ultimo.Height + 3;
                pannello.Location = punti_per_posizionare;
            }
            else
                pannello.Location = new Point(3, 3);
            pannello_padre.Controls.Add(pannello);

        }



        private void inserisci_faccine(RichTextBox addin)
        {
            addin.ReadOnly = false;
            var smileys = new Dictionary<string, Image>()
            {
                { ">:(", Properties.Resources.incazzato},
                { ":)", Properties.Resources.felice },
                { ":'(", Properties.Resources.piange},
                { ":(", Properties.Resources.triste},
                { ";)", Properties.Resources.occhiolino},
                { "xD", Properties.Resources.felicissimo},
            };

            foreach (var smiley in smileys)
            {
                add_smiley(addin, smiley.Key, smiley.Value);
            }
            addin.ReadOnly = true;
        }

        private void add_smiley(RichTextBox addin, string token, Image smiley)
        {
            while (true)
             {
                 var selectionStart = addin.Text.IndexOf(token);
                 if (selectionStart < 0) break;

                 try
                 {
                     addin.SelectionStart = selectionStart;
                     addin.SelectionLength = token.Length;


                     Clipboard.SetImage(smiley);
                     addin.Paste();



                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("troppi accessi agli appunti chiudere qualche client per utilizzare gli emoticons (ci sto lavorando...)");
                     break;
                 }
             }
/*
            Graphics grafica = addin.CreateGraphics();

            Size quanto_occupa_testo ;
            for(int i=0; i<addin.Lines.Length;i++)
            {
                int selectionStart = addin.Text.IndexOf(token);
                addin.SelectionLength = token.Length;
                if (selectionStart >= 0)
                {
                    string pezzo_prima = addin.Text.Substring(0, selectionStart);
                    string pezzo_dopo = addin.Text.Substring(selectionStart + token.Length, addin.Lines[i].Length - token.Length - selectionStart);

                    quanto_occupa_testo = TextRenderer.MeasureText(pezzo_prima, addin.Font);

                 
                    grafica.DrawImage(smiley, quanto_occupa_testo.Width, 0, 16,16);

                }
                
            }*/

        }


        private void Form1_Load(object sender, EventArgs e)
        {


            pannello_filtro.Visible = false; //inutile perchè già è scritto nel change della combobox che avviene nelle prossima istruzione (solo per sicurezza)
            filtro.SelectedIndex = 0;
           
          

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void aggiornamento_automatico_Tick(object sender, EventArgs e)
        {
            string letto="";
            bool richiesta_lista = false;


            if (!stop)
            {
                if (cliente.Available > 0)
                    letto = leggi();
                else
                {
                    scrivi("L");
                    richiesta_lista = true;
                    letto = leggi();
                }
            }

            
            if (letto != "")
            {
                if (richiesta_lista && letto[0]=='U')
                {
                    crea_elimina_pannelli(letto);
                }
                else
                {
                    if(letto[0]=='M')
                        messaggio_arrivato(letto);
                }
            }
        }


        private void cambiato(object sender, EventArgs e)
        {
            // set the current caret position to the end
            ((RichTextBox)sender).SelectionStart = ((RichTextBox)sender).Text.Length;
            // scroll it automatically
            ((RichTextBox)sender).ScrollToCaret();
        }


        Point posizione_ultima_casella = new Point(0, 3);
        public void crea_casella_di_stream(string nome, string messaggio, bool sono_io)
        {
            pannello_stream.VerticalScroll.Value = 0;

            RichTextBox casella = new RichTextBox();
            casella.TextChanged += new EventHandler(cambiato);
            Label nome_label = new Label();
            nome_label.Width = 400;
            nome_label.Text = "Messaggi da : " + nome;
            nome_label.Name = nome + "lb";


            if (!(posizione_ultima_casella.Y == 3))
            {
                posizione_ultima_casella.Y+=8;
            }

            Point appoggio = posizione_ultima_casella;
            appoggio.Y += pannello_stream.AutoScrollPosition.Y;
            nome_label.Location = appoggio;

            casella.Name = nome + "tx";
            //casella.Location = posizione_ultima_casella;

            casella.Multiline = true;
            casella.ReadOnly = true;

            if (!sono_io)
            {
                casella.AppendText(messaggio);

            }
            else
            {
                casella.AppendText(messaggio);
                string LastLineText = casella.Lines[casella.Lines.Count() - 1];
                int LastLineStartIndex = casella.Text.LastIndexOf(LastLineText);
                casella.SelectionStart = LastLineStartIndex;
                casella.SelectionLength = casella.Text.Length - 1;

                casella.SelectionAlignment = HorizontalAlignment.Right;
                
               

            }
            inserisci_faccine(casella);

            Point posiziona_casella = appoggio;
            posiziona_casella.Y += 23;
            casella.Location = posiziona_casella;
            casella.Width = 450;
            casella.Height = 155;

            casella.BorderStyle = BorderStyle.FixedSingle;

            posizione_ultima_casella.Y = casella.Location.Y + casella.Height + 5;

            //MessageBox.Show(Convert.ToString(posizione_ultima_casella.Y));

            //MessageBox.Show("location " + casella.Location.X.ToString() + ", " + casella.Location.Y.ToString());
           



            pannello_stream.Controls.Add(nome_label);
            pannello_stream.Controls.Add(casella);

            filtro.Items.Add(nome);



            pannello_stream.ScrollControlIntoView(casella);
            pannello_stream.Refresh();

            if (sono_io)
            {
                string _LastLineText = casella.Lines[casella.Lines.Count() - 1];
                int _LastLineStartIndex = casella.Text.LastIndexOf(_LastLineText);
                casella.SelectionStart = _LastLineStartIndex;
                casella.SelectionLength = casella.Text.Length;

                casella.SelectionColor = Color.ForestGreen;
            }

            inserisci_faccine(casella);

        }




        public void messaggio_ad__uno_stream(RichTextBox stream, string messaggio)
        {
            stream.AppendText(Environment.NewLine);
            string LastLineText = stream.Lines[stream.Lines.Count() -1];
            int LastLineStartIndex;


          
            LastLineStartIndex = stream.Text.LastIndexOf(LastLineText);

            stream.SelectionStart = LastLineStartIndex;
            stream.SelectionLength = stream.Text.Length - 1;
            stream.SelectionColor = Color.Black;
            stream.SelectionAlignment = HorizontalAlignment.Left;

            
            stream.AppendText(messaggio);
            inserisci_faccine(stream);
        }
        

            


        public void messaggio_arrivato(string destinatari_messaggio)
        {
            string[] destinatari_e_messaggio = destinatari_messaggio.Substring(1, destinatari_messaggio.Length-1).Split('|');

            RichTextBox[] vari_stream = pannello_stream.Controls.OfType<RichTextBox>().ToArray();
            bool esci = false;
            int i;

            for (i=0; i< vari_stream.Length && !esci; i++ )
            {
                if(vari_stream[i].Name== destinatari_e_messaggio[0] + "tx")
                {
                    esci = true;
                }
            }

            if (esci)
                messaggio_ad__uno_stream(vari_stream[i - 1], destinatari_e_messaggio[1]);
            else
            {

                  crea_casella_di_stream(destinatari_e_messaggio[0], destinatari_e_messaggio[1],false);
               
            }

            if (destinatari_e_messaggio[0] == filtro.Items[filtro.SelectedIndex].ToString())
            {
                messaggio_ad__uno_stream(richetextboxfiltro, destinatari_e_messaggio[1]);
            }

            //tx_messaggi_ricevuti.AppendText("Messaggi di: " + destinatari_e_messaggio[0] + "\n\n");
            //tx_messaggi_ricevuti.AppendText(destinatari_e_messaggio[1] + '\n');
        }


       
        void crea_elimina_pannelli (string _letto)
        {
            int i = 0;
            string letto = _letto.Substring(1);
            List<string> nuovi_utenti = new List<string>(letto.Split('|'));
            //list_utenti_connessi.Items.Clear();
            foreach (string corrente in nuovi_utenti)
            {
                if (corrente != nome)
                {
                    if (!list_utenti_connessi.Contains(corrente))
                    {
                        list_utenti_connessi.Add(corrente);
                        aggiungi_contatto(corrente, rubrica_connessi);
                    }
                }
            }

            while (i < list_utenti_connessi.Count)
            {
                if (!nuovi_utenti.Contains(list_utenti_connessi[i]))
                {
                    rimuovi_contatto(Convert.ToString(list_utenti_connessi[i]), rubrica_connessi);
                    list_utenti_connessi.Remove((list_utenti_connessi[i]));
                }

                i++;
            }
        }

        void colora_mouse_enter(object sender, EventArgs e)
        {
            Color colore = ColorTranslator.FromHtml("#ff9172");
           

            if (sender is Panel)
            {
                if (((Control)sender).BackColor != colore)
                    ((Control)sender).BackColor = colore;
            }
            else
            {
                if (((Control)sender).Parent.BackColor != colore)
                    ((Control)sender).Parent.BackColor = colore;
            }
           
        }

        void decolora_mouse_leave(object sender, EventArgs e)
        {
            if (tx_destinatari.Text != "*")
            {
                List<string> destinatari = new List<string>(tx_destinatari.Text.Split(','));
                try
                {

                    if (sender is Panel)
                    {
                        if (!destinatari.Contains(Convert.ToString(((Control)sender).Tag)))
                            ((Control)sender).BackColor = SystemColors.Control;
                    }
                    else
                    {
                        if (!destinatari.Contains(Convert.ToString(((Control)sender).Tag)))
                            ((Control)sender).Parent.BackColor = SystemColors.Control;
                    }
                }
                catch
                {
                    if (sender is Panel)
                        ((Control)sender).BackColor = SystemColors.Control;
                    else
                        ((Control)sender).Parent.BackColor = SystemColors.Control;
                }
            }
        }
        
        void aggiungi_destinatari(object sender, EventArgs e)
        {
           
            List<string> destinatari = new List<string>(tx_destinatari.Text.Split(','));


            if (destinatari.Contains(Convert.ToString(((Control)sender).Tag)))
            {
                //MessageBox.Show("Attenzione! il destinatario: " + Convert.ToString(((Control)sender).Tag) + " è già stato inserito");
                if (sender is Panel)
                    ((Control)sender).BackColor = SystemColors.Control;
                else
                    ((Control)sender).Parent.BackColor = SystemColors.Control;

                destinatari.Remove(Convert.ToString(((Control)sender).Tag));
                string stringona="";
                if(destinatari.Count>0)
                {
                    foreach(string corrente in destinatari)
                    {
                        stringona += ',';
                        stringona += corrente;
                    }
                    stringona = stringona.Substring(1,stringona.Length - 1);  
                }
                tx_destinatari.Text = stringona;
            }
            else
            {
                if (tx_destinatari.Text == "*")
                    tx_destinatari.Text = "" + Convert.ToString(((Control)sender).Tag);

                else
                {
                    if (tx_destinatari.Text == "")
                        tx_destinatari.Text = Convert.ToString(((Control)sender).Tag);
                    else
                    {
                        tx_destinatari.Text += ',';
                        tx_destinatari.Text += Convert.ToString(((Control)sender).Tag);
                    }
                }
            }
            
        }
    

        /*private void button1_Click(object sender, EventArgs e)
        {
            
            List<string> destinatari = new List<string>(tx_destinatari.Text.Split(','));
            List<string> doppi = new List<string>();
            string stringona="";

            if (tx_destinatari.Text == "*")
                tx_destinatari.Text = "";
            foreach (string corrente in list_utenti_connessi.SelectedItems)
            {
                if (destinatari.Contains(corrente))
                    doppi.Add(corrente);
                else
                {
                    if (tx_destinatari.Text == "")
                        tx_destinatari.Text = corrente;
                    else
                    {
                        tx_destinatari.Text += ',';
                        tx_destinatari.Text += corrente;
                    }
                }
            }

            if (doppi.Count > 0)
            {
                foreach (string corrente in doppi)
                    stringona += corrente + " ";
                stringona = stringona.Substring(0, stringona.Length - 1);
                if (doppi.Count == 1)
                    MessageBox.Show("Attenzione! il destinatario: " + stringona + " è già stato inserito");
                else
                    MessageBox.Show("Attenzione! i destinatari: " + stringona + " sono già stati inseriti");
            }
        }*/

        private void pulisci_Click(object sender, EventArgs e)
        {
            tx_destinatari.Text = "";

            if (!rubrica_connessi.Enabled)
            {
                rubrica_connessi.Enabled = true;
                seleziona_deseleziona_tutti.Checked = false;
            }

            foreach (Panel corrente in rubrica_connessi.Controls.OfType<Panel>())
            {
                 corrente.BackColor = SystemColors.Control;
            }

        }

        public void mio_messaggio(string destinatari, string messaggio)
        {
            string[] _destinatari = tx_destinatari.Text.Split(',');
            RichTextBox[] vari_stream = pannello_stream.Controls.OfType<RichTextBox>().ToArray();
            bool esci;
            foreach (string corrente in _destinatari)
            {
                esci = false;
                for (int i = 0; i < vari_stream.Length && !esci; i++)
                {
                    if (vari_stream[i].Name == corrente + "tx")
                    {
                        esci = true;
                        vari_stream[i].AppendText(Environment.NewLine);
                        vari_stream[i].AppendText(messaggio);
                        string LastLineText = vari_stream[i].Lines[vari_stream[i].Lines.Count() - 1];
                        int LastLineStartIndex = vari_stream[i].Text.LastIndexOf(LastLineText);
                        vari_stream[i].SelectionStart = LastLineStartIndex;
                        vari_stream[i].SelectionLength = vari_stream[i].Text.Length - 1;
                        vari_stream[i].SelectionColor = Color.ForestGreen;
                        vari_stream[i].SelectionAlignment = HorizontalAlignment.Right;
                        inserisci_faccine(vari_stream[i]);
                    }
                }

                if(!esci)
                {
                    crea_casella_di_stream(corrente,messaggio,true);
                }

                if (pannello_filtro.Visible)
                {
                    if (filtro.Items[filtro.SelectedIndex].ToString() == corrente)
                    {
                        richetextboxfiltro.AppendText(Environment.NewLine);
                        richetextboxfiltro.AppendText(messaggio);
                        string LastLineText = richetextboxfiltro.Lines[richetextboxfiltro.Lines.Count() - 1];
                        int LastLineStartIndex = richetextboxfiltro.Text.LastIndexOf(LastLineText);
                        richetextboxfiltro.SelectionStart = LastLineStartIndex;
                        richetextboxfiltro.SelectionLength = richetextboxfiltro.Text.Length - 1;
                        richetextboxfiltro.SelectionColor = Color.ForestGreen;
                        richetextboxfiltro.SelectionAlignment = HorizontalAlignment.Right;
                    }
                }

            }
            if (!Io.Visible)
                Io.Visible = true;

            
        }



        bool stop;
        private void invia_Click(object sender, EventArgs e)
        {
            if (tx_destinatari.Text != "")
            {
                if (tx_testo.Text != "")
                {
                    riscontro form_riscontro;
                    string letto, stringona = "";
                    stop = true;
                    scrivi('M' + tx_destinatari.Text + '|' + tx_testo.Text);
                    letto = leggi();
                    if (letto == "OK")
                    {
                        form_riscontro = new riscontro("");
                        form_riscontro.ShowDialog(this);
                        mio_messaggio(tx_destinatari.Text, tx_testo.Text);
                    }
                    else
                    {
                        while (letto[0] == 'M' || letto[0] == 'U')
                        {
                            if (letto[0] == 'M')
                                messaggio_arrivato(letto);
                            else
                                crea_elimina_pannelli(letto);
                            letto = leggi();
                        }
                        if (letto == "OK")
                        {
                            form_riscontro = new riscontro("");
                            form_riscontro.ShowDialog(this);
                            mio_messaggio(tx_destinatari.Text, tx_testo.Text);
                            //MessageBox.Show("Messaggio inviato con successo");
                        }
                        else
                        {
                            if (letto[0] == 'R')
                            {
                                string[] destinatari_non_ricevuto = letto.Substring(1, letto.Length - 1).Split('|');

                                foreach (string corrente in destinatari_non_ricevuto)
                                    stringona += corrente + ',';
                                stringona = stringona.Substring(0, stringona.Length - 1);
                                //MessageBox.Show("I destinatari: " + stringona + " non hanno ricevuto il messaggio!");
                                form_riscontro = new riscontro(stringona);
                                form_riscontro.ShowDialog(this);

                            }
                        }
                    }
                    stop = false;
                }
                else
                    MessageBox.Show("Non hai inserito il testo del messaggio!");
            }
            else
                MessageBox.Show("Non hai inserito il destinatario!");
        }

      

        private void seleziona_deseleziona_tutti_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                tx_destinatari.Text = "*";

                foreach (Panel corrente in rubrica_connessi.Controls.OfType<Panel>())
                {
                    corrente.BackColor = SystemColors.Control;
                }

                rubrica_connessi.Enabled = false;
            }
            else
            {
                tx_destinatari.Text = "";
                rubrica_connessi.Enabled = true;
            }
        }

        private void tx_testo_TextChanged(object sender, EventArgs e)
        {
            N_caratteri.Text=Convert.ToString(((TextBox)sender).Text.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tx_testo.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //tx_messaggi_ricevuti.Text = "";
        }

        private void pannello_stream_Paint(object sender, PaintEventArgs e)
        {
            
        }


       

        private void filtro_SelectedIndexChanged(object sender, EventArgs e)
        {

                RichTextBox[] vari_stream = pannello_stream.Controls.OfType<RichTextBox>().ToArray();


                RichTextBox[] text = pannello_filtro.Controls.OfType<RichTextBox>().ToArray();
                Label[] label_filtro = pannello_filtro.Controls.OfType<Label>().ToArray();


                if (filtro.Items[filtro.SelectedIndex].ToString() != "Tutti")
                {

                    foreach (RichTextBox corrente in vari_stream)
                    {
                        if (corrente.Name == filtro.Items[filtro.SelectedIndex].ToString() + "tx")
                        {

                            Control[] appoggio = pannello_stream.Controls.Find(corrente.Name.Substring(0, corrente.Name.Length - 2) + "lb", true);

                            //richetextboxfiltro.Name = corrente.Name.Substring(0, corrente.Name.Length - 2) + "fl";
                            richetextboxfiltro.Rtf = corrente.Rtf;
                            //richetextboxfiltro.AppendText(Environment.NewLine);
                            lable_filtro.Text= appoggio[0].Text;

                        }

                    }
                    pannello_filtro.Visible = true;
                    //pannello_stream.Visible = false;

                }
                else
                {
                    pannello_filtro.Visible = false;
                    //pannello_stream.Visible = true;

                } 

        }

        private void emoticons_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dizionario delle emoticons:\n\n:)    faccina sorridente\n\n>:(    faccina arrabbiata\n\n:'(    faccina che piange\n\n:(    faccina triste\n\n;)    faccina con un occhio strizzato\n\nxD    faccina felicissima", "Emoticons");
        }

      

        private void button2_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show("posizione ultima casella:" + posizione_ultima_casella.X.ToString() + ", " + posizione_ultima_casella.Y.ToString());
        }

       
    }
}
