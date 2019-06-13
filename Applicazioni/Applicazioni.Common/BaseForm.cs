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
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }
        protected void MostraEccezione(Exception ex, string messaggioLog)
        {
            ExceptionFrm frm = new ExceptionFrm(ex);
            frm.ShowDialog();
        }
    }
}
