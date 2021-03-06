﻿using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstraiProdottiFiniti
{
    public partial class SelezionaDIbaFrm : Form
    {
        public string IDTDIBA = string.Empty;
        public string NotaStd = string.Empty;
        public string Versione = string.Empty;
        public string Modello = string.Empty;
        public SelezionaDIbaFrm()
        {
            InitializeComponent();
        }


        private void dgvDiBa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IDTDIBA = estraiProdottiFinitiDS1.USR_PRD_TDIBA.Rows[e.RowIndex]["IDTDIBA"].ToString();
            NotaStd = estraiProdottiFinitiDS1.USR_PRD_TDIBA.Rows[e.RowIndex]["NOTESTD"].ToString();
            Versione = estraiProdottiFinitiDS1.USR_PRD_TDIBA.Rows[e.RowIndex]["DESVERSION"].ToString();
            Modello = estraiProdottiFinitiDS1.USR_PRD_TDIBA.Rows[e.RowIndex]["MODELLO"].ToString();
            DialogResult = DialogResult.OK;
        }

        private void SelezionaDIbaFrm_Load(object sender, EventArgs e)
        {
            int i = estraiProdottiFinitiDS1.USR_PRD_TDIBA.Rows.Count;
            dgvDiBa.DataSource = estraiProdottiFinitiDS1;
            dgvDiBa.Update();
        }
    
    }
}
