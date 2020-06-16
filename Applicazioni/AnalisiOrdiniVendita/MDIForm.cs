using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalisiOrdiniVendita
{
    public partial class MDIForm : Form
    {
        public MDIForm()
        {
            InitializeComponent();
        }

        private void MDIForm_Load(object sender, EventArgs e)
        {
            RicercaForm form = new RicercaForm();
            form.MdiParent = this;
            form.Show();
        }
    }
}
