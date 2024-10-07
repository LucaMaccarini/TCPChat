using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_client
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome_server, nome, risposta;
            int porta, numero_bytes;
            Byte[] bytes_da_inviare;

            nome = tx_nome.Text;
            nome_server = tx_ip_server.Text;
            porta = Convert.ToInt32(tx_porta.Text);
            TcpClient cliente = new TcpClient();
            if (nome == "")
                MessageBox.Show("Il nome non può essere vuoto!");
            else
            {
                if (nome.Contains('|') || nome.Contains(','))
                {
                    MessageBox.Show("Il nome non può contenere i caratteri: '|' e ','");
                }
                else
                {
                    try
                    {
                        cliente.Connect(nome_server, porta);
                        NetworkStream stream = cliente.GetStream();
                        Byte[] bytes = new Byte[cliente.ReceiveBufferSize];

                        //tolgo dal buffer il numero del client 'CLIENTX'
                        stream.Read(bytes, 0, cliente.ReceiveBufferSize);


                        bytes_da_inviare = Encoding.ASCII.GetBytes('N' + nome);
                        stream.Write(bytes_da_inviare, 0, bytes_da_inviare.Length);

                        numero_bytes = stream.Read(bytes, 0, cliente.ReceiveBufferSize);
                        risposta = Encoding.ASCII.GetString(bytes, 0, numero_bytes);
                        if (risposta == "Y")
                        {
                            Form1 apri = new Form1(nome, cliente);
                            this.Hide();
                            apri.Show();
                        }
                        else
                            MessageBox.Show("Nome gia in uso, cambialo!");

                    }
                    catch
                    {
                        MessageBox.Show("impossibile connettersi al server! controlla di aver acceso il server o di aver inserito correttamente l'ip e la porta del server");
                    }
                }
            }

        }
    }
}
