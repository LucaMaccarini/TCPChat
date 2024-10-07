namespace chat_client
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tx_testo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.aggiornamento_automatico = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.group_scrivi = new System.Windows.Forms.GroupBox();
            this.emoticons = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.N_caratteri = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tx_destinatari = new System.Windows.Forms.Label();
            this.invia = new System.Windows.Forms.Button();
            this.pulisci = new System.Windows.Forms.Button();
            this.pannello_filtro = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lable_filtro = new System.Windows.Forms.Label();
            this.richetextboxfiltro = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pannello_stream = new System.Windows.Forms.Panel();
            this.Io = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.filtro = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.rubrica_connessi = new System.Windows.Forms.Panel();
            this.seleziona_deseleziona_tutti = new System.Windows.Forms.CheckBox();
            this.group_scrivi.SuspendLayout();
            this.pannello_filtro.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pannello_stream.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista degli utenti connessi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Destinatari:";
            // 
            // tx_testo
            // 
            this.tx_testo.Location = new System.Drawing.Point(9, 168);
            this.tx_testo.Multiline = true;
            this.tx_testo.Name = "tx_testo";
            this.tx_testo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tx_testo.Size = new System.Drawing.Size(466, 313);
            this.tx_testo.TabIndex = 7;
            this.tx_testo.TextChanged += new System.EventHandler(this.tx_testo_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Testo";
            // 
            // aggiornamento_automatico
            // 
            this.aggiornamento_automatico.Enabled = true;
            this.aggiornamento_automatico.Interval = 50;
            this.aggiornamento_automatico.Tick += new System.EventHandler(this.aggiornamento_automatico_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Stream:";
            // 
            // group_scrivi
            // 
            this.group_scrivi.Controls.Add(this.emoticons);
            this.group_scrivi.Controls.Add(this.button1);
            this.group_scrivi.Controls.Add(this.N_caratteri);
            this.group_scrivi.Controls.Add(this.label6);
            this.group_scrivi.Controls.Add(this.tx_destinatari);
            this.group_scrivi.Controls.Add(this.label3);
            this.group_scrivi.Controls.Add(this.invia);
            this.group_scrivi.Controls.Add(this.tx_testo);
            this.group_scrivi.Controls.Add(this.pulisci);
            this.group_scrivi.Controls.Add(this.label4);
            this.group_scrivi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_scrivi.Location = new System.Drawing.Point(288, 7);
            this.group_scrivi.Name = "group_scrivi";
            this.group_scrivi.Size = new System.Drawing.Size(483, 547);
            this.group_scrivi.TabIndex = 16;
            this.group_scrivi.TabStop = false;
            this.group_scrivi.Text = "Scrivi";
            // 
            // emoticons
            // 
            this.emoticons.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("emoticons.BackgroundImage")));
            this.emoticons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.emoticons.Location = new System.Drawing.Point(315, 491);
            this.emoticons.Name = "emoticons";
            this.emoticons.Size = new System.Drawing.Size(50, 50);
            this.emoticons.TabIndex = 20;
            this.emoticons.UseVisualStyleBackColor = true;
            this.emoticons.Click += new System.EventHandler(this.emoticons_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(371, 491);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 19;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // N_caratteri
            // 
            this.N_caratteri.AutoSize = true;
            this.N_caratteri.Location = new System.Drawing.Point(126, 484);
            this.N_caratteri.Name = "N_caratteri";
            this.N_caratteri.Size = new System.Drawing.Size(14, 15);
            this.N_caratteri.TabIndex = 18;
            this.N_caratteri.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 483);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "Numero dei caratteri:";
            // 
            // tx_destinatari
            // 
            this.tx_destinatari.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tx_destinatari.Location = new System.Drawing.Point(9, 37);
            this.tx_destinatari.Name = "tx_destinatari";
            this.tx_destinatari.Size = new System.Drawing.Size(466, 60);
            this.tx_destinatari.TabIndex = 16;
            // 
            // invia
            // 
            this.invia.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("invia.BackgroundImage")));
            this.invia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.invia.Location = new System.Drawing.Point(427, 491);
            this.invia.Name = "invia";
            this.invia.Size = new System.Drawing.Size(50, 50);
            this.invia.TabIndex = 9;
            this.invia.UseVisualStyleBackColor = true;
            this.invia.Click += new System.EventHandler(this.invia_Click);
            // 
            // pulisci
            // 
            this.pulisci.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pulisci.BackgroundImage")));
            this.pulisci.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pulisci.Location = new System.Drawing.Point(425, 100);
            this.pulisci.Name = "pulisci";
            this.pulisci.Size = new System.Drawing.Size(50, 50);
            this.pulisci.TabIndex = 12;
            this.pulisci.UseVisualStyleBackColor = true;
            this.pulisci.Click += new System.EventHandler(this.pulisci_Click);
            // 
            // pannello_filtro
            // 
            this.pannello_filtro.Controls.Add(this.label9);
            this.pannello_filtro.Controls.Add(this.lable_filtro);
            this.pannello_filtro.Controls.Add(this.richetextboxfiltro);
            this.pannello_filtro.Location = new System.Drawing.Point(9, 63);
            this.pannello_filtro.Name = "pannello_filtro";
            this.pannello_filtro.Size = new System.Drawing.Size(481, 475);
            this.pannello_filtro.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.ForestGreen;
            this.label9.Location = new System.Drawing.Point(458, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 18);
            this.label9.TabIndex = 23;
            this.label9.Text = "Io";
            // 
            // lable_filtro
            // 
            this.lable_filtro.AutoSize = true;
            this.lable_filtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable_filtro.Location = new System.Drawing.Point(0, 3);
            this.lable_filtro.Name = "lable_filtro";
            this.lable_filtro.Size = new System.Drawing.Size(0, 15);
            this.lable_filtro.TabIndex = 21;
            // 
            // richetextboxfiltro
            // 
            this.richetextboxfiltro.Location = new System.Drawing.Point(0, 26);
            this.richetextboxfiltro.Name = "richetextboxfiltro";
            this.richetextboxfiltro.ReadOnly = true;
            this.richetextboxfiltro.Size = new System.Drawing.Size(481, 448);
            this.richetextboxfiltro.TabIndex = 0;
            this.richetextboxfiltro.Text = "";
            this.richetextboxfiltro.TextChanged += new System.EventHandler(this.cambiato);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pannello_filtro);
            this.groupBox2.Controls.Add(this.pannello_stream);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.filtro);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(777, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(496, 547);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Casella dei messaggi ricevuti";
            // 
            // pannello_stream
            // 
            this.pannello_stream.AutoScroll = true;
            this.pannello_stream.Controls.Add(this.Io);
            this.pannello_stream.Location = new System.Drawing.Point(9, 63);
            this.pannello_stream.Name = "pannello_stream";
            this.pannello_stream.Size = new System.Drawing.Size(481, 478);
            this.pannello_stream.TabIndex = 19;
            this.pannello_stream.Paint += new System.Windows.Forms.PaintEventHandler(this.pannello_stream_Paint);
            // 
            // Io
            // 
            this.Io.AutoSize = true;
            this.Io.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Io.ForeColor = System.Drawing.Color.ForestGreen;
            this.Io.Location = new System.Drawing.Point(427, 3);
            this.Io.Name = "Io";
            this.Io.Size = new System.Drawing.Size(20, 18);
            this.Io.TabIndex = 22;
            this.Io.Text = "Io";
            this.Io.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(217, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "Filtra:";
            // 
            // filtro
            // 
            this.filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filtro.FormattingEnabled = true;
            this.filtro.Items.AddRange(new object[] {
            "Tutti"});
            this.filtro.Location = new System.Drawing.Point(258, 27);
            this.filtro.Name = "filtro";
            this.filtro.Size = new System.Drawing.Size(181, 23);
            this.filtro.TabIndex = 21;
            this.filtro.SelectedIndexChanged += new System.EventHandler(this.filtro_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(445, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // rubrica_connessi
            // 
            this.rubrica_connessi.AutoScroll = true;
            this.rubrica_connessi.Location = new System.Drawing.Point(12, 25);
            this.rubrica_connessi.Name = "rubrica_connessi";
            this.rubrica_connessi.Size = new System.Drawing.Size(262, 497);
            this.rubrica_connessi.TabIndex = 18;
            // 
            // seleziona_deseleziona_tutti
            // 
            this.seleziona_deseleziona_tutti.AutoSize = true;
            this.seleziona_deseleziona_tutti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seleziona_deseleziona_tutti.Location = new System.Drawing.Point(12, 533);
            this.seleziona_deseleziona_tutti.Name = "seleziona_deseleziona_tutti";
            this.seleziona_deseleziona_tutti.Size = new System.Drawing.Size(103, 19);
            this.seleziona_deseleziona_tutti.TabIndex = 19;
            this.seleziona_deseleziona_tutti.Text = "Seleziona tutti";
            this.seleziona_deseleziona_tutti.UseVisualStyleBackColor = true;
            this.seleziona_deseleziona_tutti.CheckedChanged += new System.EventHandler(this.seleziona_deseleziona_tutti_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 566);
            this.Controls.Add(this.seleziona_deseleziona_tutti);
            this.Controls.Add(this.rubrica_connessi);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.group_scrivi);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.group_scrivi.ResumeLayout(false);
            this.group_scrivi.PerformLayout();
            this.pannello_filtro.ResumeLayout(false);
            this.pannello_filtro.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pannello_stream.ResumeLayout(false);
            this.pannello_stream.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tx_testo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button invia;
        private System.Windows.Forms.Timer aggiornamento_automatico;
        private System.Windows.Forms.Button pulisci;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox group_scrivi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel rubrica_connessi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label tx_destinatari;
        private System.Windows.Forms.CheckBox seleziona_deseleziona_tutti;
        private System.Windows.Forms.Label N_caratteri;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pannello_stream;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox filtro;
        private System.Windows.Forms.Button emoticons;
        private System.Windows.Forms.Panel pannello_filtro;
        private System.Windows.Forms.Label lable_filtro;
        private System.Windows.Forms.RichTextBox richetextboxfiltro;
        private System.Windows.Forms.Label Io;
        private System.Windows.Forms.Label label9;
    }
}

