using log4net;
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
        protected static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public BaseForm()
        {
            InitializeComponent();
        }
        protected virtual void MostraEccezione(Exception ex, string messaggioLog)
        {
            ExceptionFrm frm = new ExceptionFrm(ex);
            frm.ShowDialog();
        }

        protected void ScriviLogInfo(string messaggio)
        {
            Log.Info(messaggio);
        }
        protected void ScriviLogWarning(string messaggio)
        {
            Log.Warn(messaggio);
        }
        protected void ScriviLogErrore(string messaggio)
        {
            Log.Error(messaggio);
        }
        protected void ScriviLogErrore(string messaggio, Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(messaggio);

            while (ex != null)
            {
                sb.AppendLine(ex.Message);
                sb.AppendLine(ex.StackTrace);
                ex = ex.InnerException;
            }
            Log.Error(sb.ToString());
        }
    }
}
