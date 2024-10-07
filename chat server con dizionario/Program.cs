using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
namespace ConsoleApplication1
{
    class Program
    {
        

        public static Dictionary<string, client_copia> dizionario_utenti = new Dictionary<string, client_copia>(StringComparer.InvariantCultureIgnoreCase);          

        static string elenco_utenti()
        {
          
            string stringona="U";
            if (dizionario_utenti.Count > 0)
            {

                foreach (string corrente in dizionario_utenti.Keys)
                {
                    stringona += corrente + "|";
                }
                stringona = stringona.Substring(0, stringona.Length - 1);
            }
            return stringona;
               
        }


        static void togli_utente(client_copia valore)
        {
            if (dizionario_utenti.Count > 0)
            {
                dizionario_utenti.Remove(valore.nome);
            }

        }
        static char aggiungi_utente(client_copia valore)
        {
            char esito = 'Y';
            bool esci = false;
            if (dizionario_utenti.Count > 0)
            {

                if (dizionario_utenti.ContainsKey(valore.nome))
                    esito = 'N';
                else
                    dizionario_utenti.Add(valore.nome,valore);
            }
            return esito;
        }


      


        static void scrivi(TcpClient clientSocket,string valore)
        {
            Byte[] sendBytes = null;
            NetworkStream networkStream = clientSocket.GetStream();
            sendBytes = Encoding.ASCII.GetBytes(valore);
            networkStream.Write(sendBytes, 0, sendBytes.Length);
        }

        static string leggi(TcpClient clientSocket)
        {
            byte[] bytesFrom = new byte[clientSocket.ReceiveBufferSize];
            NetworkStream networkStream = clientSocket.GetStream();
            int num_bytesFrom;
            string dataFromClient;

            num_bytesFrom = networkStream.Read(bytesFrom, 0, clientSocket.ReceiveBufferSize);
            dataFromClient = Encoding.ASCII.GetString(bytesFrom, 0, num_bytesFrom);
            return dataFromClient;
        }

        static void invia_messaggi(string destinatari_messaggio, client_copia mittente)
        {
            string stringona="R";
            List<string>non_inviati=new List<string>();
            string[] destinatari = destinatari_messaggio.Substring(1, destinatari_messaggio.IndexOf('|')-1).Split(',');
            string messaggio=destinatari_messaggio.Substring(destinatari_messaggio.IndexOf('|')+1);
            if (destinatari.Length == 1 && destinatari[0] == "*")
            {
                foreach (KeyValuePair<string, client_copia> corrente in dizionario_utenti)
                {
                    if (corrente.Key != mittente.nome)
                        scrivi(corrente.Value.clientSocket, "M" + mittente.nome + '|' + messaggio);
                }
                
                scrivi(mittente.clientSocket, "OK");   
                   
            }
            else
            {
                foreach (string corrente in destinatari)
                {
                    try
                    {
                        scrivi(dizionario_utenti[corrente].clientSocket, "M" + mittente.nome + '|' + messaggio);
                    }
                    catch
                    {
                        non_inviati.Add(corrente);
                    }
                }

                if (non_inviati.Count == 0)
                {
                    scrivi(mittente.clientSocket, "OK");
                }
                else
                {
                    foreach (string uno in non_inviati)
                    {
                        stringona += uno + '|';
                    }
                    stringona = stringona.Substring(0, stringona.Length - 1);
                    scrivi(mittente.clientSocket, stringona);
                }
            }
        }




        static void Main(string[] args)
        {
            int porta=9000;
         
            Console.WriteLine("Inserisci la porta di ascolto del server (scrivi -1 per utilizzare di default la porta 9000)");
            int appoggio = Convert.ToInt32(Console.ReadLine());
            if (appoggio != -1)
                porta = appoggio;
            TcpListener serverSocket = new TcpListener(IPAddress.Any, porta);
            TcpClient clientSocket = default(TcpClient);
            int counter = 0;

            serverSocket.Start();
            Console.WriteLine("Server avviato - Porta: " + porta);

            counter = 0;
            while (true)
            {
                clientSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Client Numero: " + Convert.ToString(counter) + " si è collegato");
                client_copia client = new client_copia();
                client.startClient(clientSocket, Convert.ToString(counter));
                counter += 1;
            }

            serverSocket.Stop();
            Console.WriteLine("Esco (in realtà non avviene mai, per come è scritto questo codice)");
            Console.ReadLine();
        }

        //Classe che gestisce ogni client connesso separatamente
        public class client_copia
        {
            public TcpClient clientSocket;
            string numero_client;
            public string nome="";
            public void startClient(TcpClient inClientSocket, string numero_client)
            {
                this.clientSocket = inClientSocket;

                this.numero_client = numero_client;
                Thread ctThread = new Thread(compito_thead);
                ctThread.Start();

            }

            private void compito_thead()
            {
                bool connesso = true, inizio=true;
                string dataFromClient = null;
                bool una_volta = true;
                //Console.WriteLine("La connessione è attiva all'indirizzo/porta: " + clientSocket.Client.RemoteEndPoint.ToString());


                while (connesso)
                {
                    try
                    {
                       
                        if (inizio)
                        {
                            scrivi(clientSocket, "CLIENT" + numero_client);
                            inizio = false;
                        }

                        dataFromClient = leggi(clientSocket);

                        if (dataFromClient.Substring(0, 1) == "N" && dataFromClient.Substring(1)!="" && una_volta)
                        {
                            string _nome = dataFromClient.Substring(1, dataFromClient.Length - 1);
                            if (!_nome.Contains("|") && !_nome.Contains(","))
                            {
                                try
                                {
                                    dizionario_utenti.Add(_nome, this);
                                    nome = _nome;
                                    scrivi(clientSocket, "Y");
                                    una_volta = false;
                                    Console.WriteLine(nome + " entra nella chat");
                                    Console.WriteLine("Utenti [ONLINE]: " + elenco_utenti().Substring(1));
                                }
                                catch
                                {
                                    scrivi(clientSocket, "N");
                                    Console.WriteLine("[" + dataFromClient.Substring(1, dataFromClient.Length - 1) + "] nome già utilizzato!");
                                }
                            }
                            else
                                scrivi(clientSocket, "N");
                        }

                        if (dataFromClient == "L" && nome!="")
                            scrivi(clientSocket, elenco_utenti());
                         
                        if (dataFromClient.Substring(0, 1) == "M")  
                            invia_messaggi(dataFromClient, this);
                                   


                       

                    }
                    catch (Exception ex)
                    {
                        togli_utente(this);
                        Console.WriteLine(this.nome + " ha abbandonato la chat [OFFLINE]");
                        Console.WriteLine(elenco_utenti());
                        connesso = false;
                    }
                }
            }
        }
    }
}
