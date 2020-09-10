using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Applicazioni.Common
{
    public partial class ChildBaseForm : Form
    {
        protected string _utenteConnesso { get { return (MdiParent as BaseForm).Contesto.Utente.DisplayName; } }
        protected ContestoBase Contesto{ get { return (MdiParent as BaseForm).Contesto; } }

        protected bool _disabilitaEdit = false;
        protected void MostraEccezione(string messagioLog, Exception ex)
        {
            BaseForm form = (MdiParent as BaseForm);
            form.MostraEccezione(ex,messagioLog);
        }

        public ChildBaseForm()
        {
            InitializeComponent();
        }

        

        protected void Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
