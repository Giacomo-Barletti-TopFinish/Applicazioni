﻿using Applicazioni.Data.Core;
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
        public void GetANAGRAFICA(MigrazioneODLDS ds, String idmagazz)
        {
            if (ds.BC_ANAGRAFICA_PRODUZIONE.Any(x => x.IDMAGAZZ == idmagazz)) return;

            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetANAGRAFICA(ds, idmagazz);
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
        public void GetUSR_PRD_TDIBA(MigrazioneODLDS ds, String idmagazz, string dibaMethod, decimal version, string desVersion)
        {
            if (ds.USR_PRD_TDIBA.Any(x => x.IDMAGAZZ == idmagazz && x.IDDIBAMETHOD == dibaMethod && x.VERSION == version && x.DESVERSION == desVersion)) return;

            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetUSR_PRD_TDIBA(ds, idmagazz, dibaMethod, version, desVersion);
        }

        [DataContext]
        public void GetUSR_PRD_TDIBA1(MigrazioneODLDS ds, String idTdiba, string azienda)
        {
            if (ds.USR_PRD_TDIBA1.Any(x => x.IDTDIBAIFFASE == idTdiba && x.AZIENDA == azienda)) return;

            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetUSR_PRD_TDIBA1(ds, idTdiba, azienda);
        }

        [DataContext]
        public void GetPRODOTTIFINITI(MigrazioneODLDS ds)
        {
            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetPRODOTTIFINITI(ds);
        }
    }
}
