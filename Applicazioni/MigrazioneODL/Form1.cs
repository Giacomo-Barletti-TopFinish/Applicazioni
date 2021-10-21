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
            txtAnagrafica.Text = string.Empty;

            if (!string.IsNullOrEmpty(barcode))
            {
                MigrazioneODLDS.USR_PRD_MOVFASIRow odl = estraDatiODL(barcode);

                if (trovaAnagraficaPerMigrazione(odl))
                {
                    txtDescrizioneODV.Text = string.Format("{0} {1}", odl.NUMMOVFASE, odl.DATAMOVFASE.ToShortDateString());
                    txtDescrizione2ODV.Text = string.Format("{0} - {1}", txtREPARTO.Text, txtFASE.Text);
                    caricaComponenti();
                }
            }
        }

        private void caricaComponenti()
        {
            txtComponentiODV.Text = string.Empty;
            using (MigrazioneODLSQLBusiness bMigrazione = new MigrazioneODLSQLBusiness())
            {
                bMigrazione.GetDistinteBCDettaglio(_ds, txtAnagrafica.Text);
                StringBuilder sb = new StringBuilder();

                foreach(MigrazioneODLDS.DistinteBCDettaglioRow dettaglio in _ds.DistinteBCDettaglio.Where(x=>x.Production_BOM_No_==txtAnagrafica.Text))
                {
                    sb.AppendLine(string.Format("{0} - qta: {1}",dettaglio.No_,dettaglio.Quantity_per));
                }
                txtComponentiODV.Text = sb.ToString();
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

        private bool trovaAnagraficaPerMigrazione(MigrazioneODLDS.USR_PRD_MOVFASIRow odl)
        {
            txtAnagrafica.Text = string.Empty;
            if (odl.IsIDMAGAZZNull()) return false;


            string idmagazz = odl.IDMAGAZZ;

            using (MigrazioneODLBusiness bMigrazioneODL = new MigrazioneODLBusiness())
            {
                bool continua = true;
                MigrazioneODLDS.BC_ANAGRAFICA_PRODUZIONERow anagrafica = bMigrazioneODL.GetANAGRAFICA(_ds, idmagazz);

                if (anagrafica != null)
                {
                    txtAnagrafica.Text = (anagrafica == null) ? string.Empty : anagrafica.BC;
                    return true;
                }
                bMigrazioneODL.FillBC_MIGRAZIONE(_ds);
                MigrazioneODLDS.BC_MIGRAZIONERow riga = _ds.BC_MIGRAZIONE.Where(x => x.IDMAGAZZ == idmagazz).FirstOrDefault();
                if (riga == null) return false;
                decimal iddiba = riga.DIBA;
                decimal idnodo = riga.IDNODO;
                while (anagrafica == null && continua)
                {
                    riga = _ds.BC_MIGRAZIONE.Where(x => x.IDNODO == idnodo && x.DIBA == iddiba).FirstOrDefault();
                    if (riga == null)
                    {
                        continua = false;
                    }
                    else
                    {
                        if (riga.IDPADRE < 0)
                        {
                            continua = false;
                        }
                        else
                        {
                            MigrazioneODLDS.BC_MIGRAZIONERow rigaPadre = _ds.BC_MIGRAZIONE.Where(x => x.IDNODO == riga.IDPADRE && x.DIBA == iddiba).FirstOrDefault();
                            idmagazz = rigaPadre.IDMAGAZZ;
                            idnodo = rigaPadre.IDNODO;
                            anagrafica = bMigrazioneODL.GetANAGRAFICA(_ds, idmagazz);
                        }
                    }

                }

                txtPRODOTTOFINITO.Text = riga.PRODOTTOFINALE;
                txtAnagrafica.Text = (anagrafica == null) ? string.Empty : anagrafica.BC;

                return anagrafica != null;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            txtBarcodeODL.Focus();
            ActiveControl = txtBarcodeODL;
        }

        private void btnSCaricaNodi_Click(object sender, EventArgs e)
        {
            txtMessaggi.Text = string.Empty;
            StringBuilder sb = new StringBuilder();
            _ds = new MigrazioneODLDS();
            using (MigrazioneODLBusiness bMigrazioneODL = new MigrazioneODLBusiness())
            {
                bMigrazioneODL.FillBC_MIGRAZIONE(_ds);
                foreach (MigrazioneODLDS.BC_MIGRAZIONERow r in _ds.BC_MIGRAZIONE)
                    r.Delete();

                bMigrazioneODL.UpdateTable(_ds.BC_MIGRAZIONE.TableName, _ds);
                _ds.AcceptChanges();
                bMigrazioneODL.GetPRODOTTIFINITI(_ds);
            }
            int idDiba = 0;
            EstraiProdottoFinito form = new EstraiProdottoFinito();
            foreach (MigrazioneODLDS.BC_ANAGRAFICA_PRODUZIONERow prodottoFinito in _ds.BC_ANAGRAFICA_PRODUZIONE)
            {
                try
                {
                    _ds.BC_MIGRAZIONE.Clear();
                    List<Nodo> Nodi = form.CreaListaNodi(prodottoFinito.MODELLO, false);
                    if (Nodi == null)
                    {
                        sb.AppendLine(string.Format("Articolo {0} distinta non trovata", prodottoFinito.MODELLO));
                    }
                    else
                    {

                        idDiba++;
                        Nodi.ForEach(x => caricaNodo(x, idDiba, prodottoFinito.MODELLO));

                        using (MigrazioneODLBusiness bMigrazioneODL = new MigrazioneODLBusiness())
                        {
                            bMigrazioneODL.UpdateTable(_ds.BC_MIGRAZIONE.TableName, _ds);
                        }
                    }
                }
                catch (Exception ex)
                {
                    sb.AppendLine(string.Format("Articolo {0} ECCEZIONE in CREA LISTA", prodottoFinito));
                    sb.AppendLine(ex.Message);
                }
            }
            form.Close();
            form.Dispose();
            form = null;
            txtMessaggi.Text = sb.ToString();
        }
        private void caricaNodo(Nodo nodo, int iddiba, string prodottoFinale)
        {
            MigrazioneODLDS.BC_MIGRAZIONERow bcMigrazione = _ds.BC_MIGRAZIONE.NewBC_MIGRAZIONERow();
            bcMigrazione.BC = nodo.Anagrafica;
            bcMigrazione.IDMAGAZZ = nodo.IDMAGAZZ;
            bcMigrazione.IDNODO = nodo.ID;
            bcMigrazione.PROFONDITA = nodo.Profondita;
            bcMigrazione.MODELLO = nodo.Modello;
            bcMigrazione.QUANTITA = nodo.Quantita;
            bcMigrazione.IDPADRE = nodo.IDPADRE;
            bcMigrazione.REPARTO = nodo.Reparto;
            bcMigrazione.FASE = nodo.Fase;
            bcMigrazione.DIBA = iddiba;
            bcMigrazione.PRODOTTOFINALE = prodottoFinale;
            _ds.BC_MIGRAZIONE.AddBC_MIGRAZIONERow(bcMigrazione);
        }
    }
}
