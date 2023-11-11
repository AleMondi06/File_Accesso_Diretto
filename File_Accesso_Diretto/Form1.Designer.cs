namespace File_Accesso_Diretto
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
            this.EXIT = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.box_cancella = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.box_modifica = new System.Windows.Forms.TextBox();
            this.box_update = new System.Windows.Forms.TextBox();
            this.CREATE = new System.Windows.Forms.Button();
            this.UPDATE = new System.Windows.Forms.Button();
            this.DELETE = new System.Windows.Forms.Button();
            this.box_prezzo = new System.Windows.Forms.TextBox();
            this.prezzo_prodotto = new System.Windows.Forms.Label();
            this.box_prodotto = new System.Windows.Forms.TextBox();
            this.nome_art = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SEARCH = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.box_modifica_prezzo = new System.Windows.Forms.TextBox();
            this.OPEN_FILE = new System.Windows.Forms.Button();
            this.DELETE_LOGIC = new System.Windows.Forms.Button();
            this.RECUPERA = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.box_recupero = new System.Windows.Forms.TextBox();
            this.DELETE_FISIC = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.box_ricerca = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.box_recuperoprd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DELETE_FILE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EXIT
            // 
            this.EXIT.Location = new System.Drawing.Point(653, 376);
            this.EXIT.Name = "EXIT";
            this.EXIT.Size = new System.Drawing.Size(122, 64);
            this.EXIT.TabIndex = 87;
            this.EXIT.Text = "EXIT";
            this.EXIT.UseVisualStyleBackColor = true;
            this.EXIT.Click += new System.EventHandler(this.EXIT_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "prodotto da cancellare";
            // 
            // box_cancella
            // 
            this.box_cancella.Location = new System.Drawing.Point(274, 199);
            this.box_cancella.Name = "box_cancella";
            this.box_cancella.Size = new System.Drawing.Size(130, 20);
            this.box_cancella.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 79;
            this.label2.Text = "nuovo nome ";
            // 
            // box_modifica
            // 
            this.box_modifica.Location = new System.Drawing.Point(15, 318);
            this.box_modifica.Name = "box_modifica";
            this.box_modifica.Size = new System.Drawing.Size(138, 20);
            this.box_modifica.TabIndex = 77;
            // 
            // box_update
            // 
            this.box_update.Location = new System.Drawing.Point(15, 279);
            this.box_update.Name = "box_update";
            this.box_update.Size = new System.Drawing.Size(138, 20);
            this.box_update.TabIndex = 76;
            // 
            // CREATE
            // 
            this.CREATE.Location = new System.Drawing.Point(12, 87);
            this.CREATE.Name = "CREATE";
            this.CREATE.Size = new System.Drawing.Size(90, 77);
            this.CREATE.TabIndex = 74;
            this.CREATE.Text = "CREATE";
            this.CREATE.UseVisualStyleBackColor = true;
            this.CREATE.Click += new System.EventHandler(this.CREATE_Click);
            // 
            // UPDATE
            // 
            this.UPDATE.Location = new System.Drawing.Point(12, 183);
            this.UPDATE.Name = "UPDATE";
            this.UPDATE.Size = new System.Drawing.Size(90, 77);
            this.UPDATE.TabIndex = 73;
            this.UPDATE.Text = "UPDATE";
            this.UPDATE.UseVisualStyleBackColor = true;
            this.UPDATE.Click += new System.EventHandler(this.UPDATE_Click);
            // 
            // DELETE
            // 
            this.DELETE.Location = new System.Drawing.Point(0, 0);
            this.DELETE.Name = "DELETE";
            this.DELETE.Size = new System.Drawing.Size(75, 23);
            this.DELETE.TabIndex = 97;
            // 
            // box_prezzo
            // 
            this.box_prezzo.Location = new System.Drawing.Point(226, 37);
            this.box_prezzo.Name = "box_prezzo";
            this.box_prezzo.Size = new System.Drawing.Size(138, 20);
            this.box_prezzo.TabIndex = 71;
            // 
            // prezzo_prodotto
            // 
            this.prezzo_prodotto.AutoSize = true;
            this.prezzo_prodotto.Location = new System.Drawing.Point(237, 11);
            this.prezzo_prodotto.Name = "prezzo_prodotto";
            this.prezzo_prodotto.Size = new System.Drawing.Size(51, 13);
            this.prezzo_prodotto.TabIndex = 70;
            this.prezzo_prodotto.Text = "PREZZO";
            // 
            // box_prodotto
            // 
            this.box_prodotto.Location = new System.Drawing.Point(29, 37);
            this.box_prodotto.Name = "box_prodotto";
            this.box_prodotto.Size = new System.Drawing.Size(138, 20);
            this.box_prodotto.TabIndex = 69;
            // 
            // nome_art
            // 
            this.nome_art.AutoSize = true;
            this.nome_art.Location = new System.Drawing.Point(26, 11);
            this.nome_art.Name = "nome_art";
            this.nome_art.Size = new System.Drawing.Size(68, 13);
            this.nome_art.TabIndex = 67;
            this.nome_art.Text = "PRODOTTO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "nome del prodotto da modificare";
            // 
            // SEARCH
            // 
            this.SEARCH.Location = new System.Drawing.Point(139, 87);
            this.SEARCH.Name = "SEARCH";
            this.SEARCH.Size = new System.Drawing.Size(90, 77);
            this.SEARCH.TabIndex = 88;
            this.SEARCH.Text = "SEARCH";
            this.SEARCH.UseVisualStyleBackColor = true;
            this.SEARCH.Click += new System.EventHandler(this.SEARCH_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 90;
            this.label4.Text = "nuovo prezzo";
            // 
            // box_modifica_prezzo
            // 
            this.box_modifica_prezzo.Location = new System.Drawing.Point(15, 358);
            this.box_modifica_prezzo.Name = "box_modifica_prezzo";
            this.box_modifica_prezzo.Size = new System.Drawing.Size(138, 20);
            this.box_modifica_prezzo.TabIndex = 89;
            // 
            // OPEN_FILE
            // 
            this.OPEN_FILE.Location = new System.Drawing.Point(613, 54);
            this.OPEN_FILE.Name = "OPEN_FILE";
            this.OPEN_FILE.Size = new System.Drawing.Size(162, 206);
            this.OPEN_FILE.TabIndex = 91;
            this.OPEN_FILE.Text = "OPEN FILE ";
            this.OPEN_FILE.UseVisualStyleBackColor = true;
            this.OPEN_FILE.Click += new System.EventHandler(this.OPEN_FILE_Click);
            // 
            // DELETE_LOGIC
            // 
            this.DELETE_LOGIC.Location = new System.Drawing.Point(274, 85);
            this.DELETE_LOGIC.Name = "DELETE_LOGIC";
            this.DELETE_LOGIC.Size = new System.Drawing.Size(90, 77);
            this.DELETE_LOGIC.TabIndex = 92;
            this.DELETE_LOGIC.Text = "DELETE LOGIC";
            this.DELETE_LOGIC.UseVisualStyleBackColor = true;
            this.DELETE_LOGIC.Click += new System.EventHandler(this.DELETE_LOGIC_Click);
            // 
            // RECUPERA
            // 
            this.RECUPERA.Location = new System.Drawing.Point(417, 85);
            this.RECUPERA.Name = "RECUPERA";
            this.RECUPERA.Size = new System.Drawing.Size(90, 77);
            this.RECUPERA.TabIndex = 93;
            this.RECUPERA.Text = "RECUPERA";
            this.RECUPERA.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.RECUPERA.UseVisualStyleBackColor = true;
            this.RECUPERA.Click += new System.EventHandler(this.RECUPERA_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 100;
            // 
            // box_recupero
            // 
            this.box_recupero.Location = new System.Drawing.Point(0, 0);
            this.box_recupero.Name = "box_recupero";
            this.box_recupero.Size = new System.Drawing.Size(100, 20);
            this.box_recupero.TabIndex = 101;
            // 
            // DELETE_FISIC
            // 
            this.DELETE_FISIC.Location = new System.Drawing.Point(274, 231);
            this.DELETE_FISIC.Name = "DELETE_FISIC";
            this.DELETE_FISIC.Size = new System.Drawing.Size(90, 77);
            this.DELETE_FISIC.TabIndex = 96;
            this.DELETE_FISIC.Text = "DELETE FISIC";
            this.DELETE_FISIC.UseVisualStyleBackColor = true;
            this.DELETE_FISIC.Click += new System.EventHandler(this.DELETE_FISIC_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(136, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 13);
            this.label6.TabIndex = 99;
            this.label6.Text = "indice prodotto da ricercare";
            // 
            // box_ricerca
            // 
            this.box_ricerca.Location = new System.Drawing.Point(138, 199);
            this.box_ricerca.Name = "box_ricerca";
            this.box_ricerca.Size = new System.Drawing.Size(130, 20);
            this.box_ricerca.TabIndex = 98;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(414, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 103;
            this.label7.Text = "prodotto da recuperare";
            // 
            // box_recuperoprd
            // 
            this.box_recuperoprd.Location = new System.Drawing.Point(417, 199);
            this.box_recuperoprd.Name = "box_recuperoprd";
            this.box_recuperoprd.Size = new System.Drawing.Size(130, 20);
            this.box_recuperoprd.TabIndex = 102;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 104;
            this.label8.Text = "PRODOTTO";
            // 
            // DELETE_FILE
            // 
            this.DELETE_FILE.Location = new System.Drawing.Point(617, 291);
            this.DELETE_FILE.Name = "DELETE_FILE";
            this.DELETE_FILE.Size = new System.Drawing.Size(158, 64);
            this.DELETE_FILE.TabIndex = 105;
            this.DELETE_FILE.Text = "DELETE FILE ";
            this.DELETE_FILE.UseVisualStyleBackColor = true;
            this.DELETE_FILE.Click += new System.EventHandler(this.DELETE_FILE_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DELETE_FILE);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.box_recuperoprd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.box_ricerca);
            this.Controls.Add(this.DELETE_FISIC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.box_recupero);
            this.Controls.Add(this.RECUPERA);
            this.Controls.Add(this.DELETE_LOGIC);
            this.Controls.Add(this.OPEN_FILE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.box_modifica_prezzo);
            this.Controls.Add(this.SEARCH);
            this.Controls.Add(this.EXIT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.box_cancella);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.box_modifica);
            this.Controls.Add(this.box_update);
            this.Controls.Add(this.CREATE);
            this.Controls.Add(this.UPDATE);
            this.Controls.Add(this.DELETE);
            this.Controls.Add(this.box_prezzo);
            this.Controls.Add(this.prezzo_prodotto);
            this.Controls.Add(this.box_prodotto);
            this.Controls.Add(this.nome_art);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button EXIT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox box_cancella;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox box_modifica;
        private System.Windows.Forms.TextBox box_update;
        private System.Windows.Forms.Button CREATE;
        private System.Windows.Forms.Button UPDATE;
        private System.Windows.Forms.Button DELETE;
        private System.Windows.Forms.TextBox box_prezzo;
        private System.Windows.Forms.Label prezzo_prodotto;
        private System.Windows.Forms.TextBox box_prodotto;
        private System.Windows.Forms.Label nome_art;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SEARCH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox box_modifica_prezzo;
        private System.Windows.Forms.Button OPEN_FILE;
        private System.Windows.Forms.Button DELETE_LOGIC;
        private System.Windows.Forms.Button RECUPERA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox box_recupero;
        private System.Windows.Forms.Button DELETE_FISIC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox box_ricerca;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox box_recuperoprd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button DELETE_FILE;
    }
}

