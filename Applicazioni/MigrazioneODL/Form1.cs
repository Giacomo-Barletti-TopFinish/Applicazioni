using Applicazioni.Data.EstraiProdottiFiniti;
using Applicazioni.Data.MigrazioneODL;
using Applicazioni.Entities;
using EstraiProdottiFiniti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MigrazioneODL
{
    public partial class Form1 : Form
    {
        private MigrazioneODLDS _ds = new MigrazioneODLDS();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCercaODL_Click(object sender, EventArgs e)
        {
            _ds = new MigrazioneODLDS();
            string barcode = txtBarcodeODL.Text;
            txtBarcodeODL.Text = string.Empty;

            txtIDPRDMOVFASE.Text = string.Empty;
            txtAZIENDA.Text = string.Empty;
            txtREPARTO.Text = string.Empty;
            txtFASE.Text = string.Empty;
            txtIDMAGAZZ.Text = string.Empty;
            txtArticolo.Text = string.Empty;
            txtQtaDaTer.Text = string.Empty;
            txtQuantita.Text = string.Empty;
            txtDescVersione.Text = string.Empty;

            if (!string.IsNullOrEmpty(barcode))
            {
                MigrazioneODLDS.USR_PRD_MOVFASIRow odl = estraDatiODL(barcode);

                trovaAnagraficaPerMigrazione(odl);
            }
        }

        private MigrazioneODLDS.USR_PRD_MOVFASIRow estraDatiODL(string barcode)
        {
            using (MigrazioneODLBusiness bMigrazioneODL = new MigrazioneODLBusiness())
            {
                bMigrazioneODL.GetUSR_PRD_MOVFASI(_ds, barcode);


                MigrazioneODLDS.USR_PRD_MOVFASIRow odl = _ds.USR_PRD_MOVFASI.Where(x => x.BARCODE == barcode).FirstOrDefault();
                if (odl != null)
                {

                    bMigrazioneODL.GetCLIFO(_ds, odl.CODICECLIFO);
                    MigrazioneODLDS.CLIFORow reparto = _ds.CLIFO.Where(x => x.CODICE == odl.CODICECLIFO).FirstOrDefault();

                    bMigrazioneODL.GetTABFAS(_ds, odl.IDTABFAS);
                    MigrazioneODLDS.TABFASRow fase = _ds.TABFAS.Where(x => x.IDTABFAS == odl.IDTABFAS).FirstOrDefault();

                    bMigrazioneODL.GetMAGAZZ(_ds, odl.IDMAGAZZ);
                    MigrazioneODLDS.MAGAZZRow articolo = _ds.MAGAZZ.Where(x => x.IDMAGAZZ == odl.IDMAGAZZ).FirstOrDefault();

                    txtIDPRDMOVFASE.Text = odl.IDPRDMOVFASE;
                    txtAZIENDA.Text = odl.AZIENDA;
                    txtREPARTO.Text = reparto.RAGIONESOC.Trim();
                    txtFASE.Text = fase.CODICEFASE.Trim();
                    txtIDMAGAZZ.Text = articolo.IDMAGAZZ.Trim();
                    txtArticolo.Text = articolo.MODELLO.Trim();
                    txtQuantita.Text = odl.QTA.ToString();
                    txtQtaDaTer.Text = odl.QTADATER.ToString();
                    txtMetodoDiba.Text = odl.IDDIBAMETHOD;
                    txtVersioneDiba.Text = odl.VERSION.ToString();
                    txtDescVersione.Text = odl.DESVERSION.Trim();
                }
                return odl;
            }
        }

        private void trovaAnagraficaPerMigrazione(MigrazioneODLDS.USR_PRD_MOVFASIRow odl)
        {
            if (odl.IsIDMAGAZZNull()) return;


            string idmagazz = odl.IDMAGAZZ;

            using (MigrazioneODLBusiness bMigrazioneODL = new MigrazioneODLBusiness())
            {
                bool continua = true; ;
                bMigrazioneODL.GetANAGRAFICA(_ds, idmagazz);

                MigrazioneODLDS.BC_ANAGRAFICA_PRODUZIONERow anagrafica = _ds.BC_ANAGRAFICA_PRODUZIONE.Where(x => x.IDMAGAZZ == idmagazz).FirstOrDefault();
                if (anagrafica != null)
                {
                    txtAnagrafica.Text = (anagrafica == null) ? string.Empty : anagrafica.BC;
                    return;
                }
                bMigrazioneODL.GetUSR_PRD_TDIBA(_ds, idmagazz, odl.IDDIBAMETHOD, odl.VERSION, odl.DESVERSION);
                MigrazioneODLDS.USR_PRD_TDIBARow diba = _ds.USR_PRD_TDIBA.Where(x => x.IDMAGAZZ == idmagazz && x.IDDIBAMETHOD.Trim() == odl.IDDIBAMETHOD && x.VERSION == odl.VERSION && x.DESVERSION.Trim() == odl.DESVERSION).FirstOrDefault();

                if (diba == null) return;

                string idTdiba = diba.IDTDIBA;
                string azienda = diba.AZIENDA;

                while (anagrafica == null && continua)
                {
                    bMigrazioneODL.GetUSR_PRD_TDIBA1(_ds, idTdiba, azienda);
                    MigrazioneODLDS.USR_PRD_TDIBA1Row diba1 = _ds.USR_PRD_TDIBA1.Where(x => x.IDTDIBAIFFASE == idTdiba && x.AZIENDA == azienda).FirstOrDefault();
                    if (diba1 == null)
                        continua = false;
                    else if (!diba1.IsIDMAGAZZNull())
                    {
                        idTdiba = diba1.IDTDIBA;
                        azienda = diba1.AZIENDA;

                        idmagazz = diba1.IDMAGAZZ;
                        bMigrazioneODL.GetANAGRAFICA(_ds, idmagazz);
                        anagrafica = _ds.BC_ANAGRAFICA_PRODUZIONE.Where(x => x.IDMAGAZZ == idmagazz).FirstOrDefault();
                    }
                }

                txtAnagrafica.Text = (anagrafica == null) ? string.Empty : anagrafica.BC;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            txtBarcodeODL.Focus();
            ActiveControl = txtBarcodeODL;
        }

        private void btnSCaricaNodi_Click(object sender, EventArgs e)
        {
            _ds = new MigrazioneODLDS();
            using (MigrazioneODLBusiness bMigrazioneODL = new MigrazioneODLBusiness())
            {
                bMigrazioneODL.GetPRODOTTIFINITI(_ds);
            }

            foreach(MigrazioneODLDS.BC_ANAGRAFICA_PRODUZIONERow prodottoFinito in _ds.BC_ANAGRAFICA_PRODUZIONE)
            {
                EstraiProdottoFinito form = new EstraiProdottoFinito();
                List<Nodo> Nodi = form.CreaListaNodi(prodottoFinito.MODELLO);
            }
        }
    }
}
