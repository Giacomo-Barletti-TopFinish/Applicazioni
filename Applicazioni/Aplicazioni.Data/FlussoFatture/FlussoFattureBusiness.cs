﻿using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.FlussoFatture
{
    public class FlussoFattureBusiness : BusinessBase
    {
        [DataContext]
        public void FillBOLLE_VENDITATESTATA(FlussoFattureDS ds, DateTime Dal, DateTime Al, string radioButton, string radioButtonAzienda, bool ignoraMetalplus)
        {
            FlussoFattureAdapter a = new FlussoFattureAdapter(DbConnection, DbTransaction);
            a.FillBOLLE_VENDITATESTATA(ds, Dal, Al, radioButton, radioButtonAzienda, ignoraMetalplus);
        }
        [DataContext]
        public void FillVerificaNazioneNulla(FlussoFattureDS ds, DateTime Dal, DateTime Al, string radioButton, bool ignoraMetalplus)
        {
            FlussoFattureAdapter a = new FlussoFattureAdapter(DbConnection, DbTransaction);
            a.FillVerificaNazioneNulla(ds, Dal, Al, radioButton, ignoraMetalplus);
        }
        [DataContext]
        public void FillBC_FLUSSO_TESTATA(FlussoFattureDS ds, DateTime Dal, DateTime Al)
        {
            FlussoFattureAdapter a = new FlussoFattureAdapter(DbConnection, DbTransaction);
            a.FillBC_FLUSSO_TESTATA(ds, Dal, Al);
        }
        [DataContext]
        public void FillBC_FLUSSO_DETTAGLIO(FlussoFattureDS ds, DateTime Dal, DateTime Al)
        {
            FlussoFattureAdapter a = new FlussoFattureAdapter(DbConnection, DbTransaction);
            a.FillBC_FLUSSO_DETTAGLIO(ds, Dal, Al);
        }

        [DataContext]
        public void FillMATERIALIMAMI(FlussoFattureDS ds)
        {
            FlussoFattureAdapter a = new FlussoFattureAdapter(DbConnection, DbTransaction);
            a.FillMATERIALIMAMI(ds);
        }

        [DataContext(true)]
        public void UpdateTable(string tablename, FlussoFattureDS ds)
        {
            FlussoFattureAdapter a = new FlussoFattureAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tablename, ds);
        }

        [DataContext(true)]
        public void BloccaBolla(string FULLNUMDOC)
        {
            FlussoFattureAdapter a = new FlussoFattureAdapter(DbConnection, DbTransaction);
            a.BloccaBolla(FULLNUMDOC);
        }
    }
}
