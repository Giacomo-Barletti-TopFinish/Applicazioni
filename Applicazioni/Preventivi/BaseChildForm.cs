using Applicazioni.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preventivi
{
    public partial class BaseChildForm : BaseForm
    {
        public BaseChildForm()
        {
            InitializeComponent();
        }

        private void BaseChildForm_Load(object sender, EventArgs e)
        {
        }
        protected void MostraEccezione(Exception ex, string messaggioLog)
        {
            if (this.ParentForm != null)
                (this.ParentForm as PreventiviMainForm).MostraEccezione(messaggioLog, ex);
            else
            {
                base.MostraEccezione(ex, messaggioLog);
            }
        }
    }
}
