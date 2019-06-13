using Applicazioni.Common;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GalvanicaFrm
{
    public partial class GalvanicaModelloComponenteFrm : BaseForm
    {
        private GalvanicaDS.USR_PRD_MOVFASIRow _odl;

        public GalvanicaModelloComponenteFrm(GalvanicaDS.USR_PRD_MOVFASIRow odl)
        {
            _odl = odl;
            InitializeComponent();
        }

        private void GalvanicaModelloComponenteFrm_Load(object sender, EventArgs e)
        {
            lblModello.Text = string.Format("Modello: {0} - Componente: {1}", _odl.MODELLO_LANCIO, _odl.MODELLO_WIP);
        }
    }
}
