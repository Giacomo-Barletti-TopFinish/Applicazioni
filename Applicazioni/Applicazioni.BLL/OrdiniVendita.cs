﻿using Applicazioni.Data.AnalisiOrdiniVendita;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.BLL
{
    public class OrdiniVendita
    {
        public void EstraiOC(AnalisiOrdiniVenditaDS ds)
        {
            using (AnalisiOrdiniVenditaBusiness aovb = new AnalisiOrdiniVenditaBusiness())
            {
                aovb.FillOC_APERTI(ds);
            }
        }

        public void FillAccantonatoEsistenzaPerOrigine(AnalisiOrdiniVenditaDS ds, string idOrigine, decimal tipoOrigine)
        {

            ds.USR_ACCTO_ESI.Clear();

            using (AnalisiOrdiniVenditaBusiness aovb = new AnalisiOrdiniVenditaBusiness())
            {
                aovb.FillAccantonatoEsistenzaPerOrigine(ds, idOrigine, tipoOrigine);
            }

        }
        public void FillAccantonatoConsegnaPerOrigine(AnalisiOrdiniVenditaDS ds, string idOrigine, decimal tipoOrigine)
        {

            ds.USR_ACCTO_CON.Clear();
            ds.USR_ACCTO_CON_DOC.Clear();

            using (AnalisiOrdiniVenditaBusiness aovb = new AnalisiOrdiniVenditaBusiness())
            {
                aovb.FillAccantonatoConsegnaPerOrigine(ds, idOrigine, tipoOrigine);
                foreach (AnalisiOrdiniVenditaDS.USR_ACCTO_CONRow accConsegna in ds.USR_ACCTO_CON)
                    aovb.FillAccantonatoConsegnaDocumento(ds, accConsegna.IDACCTOCON);
            }

        }

        public string GetNumeroDocumento(AnalisiOrdiniVenditaDS ds, decimal destinazione, string idDestinazione)
        {
            switch (destinazione)
            {
                case (decimal)DestinazioneAccantonato.OrdineDiLavoro:
                    AnalisiOrdiniVenditaDS.USR_PRD_MOVFASIRow odl = GetODL(ds, idDestinazione);
                    return odl == null ? string.Empty : odl.NUMMOVFASE;

                case (decimal)DestinazioneAccantonato.FaseDiCommessa:
                    AnalisiOrdiniVenditaDS.USR_PRD_FASIRow fase = GetFase(ds, idDestinazione);
                    return fase == null ? string.Empty : string.Format("{0} {1}", fase.IsCODICECLIFONull() ? string.Empty : fase.CODICECLIFO, GetDescrizioneFase(ds, fase.IDTABFAS));
            }
            return string.Empty;
        }
        public void CaricaLancio(AnalisiOrdiniVenditaDS ds, string idLancioD)
        {
            using (AnalisiOrdiniVenditaBusiness aovb = new AnalisiOrdiniVenditaBusiness())
            {
                aovb.GetUSR_PRD_FASIDaLancio(ds, idLancioD);
                aovb.GetUSR_PRD_MOVFASIDaLancio(ds, idLancioD);
            }
        }
        public AnalisiOrdiniVenditaDS.USR_PRD_MOVFASIRow GetODL(AnalisiOrdiniVenditaDS ds, string idPrdMovFase)
        {
            AnalisiOrdiniVenditaDS.USR_PRD_MOVFASIRow odl = ds.USR_PRD_MOVFASI.Where(x => x.IDPRDMOVFASE == idPrdMovFase).FirstOrDefault();
            if (odl == null)
            {
                using (AnalisiOrdiniVenditaBusiness aovb = new AnalisiOrdiniVenditaBusiness())
                {
                    aovb.GetUSR_PRD_MOVFASI(ds, idPrdMovFase);
                    odl = ds.USR_PRD_MOVFASI.Where(x => x.IDPRDMOVFASE == idPrdMovFase).FirstOrDefault();
                }

            }

            return odl;
        }

        public AnalisiOrdiniVenditaDS.USR_PRD_FASIRow GetFase(AnalisiOrdiniVenditaDS ds, string idPrdFase)
        {
            AnalisiOrdiniVenditaDS.USR_PRD_FASIRow fase = ds.USR_PRD_FASI.Where(x => x.IDPRDFASE == idPrdFase).FirstOrDefault();
            if (fase == null)
            {
                using (AnalisiOrdiniVenditaBusiness aovb = new AnalisiOrdiniVenditaBusiness())
                {
                    aovb.GetUSR_PRD_FASI(ds, idPrdFase);
                    aovb.GetUSR_PRD_MOVFASIAperte(ds, idPrdFase);
                    aovb.GetUSR_CHECKQ_T(ds, idPrdFase);
                    fase = ds.USR_PRD_FASI.Where(x => x.IDPRDFASE == idPrdFase).FirstOrDefault();
                }

            }

            return fase;
        }

        public List<AnalisiOrdiniVenditaDS.USR_CHECKQ_SRow> GetSeguito(AnalisiOrdiniVenditaDS ds, string idcheckqt)
        {
            List<AnalisiOrdiniVenditaDS.USR_CHECKQ_SRow> seguito = ds.USR_CHECKQ_S.Where(x => x.IDCHECKQT == idcheckqt).ToList();
            if (seguito.Count == 0)
            {
                using (AnalisiOrdiniVenditaBusiness aovb = new AnalisiOrdiniVenditaBusiness())
                {
                    aovb.FillUSR_CHECKQ_S(ds, idcheckqt);
                    seguito = ds.USR_CHECKQ_S.Where(x => x.IDCHECKQT == idcheckqt).ToList();
                }
            }

            return seguito;
        }
        public string GetModello(AnalisiOrdiniVenditaDS ds, string idMagazz)
        {
            AnalisiOrdiniVenditaDS.MAGAZZRow magazz = ds.MAGAZZ.Where(x => x.IDMAGAZZ == idMagazz).FirstOrDefault();
            if (magazz == null)
            {
                using (AnalisiOrdiniVenditaBusiness aovb = new AnalisiOrdiniVenditaBusiness())
                {
                    aovb.GetMagazz(ds, idMagazz);
                    magazz = ds.MAGAZZ.Where(x => x.IDMAGAZZ == idMagazz).FirstOrDefault();
                }

            }
            if (magazz == null) return string.Empty;
            return magazz.MODELLO;
        }

        public string GetDescrizioneSeguito(AnalisiOrdiniVenditaDS ds, string IDSEGUITOCHECKQ)
        {
            AnalisiOrdiniVenditaDS.USR_TAB_SEGUITICHECKQRow seguitoTab = ds.USR_TAB_SEGUITICHECKQ.Where(x => x.IDSEGUITOCHECKQ == IDSEGUITOCHECKQ).FirstOrDefault();
            if (seguitoTab == null)
            {
                using (AnalisiOrdiniVenditaBusiness aovb = new AnalisiOrdiniVenditaBusiness())
                {
                    aovb.FillUSR_TAB_SEGUITICHECKQ(ds);
                    seguitoTab = ds.USR_TAB_SEGUITICHECKQ.Where(x => x.IDSEGUITOCHECKQ == IDSEGUITOCHECKQ).FirstOrDefault();
                }

            }
            return seguitoTab.DESSEGUITOCHECKQ;
        }
        public string GetMagazzino(AnalisiOrdiniVenditaDS ds, string idTabMag)
        {
            AnalisiOrdiniVenditaDS.TABMAGRow tabmag = ds.TABMAG.Where(x => x.IDTABMAG == idTabMag).FirstOrDefault();
            if (tabmag == null)
            {
                using (AnalisiOrdiniVenditaBusiness aovb = new AnalisiOrdiniVenditaBusiness())
                {
                    aovb.GetTabMag(ds, idTabMag);
                    tabmag = ds.TABMAG.Where(x => x.IDTABMAG == idTabMag).FirstOrDefault();
                }

            }
            if (tabmag == null) return string.Empty;
            return tabmag.CODICEMAG;
        }

        public string GetDescrizioneFase(AnalisiOrdiniVenditaDS ds, string idTabFas)
        {
            AnalisiOrdiniVenditaDS.TABFASRow tabfas = ds.TABFAS.Where(x => x.IDTABFAS == idTabFas).FirstOrDefault();
            if (tabfas == null)
            {
                using (AnalisiOrdiniVenditaBusiness aovb = new AnalisiOrdiniVenditaBusiness())
                {
                    aovb.FillTabFas(ds);
                    tabfas = ds.TABFAS.Where(x => x.IDTABFAS == idTabFas).FirstOrDefault();
                }

            }
            if (tabfas == null) return string.Empty;
            return tabfas.CODICEFASE + tabfas.DESTABFAS.Trim();
        }
    }



    public enum OrigineAccantonato
    {
        OrdineCliente,
        MaterialeDiCommessa,
        MaterialeOrdineDilavoro,
        RichiestaTraferimento,
        FlussoDiImpegno,
        Nessuno
    }

    public enum DestinazioneAccantonato
    {
        RigaOrdineFornitore,
        FaseDiCommessa,
        OrdineDiLavoro,
        RichiestaTrasferimento,
        ControlloQualita
    }
}
