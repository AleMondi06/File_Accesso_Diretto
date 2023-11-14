using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Accesso_Diretto
{
    // Classe principale dell'applicazione Windows Form
    public partial class Form1 : Form
    {
        // Costruttore della classe Form1
        public Form1()
        {
            InitializeComponent();
        }

        // Struttura per rappresentare un prodotto con nome e prezzo
        public struct Prodotto
        {
            public string prodotto;
            public double prezzo;
        }

        // Array di prodotti e variabili globali
        public Prodotto[] p = new Prodotto[100];
        public int dim = 0;
        public string filePath = "SaveList.txt";
        public int riempi = 64;

        // Metodo per aggiungere un prodotto al file
        private void Aggiunta(string nome, double prezzo, string filePath)
        {
            // Apertura del file per la lettura
            var apertura = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader reader = new StreamReader(apertura);
            string line;
            int riga = 0;

            // Scansione del file per trovare un prodotto esistente
            while ((line = reader.ReadLine()) != null)
            {
                string[] dati = line.Split(';');

                // Se trova un prodotto con lo stesso nome e prezzo, incrementa la terza colonna
                if (dati[0] == nome && Convert.ToDouble(dati[1]) == prezzo)
                {
                    int quantita = Convert.ToInt32(dati[2]);
                    quantita++;
                    apertura.Close();
                    UpdateQuantita(filePath, riga, quantita);
                    return;
                }

                riga++;
            }

            // Se non trova un prodotto con lo stesso nome e prezzo, aggiunge un nuovo prodotto
            apertura.Close();
            var scrittura = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter write = new StreamWriter(scrittura);
            write.WriteLine($"{nome};{prezzo};1;0;".PadRight(riempi - 4) + "##");
            write.Close();
            MessageBox.Show("Prodotto salvato con successo.");
            box_prodotto.Clear();
            box_prezzo.Clear();
        }

        // Metodo per aggiornare la quantità di un prodotto esistente
        private void UpdateQuantita(string filePath, int riga, int nuovaQuantita)
        {
            // Legge tutte le linee del file
            string[] linee = File.ReadAllLines(filePath);

            // Modifica la quantità nella riga specificata
            linee[riga] = linee[riga].Replace(linee[riga].Split(';')[2], nuovaQuantita.ToString());

            // Tronca il file e riscrive tutte le linee aggiornate
            var file = new FileStream(filePath, FileMode.Truncate, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(file);
            sw.Write(string.Empty);
            sw.Close();

            var files = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sws = new StreamWriter(files);

            // Riscrive le linee aggiornate nel file
            foreach (string linea in linee)
            {
                sws.WriteLine(linea);
            }
            MessageBox.Show("Prodotto inserito più volte con successo.");
            box_prodotto.Clear();
            box_prezzo.Clear();
            sws.Close();
        }

        // Metodo per cercare l'indice di un prodotto nel file
        public int RicercaIndice(string nome)
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dati = line.Split(';');
                    if (dati[3] == "0" && dati[0] == nome)
                    {
                        sr.Close();
                        return riga;
                    }
                    riga++;
                }
            }
            return -1;
        }

        // Metodo per cercare le informazioni di un prodotto nel file
        public string[] RicercaProdotto(string nome)
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dati = line.Split(';');
                    if (dati[3] == "0" && dati[0] == nome)
                    {
                        sr.Close();
                        return dati;
                    }
                    riga++;
                }
            }
            return null;
        }

        // Metodo per cercare l'indice di un prodotto nel file
        public int Ricerca(string nome, string filePath)
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] dati = s.Split(';');
                    if (dati[3] == "0" && dati[0] == nome)
                    {
                        sr.Close();
                        return riga;
                    }
                    riga++;
                }
                sr.Close();
            }
            return -1;
        }

        // Metodo per cercare le informazioni di un prodotto nel file
        public string[] RicercaProdottoRecuperare(string nome)
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dati = line.Split(';');
                    dati[0] = dati[0].Remove(0, 1);
                    if (dati[3] == "1" && String.Equals(dati[0], nome))
                    {
                        sr.Close();
                        return dati;
                    }
                    riga++;
                }
            }
            return null;
        }

        // Metodo per cercare l'indice di un prodotto da recuperare nel file
        public int RicercaIndiceRecuperare(string nome)
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dati = line.Split(';');
                    dati[0] = dati[0].Remove(0, 1);
                    if (dati[3] == "1" && String.Equals(dati[0], nome))
                    {
                        sr.Close();
                        return riga;
                    }
                    riga++;
                }
            }
            return -1;
        }

        // Gestisce il click sul pulsante "CREATE"
        private void CREATE_Click(object sender, EventArgs e)
        {
            string nomeProdottoDaCancellare = box_prodotto.Text;

            bool c = false;
            bool y = false;

            // Verifica se il nome del prodotto è stato inserito
            if (string.IsNullOrWhiteSpace(nomeProdottoDaCancellare))
            {
                MessageBox.Show("Inserisci il nome del prodotto.");
                return;
            }

            // Verifica se il prezzo è valido
            if (c == false)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(box_prezzo.Text, "[^0-9]") || string.IsNullOrWhiteSpace(box_prezzo.Text))
                {
                    MessageBox.Show("Inserisci un valore numerico valido.");
                    y = true;
                }

                // Se il prezzo è valido, aggiungi il prodotto
                if (y == false)
                {
                    p[dim].prodotto = box_prodotto.Text;
                    p[dim].prezzo = float.Parse(box_prezzo.Text);
                    Aggiunta(p[dim].prodotto, p[dim].prezzo, filePath);
                    dim++;
                }
            }
        }

        // Gestisce il click sul pulsante "UPDATE"
        private void UPDATE_Click(object sender, EventArgs e)
        {
            // Acquisizione dei valori inseriti dall'utente per il vecchio nome, il nuovo nome e il nuovo prezzo
            string NomeVecchio = box_update.Text;
            string NomeNuovo = box_modifica.Text;
            string PrezzoNuovo = box_modifica_prezzo.Text;

            // Verifica se uno qualsiasi dei campi è vuoto o se il prezzo contiene caratteri non numerici
            if (string.IsNullOrWhiteSpace(NomeVecchio) || string.IsNullOrWhiteSpace(NomeNuovo) || string.IsNullOrWhiteSpace(PrezzoNuovo) || System.Text.RegularExpressions.Regex.IsMatch(box_modifica_prezzo.Text, "[^0-9]"))
            {
                MessageBox.Show("Inserisci un vecchio nome e un nuovo nome per la modifica o assicurati che il prezzo sia un numero valido.");
                return;
            }

            try
            {
                // Ricerca dell'indice del prodotto da modificare
                int indice = RicercaIndice(box_update.Text);

                // Se il prodotto non viene trovato, mostra un messaggio e interrompe l'esecuzione
                if (indice == -1)
                {
                    MessageBox.Show("Prodotto non trovato.");
                    return;
                }

                // Ricerca delle informazioni del prodotto basandosi sul vecchio nome
                string[] prodotto = RicercaProdotto(box_update.Text);
                string line;

                // Apertura del file in modalità scrittura per la modifica del prodotto
                using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Write))
                {
                    // Posizionamento del cursore nel file all'inizio del record del prodotto da modificare
                    file.Seek(riempi * indice, SeekOrigin.Begin);

                    // Creazione della nuova linea del prodotto con i dati aggiornati
                    line = $"{box_modifica.Text};{box_modifica_prezzo.Text};{prodotto[2]};0;".PadRight(riempi - 4) + "##";

                    // Conversione della stringa in byte e scrittura nel file
                    byte[] bytes = Encoding.UTF8.GetBytes(line);
                    file.Write(bytes, 0, bytes.Length);
                }

                // Messaggio di successo dopo la modifica
                MessageBox.Show("Modifica completata con successo.");
            }
            catch (Exception ex)
            {
                // Gestione delle eccezioni durante la modifica e visualizzazione del messaggio di errore
                MessageBox.Show($"Si è verificato un errore durante la modifica del nome: {ex.Message}");
            }

            // Pulizia dei campi di input dopo la modifica
            box_update.Clear();
            box_modifica.Clear();
            box_modifica_prezzo.Clear();


        }

        private void DELETE_LOGIC_Click(object sender, EventArgs e)
        {
            // Acquisizione del nome del prodotto da cancellare inserito dall'utente
            string nomeProdotto = box_cancella.Text;

            // Verifica se il campo è vuoto
            if (string.IsNullOrWhiteSpace(nomeProdotto))
            {
                MessageBox.Show("Inserisci il nome del prodotto da cancellare.");
                return;
            }

            try
            {
                // Ricerca dell'indice del prodotto da cancellare
                int indice = RicercaIndice(box_cancella.Text);

                // Se il prodotto non viene trovato, mostra un messaggio e interrompe l'esecuzione
                if (indice == -1)
                {
                    MessageBox.Show("Prodotto non trovato.");
                    return;
                }

                // Ricerca delle informazioni del prodotto basandosi sul nome
                string[] prodotto = RicercaProdotto(box_cancella.Text);
                string line;

                // Apertura del file in modalità scrittura per la cancellazione del prodotto
                using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Write))
                {
                    // Posizionamento del cursore nel file all'inizio del record del prodotto da cancellare
                    file.Seek(riempi * indice, SeekOrigin.Begin);

                    // Creazione della nuova linea del prodotto con l'indicatore di cancellazione
                    line = $"@{prodotto[0]};{prodotto[1]};{prodotto[2]};1;".PadRight(riempi - 4) + "##";

                    // Conversione della stringa in byte e scrittura nel file
                    byte[] bytes = Encoding.UTF8.GetBytes(line);
                    file.Write(bytes, 0, bytes.Length);
                }

                // Messaggio di successo dopo la cancellazione
                MessageBox.Show("Cancellazione completata con successo.");
            }
            catch (Exception ex)
            {
                // Gestione delle eccezioni durante la cancellazione e visualizzazione del messaggio di errore
                MessageBox.Show($"Si è verificato un errore durante la cancellazione del prodotto: {ex.Message}");
            }

            // Pulizia del campo di input dopo la cancellazione
            box_cancella.Clear();

        }
        private void DELETE_FISIC_Click(object sender, EventArgs e)
        {
            // Acquisizione del nome del prodotto da cancellare inserito dall'utente
            string nomeProdotto = box_cancella.Text;

            // Verifica se il campo è vuoto
            if (string.IsNullOrWhiteSpace(nomeProdotto))
            {
                MessageBox.Show("Inserisci il nome del prodotto da cancellare.");
                return;
            }
            try
            {
                // Ricerca dell'indice del prodotto da cancellare
                int indice = RicercaIndice(box_cancella.Text);

                // Se il prodotto non viene trovato, mostra un messaggio e interrompe l'esecuzione
                if (indice == -1)
                {
                    MessageBox.Show("Prodotto non trovato.");
                    return;
                }

                // Lettura di tutte le linee del file nel quale si trova il prodotto
                string[] linea = File.ReadAllLines(filePath);

                // Shift delle linee successive per sovrascrivere la linea da cancellare
                for (int i = indice; i < linea.Length - 1; i++)
                {
                    linea[i] = linea[i + 1];
                }

                // Apertura del file in modalità Truncate per eliminare il contenuto
                var file = new FileStream(filePath, FileMode.Truncate, FileAccess.Write, FileShare.Read);

                // Creazione di un nuovo writer per il file
                StreamWriter sw = new StreamWriter(file);

                // Scrittura di una stringa vuota per cancellare il contenuto
                sw.Write(string.Empty);

                // Chiusura del writer
                sw.Close();

                // Apertura del file in modalità Append per riscrivere il contenuto aggiornato
                var files = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read);

                // Creazione di un nuovo writer per il file
                StreamWriter sws = new StreamWriter(files);

                // Scrittura delle linee aggiornate nel file
                for (int i = 0; i < linea.Length - 1; i++)
                {
                    sws.WriteLine(linea[i]);
                }

                // Chiusura del writer
                sws.Close();

                // Messaggio di successo dopo la cancellazione
                MessageBox.Show("Cancellazione completata con successo.");
            }
            catch (Exception ex)
            {
                // Gestione delle eccezioni durante la cancellazione e visualizzazione del messaggio di errore
                MessageBox.Show($"Si è verificato un errore durante la cancellazione del prodotto: {ex.Message}");
            }

            // Pulizia del campo di input dopo la cancellazione
            box_cancella.Clear();
        }
        private void RECUPERA_Click(object sender, EventArgs e)
        {
            // Acquisizione dell'indice del prodotto da recuperare inserito dall'utente
            int indice = RicercaIndiceRecuperare(box_recuperoprd.Text);

            // Se il prodotto non viene trovato, mostra un messaggio e interrompe l'esecuzione
            if (indice == -1)
            {
                MessageBox.Show("Prodotto non trovato.");
                return;
            }

            // Ricerca delle informazioni del prodotto basandosi sul nome
            string[] prodotto = RicercaProdottoRecuperare(box_recuperoprd.Text);
            string line;

            try
            {
                // Apertura del file in modalità scrittura binaria
                using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Write))
                using (BinaryWriter writer = new BinaryWriter(file))
                {
                    // Posizionamento del cursore nel file all'inizio del record del prodotto da recuperare
                    file.Seek(riempi * indice, SeekOrigin.Begin);

                    // Creazione della nuova linea del prodotto con l'indicatore di recupero
                    line = $"{prodotto[0]};{prodotto[1]};{prodotto[2]};0;".PadRight(riempi - 4) + "##";

                    // Conversione della stringa in byte e scrittura nel file
                    byte[] bytes = Encoding.UTF8.GetBytes(line);
                    writer.Write(bytes, 0, bytes.Length);

                    // Pulizia del campo di input dopo il recupero
                    box_recuperoprd.Clear();
                }

                // Messaggio di successo dopo il recupero
                MessageBox.Show("Recupero completato con successo.");
            }
            catch (Exception ex)
            {
                // Gestione delle eccezioni durante il recupero e visualizzazione del messaggio di errore
                MessageBox.Show($"Si è verificato un errore durante il recupero del prodotto: {ex.Message}. ");
            }


        }

        private void SEARCH_Click(object sender, EventArgs e)
        {
            // Acquisizione della stringa di ricerca inserita dall'utente
            string a = box_ricerca.Text;

            // Chiamata alla funzione di ricerca e ottenimento dell'indice del prodotto
            int trovato = Ricerca(a, filePath);

            // Se il prodotto non viene trovato, mostra un messaggio, altrimenti mostra la posizione del prodotto
            if (trovato == -1)
            {
                MessageBox.Show("Il prodotto non è stato trovato / è stato cancellato.");
            }
            else
            {
                MessageBox.Show($"Il prodotto si trova nella riga {trovato + 1}");

                // Pulizia del campo di input dopo la ricerca
                box_ricerca.Clear();
            }

        }
        private void OPEN_FILE_Click(object sender, EventArgs e)
        {
            // Creazione del percorso completo del file "SaveList.txt" nell'omonima directory dell'eseguibile
            string percorsoFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "SaveList.txt");

            // Apertura del file con l'applicazione predefinita
            Process.Start(percorsoFile);

        }
        private void DELETE_FILE_Click(object sender, EventArgs e)
        {
            // Creazione di un nuovo FileStream con FileMode.Truncate per eliminare il contenuto del file
            var file = new FileStream(filePath, FileMode.Truncate, FileAccess.Write, FileShare.Read);

            // Creazione di un nuovo StreamWriter per il file
            StreamWriter sw = new StreamWriter(file);

            // Scrittura di una stringa vuota per cancellare il contenuto del file
            sw.Write(string.Empty);

            // Chiusura del writer
            sw.Close();

            // Messaggio di conferma della cancellazione
            MessageBox.Show($"Cancellazione eseguita.");

        }
        private void EXIT_Click(object sender, EventArgs e)
        {
            // Chiusura della applicazione con conferma
            DialogResult conferma = MessageBox.Show("Sei sicuro di voler uscire dal programma?", "Esci", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (conferma == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
