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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public struct Prezzoprodotto
        {
            public string prodotto;
            public double prezzo;
        }

        public Prezzoprodotto[] p = new Prezzoprodotto[100];
        public int dim = 0;
        public string filePath = "SaveList.txt";
        public int riempi = 64;

        private void aggiunta(string nome, double prezzo, string filePath)
        {
            var apertura = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader reader = new StreamReader(apertura);
            string line;
            int riga = 0;

            while ((line = reader.ReadLine()) != null)
            {
                string[] dati = line.Split(';');

                if (dati[0] == nome && Convert.ToDouble(dati[1]) == prezzo)
                {
                    // Trovato un prodotto con lo stesso nome e prezzo, incrementa la terza colonna
                    int quantita = Convert.ToInt32(dati[2]);
                    quantita++;
                    apertura.Close();
                    UpdateQuantita(filePath, riga, quantita);
                    return;
                }

                riga++;
            }

            // Se non trova un prodotto con lo stesso nome e prezzo, aggiungi un nuovo prodotto
            apertura.Close();
            var scrittura = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter write = new StreamWriter(scrittura);
            write.WriteLine($"{nome};{prezzo};1;0;".PadRight(riempi - 4) + "##");
            write.Close();
            MessageBox.Show("Prodotto salvato con successo.");
            box_prodotto.Clear();
            box_prezzo.Clear();
        }
        private void UpdateQuantita(string filePath, int riga, int nuovaQuantita)
        {
            string[] linee = File.ReadAllLines(filePath);
            linee[riga] = linee[riga].Replace(linee[riga].Split(';')[2], nuovaQuantita.ToString());

            var file = new FileStream(filePath, FileMode.Truncate, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(file);
            sw.Write(string.Empty);
            sw.Close();

            var files = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sws = new StreamWriter(files);

            foreach (string linea in linee)
            {
                sws.WriteLine(linea);
            }
            MessageBox.Show("Prodotto inserito piú volte con successo.");
            box_prodotto.Clear();
            box_prezzo.Clear();
            sws.Close();
        }
        public int ricercaindice(string nome)
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

        public string[] ricercaprod(string nome)
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

        public int ricerca(string nome, string filePath)
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

        public string[] ricercaprodrecuperare(string nome)
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText(filePath))
            {

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dati = line.Split(';');
                    dati[0] = dati[0].Remove(0, 1);
                    if (dati[3] == "1" && String.Equals(dati[0],nome))
                    {
                        sr.Close();
                        return dati;
                    }
                    riga++;
                }
            }
            return null;
        }

        public int ricercaindicedarecuperare(string nome)
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


        private void CREATE_Click(object sender, EventArgs e)
        {
            string nomeProdottoDaCancellare = box_prodotto.Text;

            bool c = false;
            bool y = false;

            if (string.IsNullOrWhiteSpace(nomeProdottoDaCancellare))
            {
                MessageBox.Show("Inserisci il nome del prodotto.");
                return;
            }
            if (c == false)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(box_prezzo.Text, "[^0-9]") || string.IsNullOrWhiteSpace(box_prezzo.Text))
                {
                    MessageBox.Show("inserisci un valore / Inserire dei valori numerici e non lettere");
                    y = true;
                }
                if (y == false)
                {
                    p[dim].prodotto = box_prodotto.Text;
                    p[dim].prezzo = float.Parse(box_prezzo.Text);
                    aggiunta(p[dim].prodotto, p[dim].prezzo, filePath);
                    dim++;

                }
            }
        }
        private void UPDATE_Click(object sender, EventArgs e)
        {
            string NomeVecchio = box_update.Text;
            string NomeNuovo = box_modifica.Text;
            string PrezzoNuovo = box_modifica_prezzo.Text;

            if (string.IsNullOrWhiteSpace(NomeVecchio) || string.IsNullOrWhiteSpace(NomeNuovo) || string.IsNullOrWhiteSpace(PrezzoNuovo))
            {
                MessageBox.Show("Inserisci un vecchio nome e un nuovo nome per la modifica.");
                return;
            }

            try
            {
                
                int indice = ricercaindice(box_update.Text);

                if (indice == -1)
                {
                    MessageBox.Show("prodotto non trovato.");
                    return;
                }

                string[] prodotto = ricercaprod(box_update.Text);
                string line;

                using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Write))
                {
                    file.Seek(riempi * indice, SeekOrigin.Begin);
                    line = $"{box_modifica.Text};{prodotto[1]};{prodotto[2]};0;".PadRight(riempi - 4) + "##";
                    byte[] bytes = Encoding.UTF8.GetBytes(line);
                    file.Write(bytes, 0, bytes.Length);
                }

                MessageBox.Show("Modifica completata con successo.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Si è verificato un errore durante la modifica del nome: {ex.Message}");
            }

            box_update.Clear();
            box_modifica.Clear();
            box_modifica_prezzo.Clear();

        }
        private void DELETE_LOGIC_Click(object sender, EventArgs e)
        {
            string nomeProdotto = box_cancella.Text;

            if (string.IsNullOrWhiteSpace(nomeProdotto))
            {
                MessageBox.Show("Inserisci il nome del prodotto da cancellare.");
                return;
            }

            try
            {
                int indice = ricercaindice(box_cancella.Text);

                if (indice == -1)
                {
                    MessageBox.Show("Prodotto non trovato.");
                    return;
                }

                string[] prodotto = ricercaprod(box_cancella.Text);
                string line;

                using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Write))
                {
                    file.Seek(riempi * indice, SeekOrigin.Begin);
                    line = $"@{prodotto[0]};{prodotto[1]};{prodotto[2]};1;".PadRight(riempi - 4) + "##";
                    byte[] bytes = Encoding.UTF8.GetBytes(line);
                    file.Write(bytes, 0, bytes.Length);
                }

                MessageBox.Show("Cancellazione completata con successo.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Si è verificato un errore durante la cancellazione del prodotto: {ex.Message}");
            }

            box_cancella.Clear();
        }
        private void DELETE_FISIC_Click(object sender, EventArgs e)
        {
            string nomeProdotto = box_cancella.Text;

            if (string.IsNullOrWhiteSpace(nomeProdotto))
            {
                MessageBox.Show("Inserisci il nome del prodotto da cancellare.");
                return;
            }
            try
            {
                int indice = ricercaindice(box_cancella.Text);
                if (indice == -1)
                {
                    MessageBox.Show("Prodotto non trovato.");
                    return;
                }
                string[] linea = File.ReadAllLines(filePath);
                for (int i = indice; i < linea.Length - 1; i++)
                {
                    linea[i] = linea[i + 1];
                }

                var file = new FileStream(filePath, FileMode.Truncate, FileAccess.Write, FileShare.Read);
                StreamWriter sw = new StreamWriter(file);
                sw.Write(string.Empty);
                sw.Close();

                var files = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read);
                StreamWriter sws = new StreamWriter(files);
                for (int i = 0; i < linea.Length - 1; i++)
                {
                    sws.WriteLine(linea[i]);
                }
                sws.Close();
                MessageBox.Show("Cancellazione completata con successo.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Si è verificato un errore durante la cancellazione del prodotto: {ex.Message}");
            }
            box_cancella.Clear();


        }
        private void RECUPERA_Click(object sender, EventArgs e)
        {
            int indice = ricercaindicedarecuperare(box_recuperoprd.Text);
            
            if (indice == -1)
            {
                MessageBox.Show("Prodotto non trovato.");
                return;
            }

            string[] prodotto = ricercaprodrecuperare(box_recuperoprd.Text);
            string line;

            try
            {
                using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Write))
                using (BinaryWriter writer = new BinaryWriter(file))
                {
                    file.Seek(riempi * indice, SeekOrigin.Begin);
                    line = $"{prodotto[0]};{prodotto[1]};{prodotto[2]};0;".PadRight(riempi - 4) + "##";
                    byte[] bytes = Encoding.UTF8.GetBytes(line);
                    writer.Write(bytes, 0, bytes.Length);
                    box_recuperoprd.Clear();
                }

                MessageBox.Show("Recupero completato con successo.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Si è verificato un errore durante il recupero del prodotto: {ex.Message}. ");
            }

        }

        private void SEARCH_Click(object sender, EventArgs e)
        {
            string a = box_ricerca.Text;
            int trovato = ricerca(a, filePath);
            if (trovato == -1)
            {
                MessageBox.Show("Il prodotto non è stato trovato");
            }
            else
            {
                MessageBox.Show($"Il prodotto si trova nella riga {trovato + 1}");
                box_ricerca.Clear();
            }
        }
        private void OPEN_FILE_Click(object sender, EventArgs e)
        {
            string percorsoFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "SaveList.txt");
            Process.Start(percorsoFile);
        }
        private void DELETE_FILE_Click(object sender, EventArgs e)
        {
            var file = new FileStream(filePath, FileMode.Truncate, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(file);
            sw.Write(string.Empty);
            sw.Close();
            MessageBox.Show($"cancellazione eseguita.");
        }
        private void EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
