using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.Preventivi
{
    public class PreventiviBusiness : BusinessBase
    {
        [DataContext]
        public void FillUSR_VENDITEPT(PreventiviDS ds, string Riferimento, string FiltroCliente)
        {
            PreventiviAdapter a = new PreventiviAdapter(DbConnection, DbTransaction);
            a.FillUSR_VENDITEPT(ds, Riferimento, FiltroCliente);
        }

        [DataContext]
        public void FillUSR_VENDITEPD(PreventiviDS ds, string IDVENDITEPT)
        {
            PreventiviAdapter a = new PreventiviAdapter(DbConnection, DbTransaction);
            a.FillUSR_VENDITEPD(ds, IDVENDITEPT);
        }

        [DataContext]
        public void FillUSR_VENDITEPF(PreventiviDS ds, string IDVENDITEPD)
        {
            PreventiviAdapter a = new PreventiviAdapter(DbConnection, DbTransaction);
            a.FillUSR_VENDITEPF(ds, IDVENDITEPD);
        }

        [DataContext]
        public void FillUSR_VENDITEPF_DIBA(PreventiviDS ds, string IDVENDITEPF)
        {
            PreventiviAdapter a = new PreventiviAdapter(DbConnection, DbTransaction);
            a.FillUSR_VENDITEPF_DIBA(ds, IDVENDITEPF);
        }

        [DataContext]
        public void FillUSR_VENDITEPF_DIBATREE(PreventiviDS ds, string IDVENDITEPFDIBA)
        {
            PreventiviAdapter a = new PreventiviAdapter(DbConnection, DbTransaction);
            a.FillUSR_VENDITEPF_DIBATREE(ds, IDVENDITEPFDIBA);
        }

        [DataContext]
        public void FillUSR_VENDITEPF_DIBACOS(PreventiviDS ds, string IDVENDITEPFDIBA)
        {
            PreventiviAdapter a = new PreventiviAdapter(DbConnection, DbTransaction);
            a.FillUSR_VENDITEPF_DIBACOS(ds, IDVENDITEPFDIBA);
        }

        [DataContext]
        public void FillUSR_VENDITEPF_GRUPPOT(PreventiviDS ds, string IDVENDITEPFDIBA)
        {
            PreventiviAdapter a = new PreventiviAdapter(DbConnection, DbTransaction);
            a.FillUSR_VENDITEPF_GRUPPOT(ds, IDVENDITEPFDIBA);
        }

        [DataContext]
        public void FillUSR_VENDITEPF_GRUPPOD(PreventiviDS ds, string IDVENDITEPFDIBA)
        {
            PreventiviAdapter a = new PreventiviAdapter(DbConnection, DbTransaction);
            a.FillUSR_VENDITEPF_GRUPPOD(ds, IDVENDITEPFDIBA);
        }

        [DataContext]
        public void FillUSR_VENDITEPF_TOTPREV(PreventiviDS ds, string IDVENDITEPFDIBA)
        {
            PreventiviAdapter a = new PreventiviAdapter(DbConnection, DbTransaction);
            a.FillUSR_VENDITEPF_TOTPREV(ds, IDVENDITEPFDIBA);
        }

        [DataContext]
        public void FillAP_PREVENTIVIC(PreventiviDS ds, string IDVENDITEPF)
        {
            PreventiviAdapter a = new PreventiviAdapter(DbConnection, DbTransaction);
            a.FillAP_PREVENTIVIC(ds, IDVENDITEPF);
        }

        [DataContext]
        public void FillAP_PREVENTIVIG(PreventiviDS ds, string IDVENDITEPF)
        {
            PreventiviAdapter a = new PreventiviAdapter(DbConnection, DbTransaction);
            a.FillAP_PREVENTIVIG(ds, IDVENDITEPF);
        }

        [DataContext]
        public void FillAP_PREVENTIVIT(PreventiviDS ds, string IDVENDITEPF)
        {
            PreventiviAdapter a = new PreventiviAdapter(DbConnection, DbTransaction);
            a.FillAP_PREVENTIVIT(ds, IDVENDITEPF);
        }

        [DataContext(true)]
        public void UpdateTable(string tablename, PreventiviDS ds)
        {
            PreventiviAdapter a = new PreventiviAdapter(DbConnection, DbTransaction);
            a.UpdateTable(tablename, ds);
        }
    }
}
