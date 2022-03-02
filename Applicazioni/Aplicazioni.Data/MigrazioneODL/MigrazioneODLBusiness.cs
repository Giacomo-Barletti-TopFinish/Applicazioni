using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.MigrazioneODL
{

    public class MigrazioneODLBusiness : BusinessBase
    {
        [DataContext]
        public void GetUSR_PRD_MOVFASI(MigrazioneODLDS ds, String Barcode)
        {
            if (ds.USR_PRD_MOVFASI.Any(x => x.BARCODE == Barcode)) return;

            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetUSR_PRD_MOVFASI(ds, Barcode);
        }
        [DataContext]
        public void GetTrasferimenti(MigrazioneODLDS ds, String Barcode)
        {
            if (ds.USR_PRD_MOVFASI.Any(x => x.BARCODE == Barcode)) return;

            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetTrasferimenti(ds, Barcode);
        }
        [DataContext]
        public void GetUSR_PRD_MOVFASI_Trasferimento(MigrazioneODLDS ds, String IDMAGAZZ)
        {
            if (ds.USR_PRD_MOVFASI.Any(x => x.IDMAGAZZ == IDMAGAZZ)) return;

            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetUSR_PRD_MOVFASI_Trasferimento(ds, IDMAGAZZ);
        }
        [DataContext]
        public void GetTask(MigrazioneODLDS ds, String IDTABFAS)
        {
            if (ds.BC_TASK.Any(x => x.IDTABFAS == IDTABFAS)) return;

            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetTask(ds, IDTABFAS);
        }
        [DataContext]
        public void GetUSR_PRD_MOVFASIByNumdoc(MigrazioneODLDS ds, String NUMMOVFASE)
        {
            if (ds.USR_PRD_MOVFASI.Any(x => x.NUMMOVFASE == NUMMOVFASE)) return;

            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetUSR_PRD_MOVFASIByNumdoc(ds, NUMMOVFASE);
        }
        [DataContext]
        public MigrazioneODLDS.USR_PRD_FASIRow GetUSR_PRD_FASI(MigrazioneODLDS ds, String IDPRDFASE, string AZIENDA)
        {
            MigrazioneODLDS.USR_PRD_FASIRow RIGA = ds.USR_PRD_FASI.Where(x => x.IDPRDFASE == IDPRDFASE && x.AZIENDA == AZIENDA).FirstOrDefault();
            if (RIGA == null)
            {
                MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
                a.GetUSR_PRD_FASI(ds, IDPRDFASE, AZIENDA);
            }
            return ds.USR_PRD_FASI.Where(x => x.IDPRDFASE == IDPRDFASE && x.AZIENDA == AZIENDA).FirstOrDefault();
        }

        [DataContext]
        public MigrazioneODLDS.USR_PRD_FASIRow GetUSR_PRD_FASIParde(MigrazioneODLDS ds, String IDPRDFASEPADRE, string AZIENDA)
        {
            MigrazioneODLDS.USR_PRD_FASIRow RIGA = ds.USR_PRD_FASI.Where(x => !x.IsIDPRDFASEPADRENull() && x.IDPRDFASEPADRE == IDPRDFASEPADRE && x.AZIENDA == AZIENDA).FirstOrDefault();
            if (RIGA == null)
            {
                MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
                a.GetUSR_PRD_FASIPadre(ds, IDPRDFASEPADRE, AZIENDA);
            }
            return ds.USR_PRD_FASI.Where(x => !x.IsIDPRDFASEPADRENull() && x.IDPRDFASEPADRE == IDPRDFASEPADRE && x.AZIENDA == AZIENDA).FirstOrDefault();
        }


        [DataContext]
        public void GetCLIFO(MigrazioneODLDS ds, String CodiceClifo)
        {
            if (ds.CLIFO.Any(x => x.CODICE == CodiceClifo)) return;

            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetCLIFO(ds, CodiceClifo);
        }
        [DataContext]
        public MigrazioneODLDS.BC_ANAGRAFICA_PRODUZIONERow GetANAGRAFICA(MigrazioneODLDS ds, String idmagazz)
        {
            MigrazioneODLDS.BC_ANAGRAFICA_PRODUZIONERow anagrafica = ds.BC_ANAGRAFICA_PRODUZIONE.Where(x => x.IDMAGAZZ == idmagazz).FirstOrDefault();

            if (anagrafica != null) return anagrafica;

            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetANAGRAFICA(ds, idmagazz);
            return ds.BC_ANAGRAFICA_PRODUZIONE.Where(x => x.IDMAGAZZ == idmagazz).FirstOrDefault();
        }
        //[DataContext]
        //public void GetDistinteBCDettaglio(MigrazioneODLDS ds, String codiceTestata)
        //{
        //    MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
        //    a.GetDistinteBCDettaglio(ds, codiceTestata);
        //}

        [DataContext]
        public void GetODL2ODPCOMPONENTI(MigrazioneODLDS ds, String NUMMOVFASE)
        {
            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetODL2ODPCOMPONENTI(ds, NUMMOVFASE);
        }
        [DataContext]
        public void GetODL2ODP(MigrazioneODLDS ds, String NUMMOVFASE)
        {
            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetODL2ODP(ds, NUMMOVFASE);
        }
        [DataContext(true)]
        public void InsertODL2ODP(string azienda, string idPrdMovFase, string numMovFase, string reparto, string fase, string idmagazz, string anagrafica, decimal quantita,
            string odv, string descrizione, string descrizione2, string company)
        {
            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.InsertODL2ODP(azienda, idPrdMovFase, numMovFase, reparto, fase, idmagazz, anagrafica, quantita, odv, descrizione, descrizione2, company);
        }
        [DataContext(true)]
        public void InsertODL2ODPComponenti(string azienda, string numMovFase, string reparto, string fase, string distinta, string componente, decimal quantita, decimal quantitaNominale,
          string odv, string ubicazione, string collocazione, string company)
        {
            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.InsertODL2ODPComponenti(azienda, numMovFase, reparto, fase, distinta, componente, quantita, quantitaNominale, odv, ubicazione, collocazione, company);
        }
        [DataContext(true)]
        public void InsertODL2ODPlog(string numMovFase, string nota, string esecuzione, string company, int errore)
        {
            InsertODL2ODPlog(numMovFase, nota, esecuzione, company, errore, string.Empty);
        }
        [DataContext(true)]
        public void InsertODL2ODPlog(string numMovFase, string nota, string esecuzione, string company, int errore, string modello)
        {
            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.InsertODL2ODPlog(numMovFase, nota, esecuzione, company, errore, modello);
        }
        [DataContext]
        public void GetTABFAS(MigrazioneODLDS ds, String idtabfas)
        {
            if (ds.TABFAS.Any(x => x.IDTABFAS == idtabfas)) return;

            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetTABFAS(ds, idtabfas);
        }
        [DataContext]
        public void GetMAGAZZ(MigrazioneODLDS ds, String idmagazz)
        {
            if (ds.MAGAZZ.Any(x => x.IDMAGAZZ == idmagazz)) return;

            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetMAGAZZ(ds, idmagazz);
        }

        [DataContext]
        public void GetPRODOTTIFINITI(MigrazioneODLDS ds)
        {
            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetPRODOTTIFINITI(ds);
        }
        [DataContext]
        public void FillBC_MIGRAZIONE(MigrazioneODLDS ds)
        {
            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.FillBC_MIGRAZIONE(ds);
        }
        [DataContext(true)]
        public void UpdateTable(string tablename, MigrazioneODLDS ds)
        {
            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tablename, ds);
        }
    }
}
