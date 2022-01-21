using Applicazioni.Data.CaricoLavoro;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaricoLavoro
{
    public class CaricoLavoro
    {
        private static DateTime? DataPrimoInvio(CaricoLavoroDS ds, CaricoLavoroDS.CARICOLAVORORow elemento, CaricoLavoroBusiness bCarico)
        {
            CaricoLavoroDS.USR_PRD_MOVMATERow movMate = bCarico.GetUSR_PRD_MOVMATE(ds, elemento.IDPRDMOVFASE, elemento.AZIENDA);
            if (movMate != null)
            {
                List<CaricoLavoroDS.USR_PRD_FLUSSO_MOVMATERow> FLUSSOmOVmATE = bCarico.FillUSR_PRD_FLUSSO_MOVMATE(ds, movMate.IDPRDMOVMATE, elemento.AZIENDA);

                if (FLUSSOmOVmATE.Where(x => x.SEGNO == 3).Count() > 0)
                {
                    DateTime t = FLUSSOmOVmATE.Where(x => x.SEGNO == 3).Min(x => x.DATAFLUSSOMOVMATE);
                    if (t != null)
                        return t;
                }

            }
            return null;
        }

        private static string ElencoFasi(CaricoLavoroDS ds, CaricoLavoroDS.CARICOLAVORORow elemento, CaricoLavoroBusiness bCarico)
        {
            string multifase = string.Empty;
            CaricoLavoroDS.TABFASRow fase = ds.TABFAS.Where(x => x.IDTABFAS == elemento.IDTABFAS).FirstOrDefault();
            if (fase != null)
            {
                multifase = fase.CODICEFASE;

                List<CaricoLavoroDS.USR_PRD_LEG_MULTILAVRow> lavorazioniMultiple = bCarico.GetUSR_PRD_LEG_MULTILAV(ds, elemento.IDPRDMOVFASE, elemento.AZIENDA);
                if (lavorazioniMultiple.Count > 0)
                {
                    foreach (CaricoLavoroDS.USR_PRD_LEG_MULTILAVRow lavorazione in lavorazioniMultiple)
                    {
                        CaricoLavoroDS.USR_PRD_FASIRow prdFase = bCarico.GetUSR_PRD_FASI(ds, lavorazione.IDPRDFASE_NEXT, lavorazione.AZIENDA);
                        if (prdFase != null)
                        {
                            CaricoLavoroDS.TABFASRow fase2 = ds.TABFAS.Where(x => x.IDTABFAS == prdFase.IDTABFAS).FirstOrDefault();
                            if (fase2 != null)
                                multifase += ";" + fase2.CODICEFASE;
                        }
                    }

                }

            }
            return multifase;
        }

        private static string DocumentiInvio(CaricoLavoroDS ds, CaricoLavoroDS.CARICOLAVORORow elemento, CaricoLavoroBusiness bCarico)
        {
            StringBuilder sb = new StringBuilder();
            CaricoLavoroDS.USR_PRD_MOVMATERow movMate = bCarico.GetUSR_PRD_MOVMATE(ds, elemento.IDPRDMOVFASE, elemento.AZIENDA);
            List<CaricoLavoroDS.USR_VENDITETRow> vts = new List<CaricoLavoroDS.USR_VENDITETRow>();
            if (movMate != null)
            {
                List<CaricoLavoroDS.USR_PRD_FLUSSO_MOVMATERow> FLUSSOmOVmATE = bCarico.FillUSR_PRD_FLUSSO_MOVMATE(ds, movMate.IDPRDMOVMATE, elemento.AZIENDA);

                if (FLUSSOmOVmATE.Where(x => x.SEGNO == 3).Count() > 0)
                {
                    foreach (CaricoLavoroDS.USR_PRD_FLUSSO_MOVMATERow fmm in FLUSSOmOVmATE.Where(x => x.SEGNO == 3))
                    {
                        if(!fmm.IsIDVENDITEDNull())
                        {
                            List<CaricoLavoroDS.USR_VENDITEDRow> vds = bCarico.GetUSR_VENDITED(ds, fmm.IDVENDITED, fmm.AZIENDA);
                            if (vds.Count > 0)
                            {
                                foreach (CaricoLavoroDS.USR_VENDITEDRow vd in vds)
                                {
                                    CaricoLavoroDS.USR_VENDITETRow vt = bCarico.GetUSR_VENDITET(ds, vd.IDVENDITET, vd.AZIENDA);
                                    if (vt != null) vts.Add(vt);
                                }
                            }
                        }
                    }
                }
            }
            foreach(CaricoLavoroDS.USR_VENDITETRow vt in vts.Distinct())
            {
                string tipoDocumento = string.Empty;
                if(!vt.IsIDTABTIPDOCNull())
                {
                    CaricoLavoroDS.TABTIPDOCRow tdoc = ds.TABTIPDOC.Where(x => x.AZIENDA == vt.AZIENDA && x.IDTABTIPDOC == vt.IDTABTIPDOC).FirstOrDefault();
                    if (tdoc != null) tipoDocumento = tdoc.CODICETIPDOC;
                }
                string documento = string.Format("{0}/{1} del {2};",tipoDocumento,vt.NUMDOC,vt.DATDOC);
                sb.Append(documento);
            }
            return sb.ToString();
        }

        public static void Esegui()
        {
            CaricoLavoroDS ds = new CaricoLavoroDS();
            using (CaricoLavoroBusiness bCarico = new CaricoLavoroBusiness())
            {
                bCarico.GetCaricoLavoro(ds);
                bCarico.FillTABFAS(ds);
                bCarico.FillTABTIPDOC(ds);
                //bCarico.FillUSR_PRD_CAUMATE(ds);
                int i = 1;
                foreach (CaricoLavoroDS.CARICOLAVORORow elemento in ds.CARICOLAVORO)
                {
                    Console.WriteLine(string.Format("elemento {0} di {1} - {2}", i, ds.CARICOLAVORO.Count, elemento.NUMMOVFASE));

                    DateTime? primoInvio = DataPrimoInvio(ds, elemento, bCarico);
                    if (primoInvio.HasValue)
                        elemento.DATAPRIMOINVIO_ODL = primoInvio.Value;

                    //CaricoLavoroDS.USR_PRD_MOVMATERow movMate = bCarico.GetUSR_PRD_MOVMATE(ds, elemento.IDPRDMOVFASE, elemento.AZIENDA);
                    //if (movMate != null)
                    //{
                    //    List<CaricoLavoroDS.USR_PRD_FLUSSO_MOVMATERow> FLUSSOmOVmATE = bCarico.FillUSR_PRD_FLUSSO_MOVMATE(ds, movMate.IDPRDMOVMATE, elemento.AZIENDA);

                    //    if (FLUSSOmOVmATE.Where(x => x.SEGNO == 3).Count() > 0)
                    //    {
                    //        DateTime t = FLUSSOmOVmATE.Where(x => x.SEGNO == 3).Min(x => x.DATAFLUSSOMOVMATE);
                    //        if (t != null)
                    //            elemento.DATAPRIMOINVIO_ODL = t;
                    //    }

                    //}
                    //string multifase = string.Empty;
                    //CaricoLavoroDS.TABFASRow fase = ds.TABFAS.Where(x => x.IDTABFAS == elemento.IDTABFAS).FirstOrDefault();
                    //if (fase != null)
                    //{
                    //    multifase = fase.CODICEFASE;

                    //    List<CaricoLavoroDS.USR_PRD_LEG_MULTILAVRow> lavorazioniMultiple = bCarico.GetUSR_PRD_LEG_MULTILAV(ds, elemento.IDPRDMOVFASE, elemento.AZIENDA);
                    //    if (lavorazioniMultiple.Count > 0)
                    //    {
                    //        foreach (CaricoLavoroDS.USR_PRD_LEG_MULTILAVRow lavorazione in lavorazioniMultiple)
                    //        {
                    //            CaricoLavoroDS.USR_PRD_FASIRow prdFase = bCarico.GetUSR_PRD_FASI(ds, lavorazione.IDPRDFASE_NEXT, lavorazione.AZIENDA);
                    //            if (prdFase != null)
                    //            {
                    //                CaricoLavoroDS.TABFASRow fase2 = ds.TABFAS.Where(x => x.IDTABFAS == prdFase.IDTABFAS).FirstOrDefault();
                    //                if (fase2 != null)
                    //                    multifase += ";" + fase2.CODICEFASE;
                    //            }
                    //        }

                    //    }

                    //}
                    elemento.ELENCOFASI = ElencoFasi(ds, elemento, bCarico);
                    elemento.DOCUMENTI_INVIO = DocumentiInvio(ds, elemento, bCarico);

                    i++;
                }

            }
        }
    }
}
