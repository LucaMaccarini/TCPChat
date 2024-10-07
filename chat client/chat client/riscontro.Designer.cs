namespace chat_client
{
    partial class riscontro
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
            this.messaggio = new System.Windows.Forms.Label();
            this.elenco_errori = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.foto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.foto)).BeginInit();
            this.SuspendLayout();
            // 
            // messaggio
            // 
            this.messaggio.AutoSize = true;
            this.messaggio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messaggio.Location = new System.Drawing.Point(97, 11);
            this.messaggio.Name = "messaggio";
            this.messaggio.Size = new System.Drawing.Size(0, 18);
            this.messaggio.TabIndex = 1;
            this.messaggio.Click += new System.EventHandler(this.messaggio_Click);
            // 
            // elenco_errori
            // 
            this.elenco_errori.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elenco_errori.Location = new System.Drawing.Point(98, 32);
            this.elenco_errori.Name = "elenco_errori";
            this.elenco_errori.Size = new System.Drawing.Size(262, 58);
            this.elenco_errori.TabIndex = 2;
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(12, 93);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(348, 23);
            this.ok.TabIndex = 3;
            this.ok.Text = "Ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // foto
            // 
            this.foto.Location = new System.Drawing.Point(12, 1);
            this.foto.Name = "foto";
            this.foto.Size = new System.Drawing.Size(80, 80);
            this.foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.foto.TabIndex = 0;
            this.foto.TabStop = false;
            // 
            // riscontro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 122);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.elenco_errori);
            this.Controls.Add(this.messaggio);
            this.Controls.Add(this.foto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "riscontro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.riscontro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.foto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox foto;
        private System.Windows.Forms.Label messaggio;
        private System.Windows.Forms.Label elenco_errori;
        private System.Windows.Forms.Button ok;
    }
}