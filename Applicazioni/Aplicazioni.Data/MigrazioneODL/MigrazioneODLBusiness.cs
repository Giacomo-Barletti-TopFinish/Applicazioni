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

        [DataContext]
        public void GetODL2ODP(MigrazioneODLDS ds, String NUMMOVFASE)
        {
            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetODL2ODP(ds, NUMMOVFASE);
        }
        [DataContext(true)]
        public void InsertODL2ODP(string azienda, string idPrdMovFase, string numMovFase, string reparto, string fase, string idmagazz, string anagrafica, decimal quantita,
            string odv, string descrizione, string descrizione2,string company)
        {
            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.InsertODL2ODP(azienda, idPrdMovFase, numMovFase, reparto, fase, idmagazz, anagrafica, quantita, odv, descrizione, descrizione2, company);
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
