namespace AACPGFrm
{
    partial class AACPGFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTelaio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtODL = new System.Windows.Forms.TextBox();
            this.lblMessaggi = new System.Windows.Forms.Label();
            this.btnAvvia = new System.Windows.Forms.Button();
            this.btnTermina = new System.Windows.Forms.Button();
            this.btnCancella = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbArticolo = new System.Windows.Forms.PictureBox();
            this.txtSuperficie = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModello = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOrdineLavoro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQuantita = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArticolo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Telaio";
            // 
            // txtTelaio
            // 
            this.txtTelaio.Location = new System.Drawing.Point(75, 12);
            this.txtTelaio.Name = "txtTelaio";
            this.txtTelaio.Size = new System.Drawing.Size(237, 24);
            this.txtTelaio.TabIndex = 1;
            this.txtTelaio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTelaio_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "O.d.L.";
            // 
            // txtODL
            // 
            this.txtODL.Location = new System.Drawing.Point(438, 12);
            this.txtODL.Name = "txtODL";
            this.txtODL.Size = new System.Drawing.Size(237, 24);
            this.txtODL.TabIndex = 2;
            this.txtODL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtODL_KeyDown);
            // 
            // lblMessaggi
            // 
            this.lblMessaggi.AutoSize = true;
            this.lblMessaggi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessaggi.ForeColor = System.Drawing.Color.Red;
            this.lblMessaggi.Location = new System.Drawing.Point(12, 41);
            this.lblMessaggi.Name = "lblMessaggi";
            this.lblMessaggi.Size = new System.Drawing.Size(73, 18);
            this.lblMessaggi.TabIndex = 0;
            this.lblMessaggi.Text = "lblErrore";
            // 
            // btnAvvia
            // 
            this.btnAvvia.Location = new System.Drawing.Point(747, 8);
            this.btnAvvia.Name = "btnAvvia";
            this.btnAvvia.Size = new System.Drawing.Size(87, 32);
            this.btnAvvia.TabIndex = 3;
            this.btnAvvia.Text = "Avvia";
            this.btnAvvia.UseVisualStyleBackColor = true;
            this.btnAvvia.Click += new System.EventHandler(this.btnAvvia_Click);
            // 
            // btnTermina
            // 
            this.btnTermina.Location = new System.Drawing.Point(857, 8);
            this.btnTermina.Name = "btnTermina";
            this.btnTermina.Size = new System.Drawing.Size(87, 32);
            this.btnTermina.TabIndex = 4;
            this.btnTermina.Text = "Termina";
            this.btnTermina.UseVisualStyleBackColor = true;
            // 
            // btnCancella
            // 
            this.btnCancella.Location = new System.Drawing.Point(747, 57);
            this.btnCancella.Name = "btnCancella";
            this.btnCancella.Size = new System.Drawing.Size(197, 32);
            this.btnCancella.TabIndex = 5;
            this.btnCancella.Text = "Cancella tutto";
            this.btnCancella.UseVisualStyleBackColor = true;
            this.btnCancella.Click += new System.EventHandler(this.btnCancella_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbArticolo);
            this.groupBox1.Controls.Add(this.txtSuperficie);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDescrizione);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtQuantita);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtModello);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtOrdineLavoro);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(15, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(929, 399);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ORDINE DI LAVORO";
            // 
            // pbArticolo
            // 
            this.pbArticolo.Location = new System.Drawing.Point(6, 23);
            this.pbArticolo.Name = "pbArticolo";
            this.pbArticolo.Size = new System.Drawing.Size(369, 370);
            this.pbArticolo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbArticolo.TabIndex = 0;
            this.pbArticolo.TabStop = false;
            // 
            // txtSuperficie
            // 
            this.txtSuperficie.Location = new System.Drawing.Point(545, 295);
            this.txtSuperficie.Name = "txtSuperficie";
            this.txtSuperficie.ReadOnly = true;
            this.txtSuperficie.Size = new System.Drawing.Size(353, 24);
            this.txtSuperficie.TabIndex = 2;
            this.txtSuperficie.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtODL_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(435, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "SUPERFICIE";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(545, 245);
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.Size = new System.Drawing.Size(353, 24);
            this.txtDescrizione.TabIndex = 2;
            this.txtDescrizione.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtODL_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(422, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "DESCRIZIONE";
            // 
            // txtModello
            // 
            this.txtModello.Location = new System.Drawing.Point(545, 201);
            this.txtModello.Name = "txtModello";
            this.txtModello.ReadOnly = true;
            this.txtModello.Size = new System.Drawing.Size(353, 24);
            this.txtModello.TabIndex = 2;
            this.txtModello.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtODL_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(449, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "MODELLO";
            // 
            // txtOrdineLavoro
            // 
            this.txtOrdineLavoro.Location = new System.Drawing.Point(545, 55);
            this.txtOrdineLavoro.Name = "txtOrdineLavoro";
            this.txtOrdineLavoro.ReadOnly = true;
            this.txtOrdineLavoro.Size = new System.Drawing.Size(353, 24);
            this.txtOrdineLavoro.TabIndex = 2;
            this.txtOrdineLavoro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtODL_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "ORDINE DI LAVORO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 503);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Token";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(84, 500);
            this.txtToken.Name = "txtToken";
            this.txtToken.ReadOnly = true;
            this.txtToken.Size = new System.Drawing.Size(306, 24);
            this.txtToken.TabIndex = 1;
            this.txtToken.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTelaio_KeyDown);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(400, 512);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(544, 196);
            this.txtMessage.TabIndex = 7;
            this.txtMessage.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(447, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "QUANTITA\'";
            // 
            // txtQuantita
            // 
            this.txtQuantita.Location = new System.Drawing.Point(545, 99);
            this.txtQuantita.Name = "txtQuantita";
            this.txtQuantita.Size = new System.Drawing.Size(353, 24);
            this.txtQuantita.TabIndex = 2;
            this.txtQuantita.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtODL_KeyDown);
            // 
            // AACPGFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 731);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancella);
            this.Controls.Add(this.btnTermina);
            this.Controls.Add(this.btnAvvia);
            this.Controls.Add(this.txtODL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.txtTelaio);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblMessaggi);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AACPGFrm";
            this.Text = "AACPG";
            this.Load += new System.EventHandler(this.AACPGFrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbArticolo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTelaio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtODL;
        private System.Windows.Forms.Label lblMessaggi;
        private System.Windows.Forms.Button btnAvvia;
        private System.Windows.Forms.Button btnTermina;
        private System.Windows.Forms.Button btnCancella;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbArticolo;
        private System.Windows.Forms.TextBox txtSuperficie;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtModello;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOrdineLavoro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.TextBox txtQuantita;
        private System.Windows.Forms.Label label8;
    }
}

