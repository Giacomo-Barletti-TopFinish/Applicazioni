using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpedizioniFrm
{
    public partial class MovimentiFrm : Form
    {
        public MovimentiFrm()
        {
            InitializeComponent();
        }

        private void MOVIMENTIFRM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 5) return;
            if (e.RowIndex < 0) return;
          
            
                if (e.ColumnIndex == 5)
                {
                    MovimentiFrm form = new MovimentiFrm();
                    form.ShowDialog();

                    //decimal idUbicazione = (decimal)dgvUbicazioni.Rows[e.RowIndex].Cells[0].Value;
                    //Spedizioni spedizioni = new Spedizioni();
                    //spedizioni.CancellaUbicazione(idUbicazione, _utenteConnesso);
                }
         }
            
    }

       
}
