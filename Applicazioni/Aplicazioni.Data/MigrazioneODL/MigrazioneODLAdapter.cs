using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.MigrazioneODL
{
    public class MigrazioneODLAdapter : AdapterBase
    {
        public MigrazioneODLAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
       base(connection, transaction)
        { }

        public void GetUSR_PRD_MOVFASI(MigrazioneODLDS ds, String Barcode)
        {

            string select = @"SELECT * FROM USR_PRD_MOVFASI WHERE BARCODE = $P<BARCODE>";

            ParamSet ps = new ParamSet();
            ps.AddParam("BARCODE", DbType.String, Barcode);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_MOVFASI);
            }
        }
        public void GetTask(MigrazioneODLDS ds, String IDTABFAS)
        {

            string select = @"SELECT * FROM BC_TASK WHERE IDTABFAS = $P<IDTABFAS>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDTABFAS", DbType.String, IDTABFAS);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.BC_TASK);
            }
        }
        public void GetUSR_PRD_MOVFASIByNumdoc(MigrazioneODLDS ds, String NUMMOVFASE)
        {

            string select = @"SELECT * FROM USR_PRD_MOVFASI WHERE NUMMOVFASE = $P<NUMMOVFASE>";

            ParamSet ps = new ParamSet();
            ps.AddParam("NUMMOVFASE", DbType.String, NUMMOVFASE);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_MOVFASI);
            }
        }
        public void GetANAGRAFICA(MigrazioneODLDS ds, String idmagazz)
        {

            string select = @"SELECT MA.MODELLO,BC.* from bc_anagrafica_produzione  BC
                                INNER JOIN GRUPPO.MAGAZZ MA ON MA.IDMAGAZZ = BC.IDMAGAZZ 
                                WHERE BC.IDMAGAZZ = $P<IDMAGAZZ>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDMAGAZZ", DbType.String, idmagazz);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.BC_ANAGRAFICA_PRODUZIONE);
            }
        }

        public void GetODL2ODP(MigrazioneODLDS ds, String NUMMOVFASE)
        {

            string select = @"SELECT * from ODL2ODP WHERE NUMMOVFASE = $P<NUMMOVFASE>";

            ParamSet ps = new ParamSet();
            ps.AddParam("NUMMOVFASE", DbType.String, NUMMOVFASE);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.ODL2ODP);
            }
        }

        public void GetODL2ODPCOMPONENTI(MigrazioneODLDS ds, String NUMMOVFASE)
        {

            string select = @"SELECT * from ODL2ODPCOMPONENTI WHERE NUMMOVFASE = $P<NUMMOVFASE>";

            ParamSet ps = new ParamSet();
            ps.AddParam("NUMMOVFASE", DbType.String, NUMMOVFASE);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.ODL2ODPCOMPONENTI);
            }
        }


        public void InsertODL2ODP(string azienda, string idPrdMovFase, string numMovFase, string reparto, string fase, string idmagazz, string anagrafica, decimal quantita,
            string odv, string descrizione, string descrizione2, string company)
        {

            string select = @"insert into ODL2ODP (AZIENDA,IDPRDMOVFASE,NUMMOVFASE,REPARTO,FASE,IDMAGAZZ,ANAGRAFICA, QUANTITA,ODV,DESCRIZIONE,DESCRIZIONE2,DATACREAZIONE, COMPANY)values ($P{AZIENDA},$P{IDPRDMOVFASE},$P{NUMMOVFASE},$P{REPARTO},$P{FASE},$P{IDMAGAZZ},$P{ANAGRAFICA}, $P{QUANTITA},$P{ODV},$P{DESCRIZIONE},$P{DESCRIZIONE2},$P{DATACREAZIONE},$P{COMPANY})";

            ParamSet ps = new ParamSet();
            ps.AddParam("AZIENDA", DbType.String, azienda);
            ps.AddParam("IDPRDMOVFASE", DbType.String, idPrdMovFase);
            ps.AddParam("NUMMOVFASE", DbType.String, numMovFase);
            ps.AddParam("REPARTO", DbType.String, reparto);
            ps.AddParam("FASE", DbType.String, fase);
            ps.AddParam("IDMAGAZZ", DbType.String, idmagazz);
            ps.AddParam("ANAGRAFICA", DbType.String, anagrafica);
            ps.AddParam("QUANTITA", DbType.Decimal, quantita);
            ps.AddParam("ODV", DbType.String, odv);
            ps.AddParam("DESCRIZIONE", DbType.String, descrizione);
            ps.AddParam("DESCRIZIONE2", DbType.String, descrizione2);
            ps.AddParam("DATACREAZIONE", DbType.DateTime, DateTime.Now);
            ps.AddParam("COMPANY", DbType.String, company);

            using (DbCommand cmd = BuildCommand(select, ps))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertODL2ODPComponenti(string azienda, string numMovFase, string reparto, string fase, string distinta, string componente, decimal quantita, decimal quantitaNominale,
          string odv, string ubicazione, string collocazione, string company)
        {

            string select = @"insert into ODL2ODPCOMPONENTI (AZIENDA,NUMMOVFASE,REPARTO,FASE,COMPANY,ODV,DISTINTA,COMPONENTE,QUANTITA_NOMINALE,QUANTITA,UBICAZIONE,COLLOCAZIONE,DATACREAZIONE) values 
                                        ($P{AZIENDA},$P{NUMMOVFASE},$P{REPARTO},$P{FASE},$P{COMPANY},$P{ODV},$P{DISTINTA},$P{COMPONENTE},$P{QUANTITA_NOMINALE},$P{QUANTITA},$P{UBICAZIONE},$P{COLLOCAZIONE},$P{DATACREAZIONE})";

            ParamSet ps = new ParamSet();
            ps.AddParam("AZIENDA", DbType.String, azienda);
            ps.AddParam("NUMMOVFASE", DbType.String, numMovFase);
            ps.AddParam("REPARTO", DbType.String, reparto);
            ps.AddParam("FASE", DbType.String, fase);
            ps.AddParam("COMPANY", DbType.String, company);
            ps.AddParam("ODV", DbType.String, odv);
            ps.AddParam("DISTINTA", DbType.String, distinta);
            ps.AddParam("COMPONENTE", DbType.String, componente);
            ps.AddParam("QUANTITA_NOMINALE", DbType.Decimal, quantitaNominale);
            ps.AddParam("QUANTITA", DbType.Decimal, quantita);
            ps.AddParam("UBICAZIONE", DbType.String, ubicazione);
            ps.AddParam("COLLOCAZIONE", DbType.String, collocazione);
            ps.AddParam("DATACREAZIONE", DbType.DateTime, DateTime.Now);

            using (DbCommand cmd = BuildCommand(select, ps))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertODL2ODPlog(string numMovFase, string nota, string esecuzione, string company, int errore, string modello)
        {

            if (nota.Length > 1000)
                nota = nota.Substring(0, 1000);


            string select = @"insert into ODL2ODPLOG (NUMMOVFASE,NOTA,ESECUZIONE,COMPANY,DATACREAZIONE,ERRORE,MODELLO) values 
                                        ($P{NUMMOVFASE},$P{NOTA},$P{ESECUZIONE},$P{COMPANY},$P{DATACREAZIONE},$P{ERRORE},$P{MODELLO})";

            ParamSet ps = new ParamSet();
            ps.AddParam("NUMMOVFASE", DbType.String, numMovFase);
            ps.AddParam("NOTA", DbType.String, nota);
            ps.AddParam("ESECUZIONE", DbType.String, esecuzione);
            ps.AddParam("COMPANY", DbType.String, company);
            ps.AddParam("DATACREAZIONE", DbType.DateTime, DateTime.Now);
            ps.AddParam("ERRORE", DbType.Int32, errore);
            ps.AddParam("MODELLO", DbType.String, modello);

            using (DbCommand cmd = BuildCommand(select, ps))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public void GetPRODOTTIFINITI(MigrazioneODLDS ds)
        {

            string select = @"select MA.MODELLO,BC.* from bc_anagrafica_produzione  BC
                                INNER JOIN GRUPPO.MAGAZZ MA ON MA.IDMAGAZZ = BC.IDMAGAZZ 
                                where bc like 'A-_________FI%' and CL=0
                                ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.BC_ANAGRAFICA_PRODUZIONE);
            }
        }
        public void GetCLIFO(MigrazioneODLDS ds, String codice)
        {

            string select = @"SELECT * FROM gruppo.clifo WHERE codice = $P<CODICE>";

            ParamSet ps = new ParamSet();
            ps.AddParam("CODICE", DbType.String, codice);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.CLIFO);
            }
        }
        public void GetTABFAS(MigrazioneODLDS ds, String IDTABFAS)
        {

            string select = @"SELECT * FROM gruppo.tabfas WHERE IDTABFAS = $P<IDTABFAS>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDTABFAS", DbType.String, IDTABFAS);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.TABFAS);
            }
        }
        public void GetMAGAZZ(MigrazioneODLDS ds, String idmagazz)
        {

            string select = @"SELECT * FROM gruppo.MAGAZZ WHERE IDMAGAZZ= $P<IDMAGAZZ>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDMAGAZZ", DbType.String, idmagazz);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.MAGAZZ);
            }
        }

        public void GetUSR_PRD_FASI(MigrazioneODLDS ds, String IDPRDFASE, string AZIENDA)
        {

            string select = @"SELECT * FROM USR_PRD_FASI WHERE IDPRDFASE= $P<IDPRDFASE> AND AZIENDA = $P<AZIENDA>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDPRDFASE", DbType.String, IDPRDFASE);
            ps.AddParam("AZIENDA", DbType.String, AZIENDA);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.USR_PRD_FASI);
            }
        }

        public void FillBC_MIGRAZIONE(MigrazioneODLDS ds)
        {

            string select = @"select * from BC_MIGRAZIONE";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.BC_MIGRAZIONE);
            }
        }
        public void UpdateTable(string tablename, MigrazioneODLDS ds)
        {
            string query = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}", tablename);

            using (DbDataAdapter a = BuildDataAdapter(query))
            {
                try
                {
                    a.ContinueUpdateOnError = false;
                    DataTable dt = ds.Tables[tablename];
                    DbCommandBuilder cmd = BuildCommandBuilder(a);
                    a.UpdateCommand = cmd.GetUpdateCommand();
                    a.DeleteCommand = cmd.GetDeleteCommand();
                    a.InsertCommand = cmd.GetInsertCommand();
                    a.Update(dt);
                }
                catch (DBConcurrencyException ex)
                {

                }
                catch
                {
                    throw;
                }
            }
        }
        public void GetDistinteBCTestata(MigrazioneODLDS ds, string codiceTestata)
        {
            ParamSet ps = new ParamSet();
            string select = @"select * from [dbo].DistinteBCTestata where 1=1";
            AddConditionAndParam(ref select, "[No_]", "TESTATA", codiceTestata, ps, true);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.DistinteBCTestata);
            }
        }

        public void GetDistinteBCDettaglio(MigrazioneODLDS ds, string codiceTestata)
        {
            string select = @"select * from DistinteBCDettaglio where [Production BOM No_] =  $P<TESTATA>";
            ParamSet ps = new ParamSet();
            ps.AddParam("TESTATA", DbType.String, codiceTestata);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.DistinteBCDettaglio);
            }
        }
    }
}
