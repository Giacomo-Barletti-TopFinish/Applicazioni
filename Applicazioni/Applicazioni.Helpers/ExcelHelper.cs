using Applicazioni.Entities;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Applicazioni.Helpers
{
    public enum TipoExcel { Sconosciuto, IdMagazz, RVL }

    public class Etichette
    {
        public const string ESTERO = "ESTERO";
        public const string ITALIA = "SOLO  ITALIA";
        public const string TUTTI = "TUTTI";

        public const string METAL = "METALPLUS";
        public const string TOP = "TOPFINISH";
        public const string METALTOP = "TUTTI";


        public const string IDMAGAZZ = "IDMAGAZZ";
        public const string ArticoloDescrizione = "Articolo Descrizione";
        public const string Anagrafica = "ANAGRAFICA";
        public const string CodiceCiclo = "CODICE CICLO";
        public const string CodiceFase = "Fase Codice";
        public const string CodiceReparto = "Reparto Codice^";
        public const string Consumo = "Q.tà Consumo";
        public const string UnitaMisura = "U.m. Codice";
        public const string Note = "Note Tecniche se Wip";
        public const string Peso = "Peso in gr.^";
        public const string Superficie = "([]) Superficie in mm^";
        public const string PezziOrari = "PEZZI ORARI";
        public const string Collegamento = "COLLEGAMENTO";
    }
    public class ExcelHelper
    {

        public byte[] CreaFileFaseCicli(List<Ciclo> cicli, out string errori)
        {
            errori = string.Empty;
            StringBuilder sb = new StringBuilder();

            byte[] content;

            MemoryStream ms = new MemoryStream();

            using (SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart wsTestata = workbookPart.AddNewPart<WorksheetPart>();
                wsTestata.Worksheet = new Worksheet();

                WorksheetPart wsDettaglio = workbookPart.AddNewPart<WorksheetPart>();
                wsDettaglio.Worksheet = new Worksheet();

                // Adding style
                WorkbookStylesPart stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylePart.Stylesheet = GenerateStylesheet();
                stylePart.Stylesheet.Save();


                Columns colonneTestata = new Columns();
                for (int i = 0; i < 19; i++)
                {
                    Column c = new Column();
                    UInt32Value u = new UInt32Value((uint)(i + 1));
                    c.Min = u;
                    c.Max = u;
                    c.Width = 25;
                    c.CustomWidth = true;

                    colonneTestata.Append(c);
                }

                Columns colonneDettaglio = new Columns();
                for (int i = 0; i < 6; i++)
                {
                    Column c = new Column();
                    UInt32Value u = new UInt32Value((uint)(i + 1));
                    c.Min = u;
                    c.Max = u;
                    c.Width = 25;
                    c.CustomWidth = true;

                    colonneDettaglio.Append(c);
                }

                wsTestata.Worksheet.AppendChild(colonneTestata);
                wsDettaglio.Worksheet.AppendChild(colonneDettaglio);

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sTestata = new Sheet() { Id = workbookPart.GetIdOfPart(wsTestata), SheetId = 1, Name = "Righe cicli produzione" };
                Sheet sDettaglio = new Sheet() { Id = workbookPart.GetIdOfPart(wsDettaglio), SheetId = 2, Name = "Riga commento ciclo" };

                sheets.Append(sTestata);
                sheets.Append(sDettaglio);

                workbookPart.Workbook.Save();

                SheetData sheetDataTestata = wsTestata.Worksheet.AppendChild(new SheetData());
                SheetData sheetDataDettaglio = wsDettaglio.Worksheet.AppendChild(new SheetData());


                Row rowHeaderTestata = new Row();
                rowHeaderTestata.Append(ConstructCell("Nr. ciclo", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Cod. versione", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Nr. operazione", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Tipo", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Nr.", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Tempo di setup", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Tempo lavorazione", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Tempo attesa", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Tempo spostamento", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Dimensione lotto", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Cod. unità mis. tempo di setup", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Cod. unità mis. tempo lavoraz.", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Cod. unità mis. tempo attesa", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Cod. unità mis. tempo spostamento", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Cod. collegamento tra ciclo e distinta base", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Cod. task standard", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Codice condizione", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Codice caratteristica", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Codice logiche lavorazione", CellValues.String, 2));
                sheetDataTestata.AppendChild(rowHeaderTestata);

                Row rowHeaderDettaglio = new Row();
                rowHeaderDettaglio.Append(ConstructCell("Nr. ciclo", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("Cod. versione", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("Nr. operazione", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("Nr. riga", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("Data", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("Commento", CellValues.String, 2));
                sheetDataDettaglio.AppendChild(rowHeaderDettaglio);

                foreach (Ciclo c in cicli)
                {
                    foreach (Fase f in c.Fasi)
                    {
                        Row rowTestata = new Row();

                        rowTestata.Append(ConstructCell(c.Codice, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.Versione, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.Operazione.ToString(), CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.Tipo, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.AreaProduzione, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.TempoSetup.ToString(), CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.TempoLavorazione.ToString(), CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.TempoAttesa.ToString(), CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.TempoSpostamento.ToString(), CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.DimensioneLotto.ToString(), CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.UMSetup, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.UMLavorazione, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.UMAttesa, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.UMSpostamento, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.Collegamento, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.Task, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.Condizione, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.Caratteristica, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.LogicheLavorazione, CellValues.String, 1));

                        sheetDataTestata.AppendChild(rowTestata);


                        int numeroRiga = 1000;
                        foreach (string commento in f.Commenti)
                        {
                            List<string> elementi = SeparaStringa(commento, 80);
                            foreach (string elemento in elementi)
                            {
                                Row rowDettaglio = new Row();
                                rowDettaglio.Append(ConstructCell(c.Codice, CellValues.String, 1));
                                rowDettaglio.Append(ConstructCell(string.Empty, CellValues.String, 1));
                                rowDettaglio.Append(ConstructCell(f.Operazione.ToString(), CellValues.String, 1));
                                rowDettaglio.Append(ConstructCell(numeroRiga.ToString(), CellValues.String, 1));
                                rowDettaglio.Append(ConstructCell(DateTime.Today.ToShortDateString(), CellValues.String, 1));
                                rowDettaglio.Append(ConstructCell(elemento, CellValues.String, 1));
                                sheetDataDettaglio.AppendChild(rowDettaglio);
                                numeroRiga += 1000;
                            }
                        }
                    }
                }
                workbookPart.Workbook.Save();
                document.Save();
                document.Close();

                ms.Seek(0, SeekOrigin.Begin);
                content = ms.ToArray();

                errori = sb.ToString().Trim();
                return content;
            }
        }

        private List<string> SeparaStringa(string stringa, int lunghezzaMassima)
        {
            List<string> stringhe = new List<string>();

            string[] str = stringa.Split(' ');
            string stringaComposta = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                if ((stringaComposta.Length + str[i].Length + 1) < lunghezzaMassima)
                {
                    stringaComposta = stringaComposta + " " + str[i];

                    if (i == str.Length - 1)
                    {
                        stringhe.Add(stringaComposta);
                    }
                }
                else
                {
                    stringhe.Add(stringaComposta);
                    stringaComposta = str[i];
                }
            }
            return stringhe;
        }

        public byte[] CreaFileCompoentiDistinta(List<Distinta> distinte, out string errori)
        {
            errori = string.Empty;
            StringBuilder sb = new StringBuilder();

            byte[] content;

            MemoryStream ms = new MemoryStream();

            using (SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart wsCicli = workbookPart.AddNewPart<WorksheetPart>();
                wsCicli.Worksheet = new Worksheet();

                // Adding style
                WorkbookStylesPart stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylePart.Stylesheet = GenerateStylesheet();
                stylePart.Stylesheet.Save();


                Columns colonne = new Columns();
                for (int i = 0; i < 16; i++)
                {
                    Column c = new Column();
                    UInt32Value u = new UInt32Value((uint)(i + 1));
                    c.Min = u;
                    c.Max = u;
                    c.Width = 25;
                    c.CustomWidth = true;

                    colonne.Append(c);
                }

                wsCicli.Worksheet.AppendChild(colonne);

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sTestata = new Sheet() { Id = workbookPart.GetIdOfPart(wsCicli), SheetId = 1, Name = "Righe DB produzione" };

                sheets.Append(sTestata);

                workbookPart.Workbook.Save();

                SheetData sheetDistinte = wsCicli.Worksheet.AppendChild(new SheetData());

                Row rowHeader = new Row();
                rowHeader.Append(ConstructCell("Nr. DB di produzione", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Cod. versione", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Nr. riga", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Tipo", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Nr.", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Descrizione", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Cod. unità di misura", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Quantità", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Cod. collegamento tra ciclo e distinta base", CellValues.String, 2));
                rowHeader.Append(ConstructCell("% scarto", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Quantità per", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Precious Quantity", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Formula quantità", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Codice condizione", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Nr. articolo neutro", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Cod. formula", CellValues.String, 2));
                sheetDistinte.AppendChild(rowHeader);

                foreach (Distinta d in distinte)
                {
                    int numeroRiga = 1000;
                    foreach (Componente c in d.Componenti)
                    {
                        Row row = new Row();
                        row.Append(ConstructCell(d.Codice, CellValues.String, 1));
                        row.Append(ConstructCell(d.Versione, CellValues.String, 1));
                        row.Append(ConstructCell(numeroRiga.ToString(), CellValues.String, 1));
                        numeroRiga += 1000;
                        row.Append(ConstructCell(c.Tipo, CellValues.String, 1));
                        row.Append(ConstructCell(c.Anagrafica, CellValues.String, 1));
                        row.Append(ConstructCell(c.Descrizione.ToString(), CellValues.String, 1));
                        row.Append(ConstructCell(c.CodiceUM.ToString(), CellValues.String, 1));
                        row.Append(ConstructCell(c.Quantita.ToString(), CellValues.String, 1));
                        row.Append(ConstructCell((c.Collegamento == null) ? string.Empty : c.Collegamento, CellValues.String, 1));
                        row.Append(ConstructCell(c.Scarto.ToString(), CellValues.String, 1));

                        row.Append(ConstructCell(c.Quantita.ToString(), CellValues.String, 1));
                        row.Append(ConstructCell(c.Arrotondamento.ToString(), CellValues.String, 1));
                        row.Append(ConstructCell(c.FormulaQuantita, CellValues.String, 1));
                        row.Append(ConstructCell(c.Condizione, CellValues.String, 1));
                        row.Append(ConstructCell(c.ArticoloNeutro, CellValues.String, 1));
                        row.Append(ConstructCell(c.Formula, CellValues.String, 1));
                        sheetDistinte.AppendChild(row);

                    }

                }

                workbookPart.Workbook.Save();
                document.Save();
                document.Close();

                ms.Seek(0, SeekOrigin.Begin);
                content = ms.ToArray();
            }
            errori = sb.ToString().Trim();
            return content;
        }
        public byte[] CreaFlussoFatture(List<string> idTestata, FlussoFattureDS ds, out string errori)
        {
            errori = string.Empty;
            StringBuilder sb = new StringBuilder();

            byte[] content;

            if (idTestata.Count == 0) return null;

            MemoryStream ms = new MemoryStream();

            using (SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart wsTestata = workbookPart.AddNewPart<WorksheetPart>();
                wsTestata.Worksheet = new Worksheet();

                WorksheetPart wsDettaglio = workbookPart.AddNewPart<WorksheetPart>();
                wsDettaglio.Worksheet = new Worksheet();

                // Adding style
                WorkbookStylesPart stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylePart.Stylesheet = GenerateStylesheet();
                stylePart.Stylesheet.Save();


                Columns colonneTestata = new Columns();
                for (int i = 0; i < 7; i++)
                {
                    Column c = new Column();
                    UInt32Value u = new UInt32Value((uint)(i + 1));
                    c.Min = u;
                    c.Max = u;
                    c.Width = 25;
                    c.CustomWidth = true;

                    colonneTestata.Append(c);
                }

                Columns colonneDettaglio = new Columns();
                for (int i = 0; i < 15; i++)
                {
                    Column c = new Column();
                    UInt32Value u = new UInt32Value((uint)(i + 1));
                    c.Min = u;
                    c.Max = u;
                    c.Width = 25;
                    c.CustomWidth = true;

                    colonneDettaglio.Append(c);
                }

                wsTestata.Worksheet.AppendChild(colonneTestata);
                wsDettaglio.Worksheet.AppendChild(colonneDettaglio);

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sTestata = new Sheet() { Id = workbookPart.GetIdOfPart(wsTestata), SheetId = 1, Name = "Headers" };
                Sheet sDettaglio = new Sheet() { Id = workbookPart.GetIdOfPart(wsDettaglio), SheetId = 2, Name = "Lines" };

                sheets.Append(sTestata);
                sheets.Append(sDettaglio);

                workbookPart.Workbook.Save();

                SheetData sheetDataTestata = wsTestata.Worksheet.AppendChild(new SheetData());
                SheetData sheetDataDettaglio = wsDettaglio.Worksheet.AppendChild(new SheetData());


                Row rowHeaderTestata = new Row();
                rowHeaderTestata.Append(ConstructCell("BC_SPEDIZIONE", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("BC_FATTURAREA", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("CODICETIPOO", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("FULLNUMDOC", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("DATDOC", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("PESOLORDO", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("PESONETTO", CellValues.String, 2));
                sheetDataTestata.AppendChild(rowHeaderTestata);

                Row rowHeaderDettaglio = new Row();
                rowHeaderDettaglio.Append(ConstructCell("FULLNUMDOC", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("CONTOCG", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("MODELLO", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("QTATOT", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("PREZZOUNI", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("CODIVARIGA", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("PSCONTO1", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("PESO", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("PESOLORDO", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("NRRIGA", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("RIFERIMENTO", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("RIFERIMENTORIGA", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("DESCRIZIONE", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("MATERIALE", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("UNIMI", CellValues.String, 2));

                sheetDataDettaglio.AppendChild(rowHeaderDettaglio);

                List<FlussoFattureDS.BC_FLUSSO_TESTATARow> righeTestate = ds.BC_FLUSSO_TESTATA.Where(x => idTestata.Contains(x.FULLNUMDOC)).ToList();
                //    righeTestate = righeTestate.OrderBy(x => x.FATTURAZIONE).ToList();

                foreach (FlussoFattureDS.BC_FLUSSO_TESTATARow testata in righeTestate)
                {
                    string documento = testata.FULLNUMDOC;

                    if (testata == null)
                    {
                        string messaggio = string.Format("Bolla non trovata: {0} LA BOLLA NON E' STATA ESPORTATA", documento);
                        sb.AppendLine(messaggio);
                        continue;
                    }
                    List<FlussoFattureDS.BC_FLUSSO_DETTAGLIORow> dettagli = ds.BC_FLUSSO_DETTAGLIO.Where(x => x.FULLNUMDOC == documento).ToList();
                    if (dettagli.Count == 0)
                    {
                        string messaggio = string.Format("Dettaglio bolla non trovati: {0} LA BOLLA NON E' STATA ESPORTATA", documento);
                        sb.AppendLine(messaggio);
                        continue;
                    }

                    if (testata.IsSPEDIZIONENull())
                    {
                        string messaggio = string.Format("Codice cliente spedizione non trovato FULLNUMDOC: {0} LA BOLLA NON E' STATA ESPORTATA", documento);
                        sb.AppendLine(messaggio);
                        continue;
                    }

                    if (testata.IsFATTURAZIONENull())
                    {
                        string messaggio = string.Format("Codice cliente fatturazione non trovato FULLNUMDOC: {0} LA BOLLA NON E' STATA ESPORTATA", documento);
                        sb.AppendLine(messaggio);
                        continue;
                    }
                    Row rowTestata = new Row();
                    rowTestata.Append(ConstructCell(testata.IsSPEDIZIONENull() ? string.Empty : testata.SPEDIZIONE, CellValues.String, 1));
                    rowTestata.Append(ConstructCell(testata.IsFATTURAZIONENull() ? string.Empty : testata.FATTURAZIONE, CellValues.String, 1));
                    rowTestata.Append(ConstructCell(testata.CODICETIPOO, CellValues.String, 1));
                    rowTestata.Append(ConstructCell(testata.NUMDOC, CellValues.String, 1));
                    rowTestata.Append(ConstructCell(testata.DATDOC.ToString("dd/MM/yyyy"), CellValues.String, 1));
                    rowTestata.Append(ConstructCell(testata.IsPESOLORDONull() ? string.Empty : testata.PESOLORDO.ToString(), CellValues.String, 1));
                    rowTestata.Append(ConstructCell(testata.IsPESONETTONull() ? string.Empty : testata.PESONETTO.ToString(), CellValues.String, 1));
                    sheetDataTestata.AppendChild(rowTestata);

                    foreach (FlussoFattureDS.BC_FLUSSO_DETTAGLIORow dettaglio in dettagli)
                    {
                        string riferimento = dettaglio.IsRIFERIMENTONull() ? string.Empty : dettaglio.RIFERIMENTO.ToString();
                        riferimento = riferimento.Replace(" ", "");

                        if (riferimento.Length > 20) riferimento = riferimento.Substring(0, 20);

                        string descrizione = dettaglio.IsDESCRIZIONENull() ? string.Empty : dettaglio.DESCRIZIONE.ToString();
                        string riferimento2 = dettaglio.IsRIFERIMENTO2Null() ? string.Empty : dettaglio.RIFERIMENTO2;
                        if (!dettaglio.IsNOTANull() || !dettaglio.IsRIFERIMENTO2Null())
                        {
                            string nota = dettaglio.IsNOTANull() ? string.Empty : dettaglio.NOTA;
                            nota = string.Format("{0} {1}", riferimento2, nota).Trim();
                            int lunghezzaResidua = descrizione.Length + nota.Length + 4 - 250;
                            if (lunghezzaResidua > 0)
                            {
                                nota = nota.Substring(0, nota.Length - lunghezzaResidua);
                            }
                            descrizione = string.Format("{0} ({1})", descrizione, nota);
                        }


                        Row rowDettaglio = new Row();
                        rowDettaglio.Append(ConstructCell(dettaglio.NUMDOC, CellValues.String, 1));
                        rowDettaglio.Append(ConstructCell(dettaglio.CONTOCG, CellValues.String, 1));
                        rowDettaglio.Append(ConstructCell(dettaglio.MODELLO, CellValues.String, 1));
                        rowDettaglio.Append(ConstructCell(dettaglio.QTATOT.ToString(), CellValues.String, 1));
                        rowDettaglio.Append(ConstructCell(dettaglio.PREZZOTOT.ToString(), CellValues.String, 1));
                        rowDettaglio.Append(ConstructCell(dettaglio.CODIVARIGA, CellValues.String, 1));
                        rowDettaglio.Append(ConstructCell(dettaglio.PSCONTO1.ToString(), CellValues.String, 1));
                        rowDettaglio.Append(ConstructCell(dettaglio.IsPESONull() ? string.Empty : dettaglio.PESO.ToString(), CellValues.String, 1));
                        rowDettaglio.Append(ConstructCell(dettaglio.IsPESONull() ? string.Empty : dettaglio.PESO.ToString(), CellValues.String, 1));
                        rowDettaglio.Append(ConstructCell(dettaglio.IsNRRIGANull() ? string.Empty : dettaglio.NRRIGA.ToString(), CellValues.String, 1));
                        rowDettaglio.Append(ConstructCell(riferimento, CellValues.String, 1));
                        rowDettaglio.Append(ConstructCell(dettaglio.IsRIFERIMENTORIGANull() ? string.Empty : dettaglio.RIFERIMENTORIGA.ToString(), CellValues.String, 1));

                        rowDettaglio.Append(ConstructCell(descrizione, CellValues.String, 1));
                        rowDettaglio.Append(ConstructCell(dettaglio.IsMATERIALENull() ? string.Empty : dettaglio.MATERIALE.ToString(), CellValues.String, 1));
                        rowDettaglio.Append(ConstructCell(dettaglio.IsUNIMINull() ? string.Empty : dettaglio.UNIMI.ToString(), CellValues.String, 1));
                        sheetDataDettaglio.AppendChild(rowDettaglio);

                        if (testata.FATTURAZIONE == "C00044" && !dettaglio.IsMATERIALENull())
                        {
                            FlussoFattureDS.MATERIALIMAMIRow materiale = ds.MATERIALIMAMI.Where(x => x.DESTABTIPM == dettaglio.MATERIALE).FirstOrDefault();

                            if (materiale == null || materiale.INFATTURA == "N") continue;

                            decimal peso = dettaglio.PESO * dettaglio.QTATOT;
                            peso = peso / 1000;

                            Row rowDettaglioMami = new Row();
                            rowDettaglioMami.Append(ConstructCell(dettaglio.NUMDOC, CellValues.String, 1));
                            rowDettaglioMami.Append(ConstructCell("0400007", CellValues.String, 1));
                            rowDettaglioMami.Append(ConstructCell(dettaglio.MATERIALE, CellValues.String, 1));
                            rowDettaglioMami.Append(ConstructCell(peso.ToString(), CellValues.String, 1));
                            rowDettaglioMami.Append(ConstructCell(materiale.PREZZO.ToString(), CellValues.String, 1));
                            rowDettaglioMami.Append(ConstructCell("022", CellValues.String, 1));
                            rowDettaglioMami.Append(ConstructCell(string.Empty, CellValues.String, 1));
                            rowDettaglioMami.Append(ConstructCell(string.Empty, CellValues.String, 1));
                            rowDettaglioMami.Append(ConstructCell(string.Empty, CellValues.String, 1));
                            rowDettaglioMami.Append(ConstructCell(string.Empty, CellValues.String, 1));
                            rowDettaglioMami.Append(ConstructCell("-", CellValues.String, 1));
                            rowDettaglioMami.Append(ConstructCell(string.Empty, CellValues.String, 1));

                            rowDettaglioMami.Append(ConstructCell(string.Empty, CellValues.String, 1));
                            rowDettaglioMami.Append(ConstructCell(string.Empty, CellValues.String, 1));
                            rowDettaglioMami.Append(ConstructCell("KG", CellValues.String, 1));
                            sheetDataDettaglio.AppendChild(rowDettaglioMami);
                        }

                    }
                }

                workbookPart.Workbook.Save();
                document.Save();
                document.Close();

                ms.Seek(0, SeekOrigin.Begin);
                content = ms.ToArray();
            }
            errori = sb.ToString().Trim();
            return content;
        }

        public byte[] CreaExcelOpera(List<SpedizioniDS.SPOPERARow> righeDaSalvare)
        {
            byte[] content;

            if (righeDaSalvare.Count == 0) return null;

            MemoryStream ms = new MemoryStream();

            using (SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();

                // Adding style
                WorkbookStylesPart stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylePart.Stylesheet = GenerateStylesheet();
                stylePart.Stylesheet.Save();

                int numeroColonne = righeDaSalvare[0].Table.Columns.Count;
                List<int> colonneDaScartare = new List<int>(new int[] { 6, 10, 11, 12, 14, 15, 16, 17 });
                Columns columns = new Columns();
                for (int i = 0; i < (numeroColonne - colonneDaScartare.Count); i++)
                {
                    Column c = new Column();
                    UInt32Value u = new UInt32Value((uint)(i + 1));
                    c.Min = u;
                    c.Max = u;
                    c.Width = 15;
                    c.CustomWidth = true;

                    columns.Append(c);
                }

                worksheetPart.Worksheet.AppendChild(columns);

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                string nome = DateTime.Today.AddDays(1).ToShortDateString();
                nome = nome.Replace('/', '.');
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = nome };

                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header

                Row row = new Row();

                for (int i = 0; i < numeroColonne; i++)
                {
                    if (colonneDaScartare.Contains(i)) continue;

                    string etichetta = righeDaSalvare[0].Table.Columns[i].ColumnName;
                    row.Append(ConstructCell(etichetta, CellValues.String, 2));
                }

                // Insert the header row to the Sheet Data
                sheetData.AppendChild(row);
                foreach (SpedizioniDS.SPOPERARow riga in righeDaSalvare)
                {
                    Row rowDati = new Row();
                    for (int i = 0; i < numeroColonne; i++)
                    {
                        if (colonneDaScartare.Contains(i)) continue;
                        string valore = riga[i].ToString();
                        rowDati.Append(ConstructCell(valore, CellValues.String, 1));
                    }

                    sheetData.AppendChild(rowDati);
                }

                workbookPart.Workbook.Save();
                document.Save();
                document.Close();

                ms.Seek(0, SeekOrigin.Begin);
                content = ms.ToArray();
            }

            return content;
        }

        public byte[] CreaExcelSpedizioni(SpedizioniDS ds)
        {
            byte[] content;
            MemoryStream ms = new MemoryStream();

            using (SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();

                // Adding style
                WorkbookStylesPart stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylePart.Stylesheet = GenerateStylesheet();
                stylePart.Stylesheet.Save();

                int numeroColonne = ds.SPSALDIEXT.Columns.Count;
                List<int> colonneDaScartare = new List<int>(new int[] { 0, 1, 2, 4, 5 });
                List<int> colonneDaVisualizzare = new List<int>(new int[] { 6, 7, 8, 3 });
                Columns columns = new Columns();
                for (int i = 0; i < (colonneDaVisualizzare.Count); i++)
                //                    for (int i = 0; i < (numeroColonne - colonneDaScartare.Count);  i++)
                {
                    Column c = new Column();
                    UInt32Value u = new UInt32Value((uint)(i + 1));
                    c.Min = u;
                    c.Max = u;
                    c.Width = 15;
                    c.CustomWidth = true;

                    columns.Append(c);
                }

                worksheetPart.Worksheet.AppendChild(columns);

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                string nome = DateTime.Today.AddDays(1).ToShortDateString();
                nome = nome.Replace('/', '.');
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = nome };

                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                Row row = new Row();

                for (int i = 0; i < colonneDaVisualizzare.Count; i++)
                {
                    //                    if (colonneDaScartare.Contains(i)) continue;
                    string etichetta = ds.SPSALDIEXT.Columns[colonneDaVisualizzare[i]].ColumnName;
                    row.Append(ConstructCell(etichetta, CellValues.String, 2));
                }

                sheetData.AppendChild(row);
                foreach (SpedizioniDS.SPSALDIEXTRow riga in ds.SPSALDIEXT)   //.Where(x => !x.IsQUANTITANull() && x.QUANTITA > 0).OrderBy(x => x.IsIDUBICAZIONENull() ? -1 : x.IDUBICAZIONE))
                {
                    Row rowDati = new Row();
                    for (int i = 0; i < colonneDaVisualizzare.Count; i++)
                    {
                        //   if (colonneDaScartare.Contains(i)) continue;
                        string valore = riga[colonneDaVisualizzare[i]].ToString();
                        rowDati.Append(ConstructCell(valore, CellValues.String, 1));
                    }

                    sheetData.AppendChild(rowDati);
                }

                workbookPart.Workbook.Save();
                document.Save();
                document.Close();

                ms.Seek(0, SeekOrigin.Begin);
                content = ms.ToArray();
            }

            return content;
        }


        public byte[] CreaExcelPianificazioneGalvanica(GalvanicaDS ds)
        {
            byte[] content;
            MemoryStream ms = new MemoryStream();

            using (SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();

                // Adding style
                WorkbookStylesPart stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylePart.Stylesheet = GenerateStylesheet();
                stylePart.Stylesheet.Save();

                int numeroColonne = ds.GALVANICA_CARICO.Columns.Count;
                List<int> colonneDaScartare = new List<int>(new int[] { 0, 1, 2, 4, 15, 16 });
                Columns columns = new Columns();
                for (int i = 0; i < (numeroColonne - colonneDaScartare.Count); i++)
                {
                    Column c = new Column();
                    UInt32Value u = new UInt32Value((uint)(i + 1));
                    c.Min = u;
                    c.Max = u;
                    c.Width = 15;
                    c.CustomWidth = true;

                    columns.Append(c);
                }

                worksheetPart.Worksheet.AppendChild(columns);

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                string nome = DateTime.Today.AddDays(1).ToShortDateString();
                nome = nome.Replace('/', '.');
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = nome };

                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header

                Row row = new Row();

                for (int i = 0; i < numeroColonne; i++)
                {
                    if (colonneDaScartare.Contains(i)) continue;

                    string etichetta = ds.GALVANICA_CARICO.Columns[i].ColumnName;
                    row.Append(ConstructCell(etichetta, CellValues.String, 2));
                }

                // Insert the header row to the Sheet Data
                sheetData.AppendChild(row);
                foreach (GalvanicaDS.GALVANICA_CARICORow riga in ds.GALVANICA_CARICO.Where(x => !x.IsPIANIFICATONull() && x.PIANIFICATO > 0).OrderBy(x => x.IsORDINENull() ? -1 : x.ORDINE))
                {
                    Row rowDati = new Row();
                    for (int i = 0; i < numeroColonne; i++)
                    {
                        if (colonneDaScartare.Contains(i)) continue;
                        string valore = riga[i].ToString();
                        rowDati.Append(ConstructCell(valore, CellValues.String, 1));
                    }

                    sheetData.AppendChild(rowDati);
                }

                workbookPart.Workbook.Save();
                document.Save();
                document.Close();

                ms.Seek(0, SeekOrigin.Begin);
                content = ms.ToArray();
            }

            return content;
        }

        public static void InsertText(string docName, string colonna, int riga, string text, bool isNumeric)
        {
            // Open the document for editing.
            using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(docName, true))
            {
                // Get the SharedStringTablePart. If it does not exist, create a new one.
                SharedStringTablePart shareStringPart;
                if (spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0)
                {
                    shareStringPart = spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
                }
                else
                {
                    shareStringPart = spreadSheet.WorkbookPart.AddNewPart<SharedStringTablePart>();
                }

                // Insert the text into the SharedStringTablePart.
                int index = InsertSharedStringItem(text, shareStringPart);

                // Insert a new worksheet.
                Sheets sheets = spreadSheet.WorkbookPart.Workbook.GetFirstChild<Sheets>();
                Sheet s = sheets.Elements<Sheet>().FirstOrDefault();

                WorksheetPart worksheetPart = (WorksheetPart)spreadSheet.WorkbookPart.GetPartById(s.Id);

                // Insert cell A1 into the new worksheet.
                Cell cell = InsertCellInWorksheet(colonna.ToUpper(), (uint)riga, worksheetPart);

                // Set the value of cell A1.
                if (isNumeric)
                {
                    cell.CellValue = new CellValue(text.Replace(',', '.'));
                    cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                }
                else
                {
                    cell.CellValue = new CellValue(index.ToString());
                    cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
                }

                spreadSheet.WorkbookPart.Workbook.CalculationProperties.ForceFullCalculation = true;
                spreadSheet.WorkbookPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;
                // Save the new worksheet.
                worksheetPart.Worksheet.Save();
            }
        }

        private static int InsertSharedStringItem(string text, SharedStringTablePart shareStringPart)
        {
            // If the part does not contain a SharedStringTable, create one.
            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SharedStringTable();
            }

            int i = 0;

            // Iterate through all the items in the SharedStringTable. If the text already exists, return its index.
            foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    return i;
                }

                i++;
            }

            // The text does not exist in the part. Create the SharedStringItem and return its index.
            shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
            shareStringPart.SharedStringTable.Save();

            return i;
        }

        // Given a WorkbookPart, inserts a new worksheet.
        private static WorksheetPart InsertWorksheet(WorkbookPart workbookPart)
        {
            // Add a new worksheet part to the workbook.
            WorksheetPart newWorksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            newWorksheetPart.Worksheet = new Worksheet(new SheetData());
            newWorksheetPart.Worksheet.Save();

            Sheets sheets = workbookPart.Workbook.GetFirstChild<Sheets>();
            string relationshipId = workbookPart.GetIdOfPart(newWorksheetPart);

            // Get a unique ID for the new sheet.
            uint sheetId = 1;
            if (sheets.Elements<Sheet>().Count() > 0)
            {
                sheetId = sheets.Elements<Sheet>().Select(s => s.SheetId.Value).Max() + 1;
            }

            string sheetName = "Sheet" + sheetId;

            // Append the new worksheet and associate it with the workbook.
            Sheet sheet = new Sheet() { Id = relationshipId, SheetId = sheetId, Name = sheetName };
            sheets.Append(sheet);
            workbookPart.Workbook.Save();

            return newWorksheetPart;
        }

        private static Cell InsertCellInWorksheet(string columnName, uint rowIndex, WorksheetPart worksheetPart)
        {
            Worksheet worksheet = worksheetPart.Worksheet;
            SheetData sheetData = worksheet.GetFirstChild<SheetData>();
            string cellReference = columnName + rowIndex;

            // If the worksheet does not contain a row with the specified row index, insert one.
            Row row;
            if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
            {
                row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
            }
            else
            {
                row = new Row() { RowIndex = rowIndex };
                sheetData.Append(row);
            }

            // If there is not a cell with the specified column name, insert one.  
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == columnName + rowIndex).Count() > 0)
            {
                return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
            }
            else
            {
                // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
                Cell refCell = null;
                foreach (Cell cell in row.Elements<Cell>())
                {
                    if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
                    {
                        refCell = cell;
                        break;
                    }
                }

                Cell newCell = new Cell() { CellReference = cellReference };
                row.InsertBefore(newCell, refCell);

                worksheet.Save();
                return newCell;
            }
        }

        public Cell ConstructCell(string value, CellValues dataType, uint styleIndex = 0)
        {
            return new Cell()
            {
                CellValue = new CellValue(value),
                DataType = new EnumValue<CellValues>(dataType),
                StyleIndex = styleIndex
            };
        }

        public Cell ConstructCell(string value, CellValues dataType, string riferimento, uint styleIndex = 0)
        {
            return new Cell()
            {
                CellValue = new CellValue(value),
                DataType = new EnumValue<CellValues>(dataType),
                StyleIndex = styleIndex,
                CellReference = riferimento
            };
        }
        public Stylesheet GenerateStylesheet()
        {
            Stylesheet styleSheet = null;

            Fonts fonts = new Fonts(
                new Font( // Index 0 - default
                    new FontSize() { Val = 10 }

                ),
                new Font( // Index 1 - header
                    new FontSize() { Val = 10 },
                    new Bold(),
                    new Color() { Rgb = "FFFFFF" }

                ));

            Fills fills = new Fills(
                    new Fill(new PatternFill() { PatternType = PatternValues.None }), // Index 0 - default
                    new Fill(new PatternFill() { PatternType = PatternValues.Gray125 }), // Index 1 - default
                    new Fill(new PatternFill(new ForegroundColor { Rgb = new HexBinaryValue() { Value = "66666666" } })
                    { PatternType = PatternValues.Solid }) // Index 2 - header
                );

            Borders borders = new Borders(
                    new Border(), // index 0 default
                    new Border( // index 1 black border
                        new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new DiagonalBorder())
                );

            CellFormats cellFormats = new CellFormats(
                    new CellFormat(), // default
                    new CellFormat { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true }, // body
                    new CellFormat { FontId = 1, FillId = 2, BorderId = 1, ApplyFill = true } // header
                );

            styleSheet = new Stylesheet(fonts, fills, borders, cellFormats);

            return styleSheet;
        }

        private Sheet EstraiSheetPerNome(WorkbookPart wbPart, string nomeDaTrovare)
        {
            Sheets fogliExcel = wbPart.Workbook.Sheets;
            foreach (Sheet foglio in fogliExcel)
            {
                if (foglio.Name == nomeDaTrovare) return foglio;
            }
            return null;
        }

        private string EstraiValoreCella(Cell cell, SharedStringTable sharedStringTable, CellFormats cellFormats, NumberingFormats numberingFormats)
        {
            CellValue cellValue = cell.CellValue;
            if (cellValue != null)
            {
                if (cell.DataType != null)
                {
                    switch (cell.DataType.Value)
                    {
                        case CellValues.SharedString:
                            if (string.IsNullOrEmpty(cell.InnerText)) return string.Empty;
                            return sharedStringTable.ElementAt(Int32.Parse(cell.InnerText)).InnerText;

                        case CellValues.Date:
                            double oaDateAsDouble;
                            if (double.TryParse(cell.InnerText, out oaDateAsDouble)) //this line is Culture dependent!
                            {
                                DateTime dateTime = DateTime.FromOADate(oaDateAsDouble);
                                return dateTime.ToShortDateString();
                            }
                            return string.Empty;


                        default:
                            return cell.InnerText;
                    }
                }
                else
                {
                    if (cell.StyleIndex != null)
                    {
                        var cellFormat = (CellFormat)cellFormats.ElementAt((int)cell.StyleIndex.Value);
                        if (cellFormat.NumberFormatId != null)
                        {
                            if (numberingFormats == null) return cell.InnerText;

                            var numberFormatId = cellFormat.NumberFormatId.Value;
                            var numberingFormat = numberingFormats.Cast<NumberingFormat>()
                                .SingleOrDefault(f => f.NumberFormatId.Value == numberFormatId);

                            // Here's yer string! Example: $#,##0.00_);[Red]($#,##0.00)
                            if (numberingFormat != null && (numberingFormat.FormatCode.Value.Contains("yyyy-mm-dd") || numberingFormat.FormatCode.Value.Contains("yyyy\\-mm\\-dd")))
                            {
                                string formatString = numberingFormat.FormatCode.Value;
                                double oaDateAsDouble;
                                if (double.TryParse(cell.InnerText, out oaDateAsDouble)) //this line is Culture dependent!
                                {
                                    DateTime dateTime = DateTime.FromOADate(oaDateAsDouble);
                                    return dateTime.ToShortDateString();
                                }
                                else
                                    return string.Empty;
                            }
                            else
                                return cell.InnerText;
                        }
                    }
                    else
                        return cell.InnerText;
                }

            }

            return string.Empty;

        }

        private string EstraiStringaDaCella(string cella, int lunghezzaMassimaConsentita)
        {
            return cella.Length > lunghezzaMassimaConsentita ? cella.Substring(0, lunghezzaMassimaConsentita) : cella;
        }
        private bool EstraiValoreCellaDecimal(string cella, string colonna, SpedizioniDS.SPOPERARow dettaglio, out string messaggioErrore)
        {
            messaggioErrore = string.Empty;
            decimal aux;
            if (!decimal.TryParse(cella, out aux))
            {
                messaggioErrore = string.Format("Errore lettura colonna ID {0} il valore non è un numero", colonna);
                return false;
            }
            else
            {
                dettaglio[colonna] = aux;

            }
            return true;
        }

        private bool EstraiValoreCellaDatetime(string cella, string colonna, SpedizioniDS.SPOPERARow dettaglio, out string messaggioErrore)
        {
            messaggioErrore = string.Empty;
            DateTime aux;
            if (!DateTime.TryParse(cella, out aux))
            {
                messaggioErrore = string.Format("Errore lettura colonna ID {0} il valore non è una data", colonna);
                return false;
            }
            else
            {
                dettaglio[colonna] = aux;

            }
            return true;
        }

        private string GetColumnReference(Cell cell)
        {
            List<char> numeri = new List<char>(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
            string reference = cell.CellReference;
            string colonna = string.Empty;
            if (reference == null) return colonna;
            foreach (char ch in reference.ToCharArray())
            {
                if (!numeri.Contains(ch))
                {
                    colonna = colonna + ch;
                }
            }
            return colonna;
        }

        public bool LeggiFileExcelOpera(Stream stream, SpedizioniDS ds, out string messaggioErrore)

        {
            messaggioErrore = string.Empty;
            SpreadsheetDocument document = SpreadsheetDocument.Open(stream, true);
            SharedStringTable sharedStringTable = document.WorkbookPart.SharedStringTablePart.SharedStringTable;

            WorkbookPart wbPart = document.WorkbookPart;

            Sheet foglio = EstraiSheetPerNome(wbPart, "Sheet");
            WorksheetPart worksheetPart = (WorksheetPart)wbPart.GetPartById(foglio.Id);
            SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

            CellFormats cellFormats = wbPart.WorkbookStylesPart.Stylesheet.CellFormats;
            NumberingFormats numberingFormats = wbPart.WorkbookStylesPart.Stylesheet.NumberingFormats;

            int rowCount = sheetData.Elements<Row>().Count();

            int scartaRighe = 1;
            int indiceRighe = 0;

            foreach (Row r in sheetData.Elements<Row>())
            {
                if (indiceRighe < scartaRighe)
                {
                    indiceRighe++;
                    continue;
                }
                bool esito = true;

                if (r.FirstChild.InnerText == string.Empty) continue;

                SpedizioniDS.SPOPERARow operaRow = ds.SPOPERA.NewSPOPERARow();
                operaRow.SEQUENZA = 1;
                operaRow.VALIDATA = false;

                string elemento = string.Empty;
                foreach (Cell cell in r.Elements<Cell>())
                {
                    string cella = EstraiValoreCella(cell, sharedStringTable, cellFormats, numberingFormats);
                    cella = cella.Trim();
                    string colonna = GetColumnReference(cell);
                    switch (colonna)
                    {
                        case "A":
                            if (string.IsNullOrEmpty(cella))
                                continue;
                            operaRow.BRAND = EstraiStringaDaCella(cella, ds.SPOPERA.Columns[0].MaxLength);

                            //esito = EstraiValoreCellaDecimal(cella, "IDPRENOTAZIONE", cPiombo, out messaggioErrore);
                            break;
                        case "B":
                            {
                                operaRow.RAGIONE_SOCIALE_RIGA = EstraiStringaDaCella(cella, ds.SPOPERA.Columns[1].MaxLength);
                            }
                            break;
                        case "C":
                            {
                                operaRow.STAGIONE_DESCRIZIONE_TESTATA = EstraiStringaDaCella(cella, ds.SPOPERA.Columns[2].MaxLength);
                            }
                            break;
                        case "D":
                            {
                                operaRow.RIFERIMENTO_TESTATA = EstraiStringaDaCella(cella, ds.SPOPERA.Columns[3].MaxLength);
                            }
                            break;
                        case "E":
                            {
                                operaRow.NUMERO_RIGA = EstraiStringaDaCella(cella, ds.SPOPERA.Columns[4].MaxLength);
                            }
                            break;
                        case "F":
                            {
                                double aux;
                                if (double.TryParse(cella.Replace('.', ','), out aux))
                                {
                                    DateTime dt = DateTime.FromOADate(aux);
                                    operaRow.DATA_RICHIESTA = dt;
                                }
                                //        esito = EstraiValoreCellaDatetime(cella, "DATA_RICHIESTA", operaRow, out messaggioErrore);
                            }
                            break;
                        case "G":
                            {
                                double aux;
                                if (double.TryParse(cella.Replace('.', ','), out aux))
                                {
                                    DateTime dt = DateTime.FromOADate(aux);
                                    operaRow.DATA_CREAZIONE = dt;
                                }
                                //                                esito = EstraiValoreCellaDatetime(cella, "DATA_CREAZIONE", operaRow, out messaggioErrore);
                            }
                            break;
                        case "H":
                            {
                                operaRow.MODELLO_CODICE = EstraiStringaDaCella(cella, ds.SPOPERA.Columns[7].MaxLength);
                            }
                            break;
                        case "I":
                            {
                                operaRow.DESMODELLO = EstraiStringaDaCella(cella, ds.SPOPERA.Columns[8].MaxLength);
                            }
                            break;
                        case "J":
                            {
                                if (!string.IsNullOrEmpty(cella))
                                    esito = EstraiValoreCellaDecimal(cella, "QTANOSPE", operaRow, out messaggioErrore);
                                break;
                            }
                        case "K":
                            {
                                if (!string.IsNullOrEmpty(cella))
                                    esito = EstraiValoreCellaDecimal(cella, "PREZZO_UNITARIO", operaRow, out messaggioErrore);
                            }
                            break;
                        case "L":
                            {
                                if (!string.IsNullOrEmpty(cella))
                                    esito = EstraiValoreCellaDecimal(cella, "QTAACCESI", operaRow, out messaggioErrore);
                            }
                            break;
                        case "M":
                            {
                                if (!string.IsNullOrEmpty(cella))
                                    esito = EstraiValoreCellaDecimal(cella, "QTAEST", operaRow, out messaggioErrore);
                            }
                            break;
                        case "N":
                            {
                                if (!string.IsNullOrEmpty(cella))
                                    esito = EstraiValoreCellaDecimal(cella, "QTATOT", operaRow, out messaggioErrore);
                            }
                            break;
                        case "O":
                            {
                                if (!string.IsNullOrEmpty(cella))
                                    esito = EstraiValoreCellaDecimal(cella, "QTAACCCON", operaRow, out messaggioErrore);
                            }
                            break;
                        case "P":
                            {
                                if (!string.IsNullOrEmpty(cella))
                                    esito = EstraiValoreCellaDecimal(cella, "QTANOACC", operaRow, out messaggioErrore);
                            }
                            break;
                        case "Q":
                            {
                                if (!string.IsNullOrEmpty(cella))
                                    esito = EstraiValoreCellaDecimal(cella, "QTASPE", operaRow, out messaggioErrore);
                            }
                            break;

                    }
                    if (!esito)
                        return false;
                }
                ds.SPOPERA.AddSPOPERARow(operaRow);
            }

            return true;
        }

        public TipoExcel IdentificaTipoFIleExcelneExcelDibaRVL(string filePath)
        {
            TipoExcel tipoExcel;
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
            {
                MemoryStream ms = new MemoryStream();
                byte[] dati = new byte[fs.Length];
                fs.Read(dati, 0, (int)fs.Length);
                tipoExcel = IdentificaTipoFIleExcelneExcelDibaRVL(fs);
                fs.Close();
            }
            return tipoExcel;
        }

        public TipoExcel IdentificaTipoFIleExcelneExcelDibaRVL(Stream stream)
        {
            SpreadsheetDocument document = SpreadsheetDocument.Open(stream, true);
            SharedStringTable sharedStringTable = document.WorkbookPart.SharedStringTablePart.SharedStringTable;

            WorkbookPart wbPart = document.WorkbookPart;

            Sheet foglio = EstraiSheetPerNome(wbPart, "Sheet");
            WorksheetPart worksheetPart = (WorksheetPart)wbPart.GetPartById(foglio.Id);
            SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

            CellFormats cellFormats = wbPart.WorkbookStylesPart.Stylesheet.CellFormats;
            NumberingFormats numberingFormats = wbPart.WorkbookStylesPart.Stylesheet.NumberingFormats;


            bool articoloDescrizione = false;
            bool idMagazz = false;


            foreach (Row r in sheetData.Elements<Row>())
            {
                foreach (Cell cell in r.Elements<Cell>())
                {
                    string cella = EstraiValoreCella(cell, sharedStringTable, cellFormats, numberingFormats);
                    if (cella.Trim() == Etichette.ArticoloDescrizione)
                        articoloDescrizione = true;

                    if (cella.Trim() == Etichette.IDMAGAZZ)
                        idMagazz = true;

                }
                break;
            }
            if (idMagazz) return TipoExcel.IdMagazz;
            if (articoloDescrizione) return TipoExcel.RVL;

            return TipoExcel.Sconosciuto;
        }

        public bool LeggiFileExcelTipoIDMAGAZ(Stream stream, MigrazioneDiBaDS ds, out string messaggioErrore)
        {
            ds.DATIEXCEL.Clear();
            messaggioErrore = string.Empty;
            SpreadsheetDocument document = SpreadsheetDocument.Open(stream, true);
            SharedStringTable sharedStringTable = document.WorkbookPart.SharedStringTablePart.SharedStringTable;

            WorkbookPart wbPart = document.WorkbookPart;

            Sheet foglio = EstraiSheetPerNome(wbPart, "Sheet");
            WorksheetPart worksheetPart = (WorksheetPart)wbPart.GetPartById(foglio.Id);
            SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

            CellFormats cellFormats = wbPart.WorkbookStylesPart.Stylesheet.CellFormats;
            NumberingFormats numberingFormats = wbPart.WorkbookStylesPart.Stylesheet.NumberingFormats;

            int rowCount = sheetData.Elements<Row>().Count();

            string rifMODELLO = string.Empty;
            string rifDESCRIZIONE = string.Empty;
            string rifIDMAGAZZ = string.Empty;
            string rifANAGRAFICA = string.Empty;
            string rifCODICECICLO = string.Empty;
            string rifCODICEFASE = string.Empty;
            string rifREPARTO = string.Empty;
            string rifQUANTITA = string.Empty;
            string rifUM = string.Empty;
            string rifNOTA = string.Empty;
            string rifPESO = string.Empty;
            string rifSUPERFICIE = string.Empty;
            string rifPEZZIORARI = string.Empty;
            string rifCOLLEGAMENTO = string.Empty;

            int indiceColonna = 0;
            string ultimoriferimentocolonna = string.Empty;
            int indiceUltimaColonna = 0;
            int indicePrimoRiferimento = 100;
            foreach (Row r in sheetData.Elements<Row>())
            {
                indiceColonna = 0;
                foreach (Cell cell in r.Elements<Cell>())
                {
                    string cella = EstraiValoreCella(cell, sharedStringTable, cellFormats, numberingFormats);
                    switch (cella.Trim())
                    {
                        case Etichette.PezziOrari:
                            rifPEZZIORARI = GetColumnReference(cell);
                            if (indicePrimoRiferimento > indiceColonna) indicePrimoRiferimento = indiceColonna;
                            break;
                        case Etichette.Collegamento:
                            rifCOLLEGAMENTO = GetColumnReference(cell);
                            if (indicePrimoRiferimento > indiceColonna) indicePrimoRiferimento = indiceColonna;
                            break;
                        case Etichette.ArticoloDescrizione:
                            rifDESCRIZIONE = GetColumnReference(cell);
                            if (indicePrimoRiferimento > indiceColonna) indicePrimoRiferimento = indiceColonna;
                            break;
                        case Etichette.Anagrafica:
                            rifANAGRAFICA = GetColumnReference(cell);
                            if (indicePrimoRiferimento > indiceColonna) indicePrimoRiferimento = indiceColonna;
                            break;
                        case Etichette.CodiceCiclo:
                            rifCODICECICLO = GetColumnReference(cell);
                            if (indicePrimoRiferimento > indiceColonna) indicePrimoRiferimento = indiceColonna;
                            break;
                        case Etichette.IDMAGAZZ:
                            rifIDMAGAZZ = GetColumnReference(cell);
                            if (indicePrimoRiferimento > indiceColonna) indicePrimoRiferimento = indiceColonna;
                            break;
                        case Etichette.CodiceFase:
                            rifCODICEFASE = GetColumnReference(cell);
                            if (indicePrimoRiferimento > indiceColonna) indicePrimoRiferimento = indiceColonna;
                            break;
                        case Etichette.CodiceReparto:
                            rifREPARTO = GetColumnReference(cell);
                            if (indicePrimoRiferimento > indiceColonna) indicePrimoRiferimento = indiceColonna;
                            break;
                        case Etichette.Consumo:
                            rifQUANTITA = GetColumnReference(cell);
                            if (indicePrimoRiferimento > indiceColonna) indicePrimoRiferimento = indiceColonna;
                            break;
                        case Etichette.UnitaMisura:
                            rifUM = GetColumnReference(cell);
                            if (indicePrimoRiferimento > indiceColonna) indicePrimoRiferimento = indiceColonna;
                            break;
                        case Etichette.Note:
                            rifNOTA = GetColumnReference(cell);
                            if (indicePrimoRiferimento > indiceColonna) indicePrimoRiferimento = indiceColonna;
                            break;
                        case Etichette.Peso:
                            rifPESO = GetColumnReference(cell);
                            if (indicePrimoRiferimento > indiceColonna) indicePrimoRiferimento = indiceColonna;
                            break;
                        case Etichette.Superficie:
                            rifSUPERFICIE = GetColumnReference(cell);
                            if (indicePrimoRiferimento > indiceColonna) indicePrimoRiferimento = indiceColonna;
                            break;
                    }
                    ultimoriferimentocolonna = GetColumnReference(cell);
                    indiceColonna++;
                }
                break;
            }
            indiceUltimaColonna = indiceColonna;

            int scartaRighe = 1;
            int indiceRighe = 0;
            foreach (Row r in sheetData.Elements<Row>())
            {
                if (indiceRighe < scartaRighe)
                {
                    indiceRighe++;
                    continue;
                }

                MigrazioneDiBaDS.DATIEXCELRow rigaDatiExcel = ds.DATIEXCEL.NewDATIEXCELRow();
                rigaDatiExcel.IDDATAEXCEL = indiceRighe;
                indiceRighe++;

                string elemento = string.Empty;
                decimal aux;
                int avanti = 0;
                int dietro = 0;
                indiceColonna = 0;

                foreach (Cell cell in r.Elements<Cell>())
                {
                    string cella = EstraiValoreCella(cell, sharedStringTable, cellFormats, numberingFormats);
                    cella = cella.Trim();
                    string colonna = GetColumnReference(cell);

                    if (colonna == rifDESCRIZIONE) rigaDatiExcel.DESCRIZIONE = cella;
                    if (colonna == rifIDMAGAZZ) rigaDatiExcel.IDMAGAZZ = cella;
                    if (colonna == rifANAGRAFICA) rigaDatiExcel.ANAGRAFICA = cella;
                    if (colonna == rifCODICECICLO) rigaDatiExcel.CODICECICLO = cella;
                    if (colonna == rifCODICEFASE) rigaDatiExcel.CODICEFASE = cella;
                    if (colonna == rifREPARTO) rigaDatiExcel.REPARTO = cella;
                    if (colonna == rifQUANTITA) rigaDatiExcel.QUANTITA = decimal.TryParse(cella, out aux) ? aux : 0;
                    if (colonna == rifUM) rigaDatiExcel.UM = cella;
                    if (colonna == rifNOTA) rigaDatiExcel.NOTA = cella;
                    if (colonna == rifPESO) rigaDatiExcel.PESO = decimal.TryParse(cella, out aux) ? aux : 0;
                    if (colonna == rifSUPERFICIE) rigaDatiExcel.SUPERFICIE = decimal.TryParse(cella, out aux) ? aux : 0;
                    if (colonna == rifPEZZIORARI) rigaDatiExcel.PEZZIORARI = decimal.TryParse(cella, out aux) ? aux : 0;
                    if (colonna == rifCOLLEGAMENTO) rigaDatiExcel.COLLEGAMENTO = cella;

                    if (indiceColonna < indicePrimoRiferimento)
                    {
                        if (string.IsNullOrEmpty(cella))
                        {
                            avanti++;
                            dietro++;
                        }
                        else
                        {
                            rigaDatiExcel.AVANTI = avanti;
                            rigaDatiExcel.MODELLO = cella;
                            dietro = 0;
                        }
                    }
                    if (indiceColonna == indicePrimoRiferimento)
                        rigaDatiExcel.DIETRO = dietro;

                    indiceColonna++;
                }
                ds.DATIEXCEL.AddDATIEXCELRow(rigaDatiExcel);
            }

            return true;
        }

        public bool AggiungiColonneExcelDibaRVL(MigrazioneDiBaDS ds, Stream stream, out string messaggioErrore)

        {
            messaggioErrore = string.Empty;
            SpreadsheetDocument document = SpreadsheetDocument.Open(stream, true);
            SharedStringTable sharedStringTable = document.WorkbookPart.SharedStringTablePart.SharedStringTable;

            WorkbookPart wbPart = document.WorkbookPart;

            Sheet foglio = EstraiSheetPerNome(wbPart, "Sheet");
            WorksheetPart worksheetPart = (WorksheetPart)wbPart.GetPartById(foglio.Id);
            SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

            CellFormats cellFormats = wbPart.WorkbookStylesPart.Stylesheet.CellFormats;
            NumberingFormats numberingFormats = wbPart.WorkbookStylesPart.Stylesheet.NumberingFormats;

            int indiceColonna = 0;
            int posizioneNuovaColonna = 0;
            string ultimoriferimentocolonna = string.Empty;
            int indiceUltimaColonna = 0;
            foreach (Row r in sheetData.Elements<Row>())
            {
                indiceColonna = 0;
                foreach (Cell cell in r.Elements<Cell>())
                {
                    string cella = EstraiValoreCella(cell, sharedStringTable, cellFormats, numberingFormats);
                    if (cella.Trim() == Etichette.ArticoloDescrizione)
                    {
                        posizioneNuovaColonna = indiceColonna;
                    }
                    ultimoriferimentocolonna = GetColumnReference(cell);
                    indiceColonna++;
                }
                break;
            }
            indiceUltimaColonna = indiceColonna;

            indiceUltimaColonna++;
            AggiungiColonna(worksheetPart, indiceUltimaColonna);


            int indiceRiga = 0;
            foreach (Row r in sheetData.Elements<Row>())
            {
                indiceColonna = 0;
                string valorePrecedente = string.Empty;
                string idmagazz = string.Empty;
                foreach (Cell cell in r.Elements<Cell>())
                {
                    string valoreAttuale = EstraiValoreCella(cell, sharedStringTable, cellFormats, numberingFormats);

                    if (indiceColonna == (posizioneNuovaColonna))
                    {
                        if (indiceRiga > 0)
                        {
                            idmagazz = ds.MAGAZZ.Where(x => x.DESMAGAZZ == valoreAttuale).Select(x => x.IDMAGAZZ).FirstOrDefault();
                        }
                    }
                    if (indiceColonna == (posizioneNuovaColonna + 1))
                    {
                        if (indiceRiga == 0)
                        {
                            cell.CellValue = new CellValue(Etichette.IDMAGAZZ);
                            cell.DataType = new EnumValue<CellValues>(CellValues.String);
                        }
                        else
                        {
                            cell.CellValue = new CellValue(idmagazz);
                            cell.DataType = new EnumValue<CellValues>(CellValues.String);
                        }
                    }
                    if (indiceColonna > (posizioneNuovaColonna + 1))
                    {
                        cell.CellValue = new CellValue(valorePrecedente);
                        cell.DataType = new EnumValue<CellValues>(CellValues.String);
                    }
                    indiceColonna++;
                    valorePrecedente = valoreAttuale;
                }

                indiceRiga++;

            }

            indiceUltimaColonna++;
            AggiungiColonna(worksheetPart, indiceUltimaColonna);

            indiceRiga = 0;
            foreach (Row r in sheetData.Elements<Row>())
            {
                indiceColonna = 0;
                string valorePrecedente = string.Empty;
                foreach (Cell cell in r.Elements<Cell>())
                {
                    string valoreAttuale = EstraiValoreCella(cell, sharedStringTable, cellFormats, numberingFormats);

                    if (indiceColonna == (posizioneNuovaColonna + 1))
                    {
                        if (indiceRiga == 0)
                        {
                            cell.CellValue = new CellValue(Etichette.CodiceCiclo);
                            cell.DataType = new EnumValue<CellValues>(CellValues.String);
                        }
                        else
                        {
                            cell.CellValue = new CellValue(string.Empty);
                            cell.DataType = new EnumValue<CellValues>(CellValues.String);
                        }
                    }
                    if (indiceColonna > (posizioneNuovaColonna + 1))
                    {
                        cell.CellValue = new CellValue(valorePrecedente);
                        cell.DataType = new EnumValue<CellValues>(CellValues.String);
                    }
                    indiceColonna++;
                    valorePrecedente = valoreAttuale;
                }

                indiceRiga++;
            }

            indiceUltimaColonna++;
            AggiungiColonna(worksheetPart, indiceUltimaColonna);

            indiceRiga = 0;
            foreach (Row r in sheetData.Elements<Row>())
            {
                indiceColonna = 0;
                string valorePrecedente = string.Empty;
                foreach (Cell cell in r.Elements<Cell>())
                {
                    string valoreAttuale = EstraiValoreCella(cell, sharedStringTable, cellFormats, numberingFormats);

                    if (indiceColonna == (posizioneNuovaColonna + 1))
                    {
                        if (indiceRiga == 0)
                        {
                            cell.CellValue = new CellValue(Etichette.PezziOrari);
                            cell.DataType = new EnumValue<CellValues>(CellValues.String);
                        }
                        else
                        {
                            cell.CellValue = new CellValue(string.Empty);
                            cell.DataType = new EnumValue<CellValues>(CellValues.String);
                        }
                    }
                    if (indiceColonna > (posizioneNuovaColonna + 1))
                    {
                        cell.CellValue = new CellValue(valorePrecedente);
                        cell.DataType = new EnumValue<CellValues>(CellValues.String);
                    }
                    indiceColonna++;
                    valorePrecedente = valoreAttuale;
                }

                indiceRiga++;
            }

            indiceUltimaColonna++;
            AggiungiColonna(worksheetPart, indiceUltimaColonna);

            indiceRiga = 0;
            foreach (Row r in sheetData.Elements<Row>())
            {
                indiceColonna = 0;
                string valorePrecedente = string.Empty;
                foreach (Cell cell in r.Elements<Cell>())
                {
                    string valoreAttuale = EstraiValoreCella(cell, sharedStringTable, cellFormats, numberingFormats);

                    if (indiceColonna == (posizioneNuovaColonna + 1))
                    {
                        if (indiceRiga == 0)
                        {
                            cell.CellValue = new CellValue(Etichette.Collegamento);
                            cell.DataType = new EnumValue<CellValues>(CellValues.String);
                        }
                        else
                        {
                            cell.CellValue = new CellValue(string.Empty);
                            cell.DataType = new EnumValue<CellValues>(CellValues.String);
                        }
                    }
                    if (indiceColonna > (posizioneNuovaColonna + 1))
                    {
                        cell.CellValue = new CellValue(valorePrecedente);
                        cell.DataType = new EnumValue<CellValues>(CellValues.String);
                    }
                    indiceColonna++;
                    valorePrecedente = valoreAttuale;
                }

                indiceRiga++;
            }


            indiceUltimaColonna++;
            AggiungiColonna(worksheetPart, indiceUltimaColonna);

            indiceRiga = 0;
            foreach (Row r in sheetData.Elements<Row>())
            {
                indiceColonna = 0;
                string valorePrecedente = string.Empty;
                string idmagazz = string.Empty;
                string bc = string.Empty;
                foreach (Cell cell in r.Elements<Cell>())
                {
                    string valoreAttuale = EstraiValoreCella(cell, sharedStringTable, cellFormats, numberingFormats);
                    if (indiceColonna == (posizioneNuovaColonna))
                    {
                        if (indiceRiga > 0)
                        {
                            idmagazz = ds.MAGAZZ.Where(x => x.DESMAGAZZ == valoreAttuale).Select(XmlCellProperties => XmlCellProperties.IDMAGAZZ).FirstOrDefault();
                            bc = ds.BC_ANAGRAFICA.Where(x => x.IDMAGAZZ == idmagazz).Select(x => x.BC).FirstOrDefault();
                        }
                    }
                    if (indiceColonna == (posizioneNuovaColonna + 1))
                    {
                        if (indiceRiga == 0)
                        {
                            cell.CellValue = new CellValue(Etichette.Anagrafica);
                            cell.DataType = new EnumValue<CellValues>(CellValues.String);
                        }
                        else
                        {
                            cell.CellValue = new CellValue(string.IsNullOrEmpty(bc) ? string.Empty : bc);
                            cell.DataType = new EnumValue<CellValues>(CellValues.String);
                        }
                    }
                    if (indiceColonna > (posizioneNuovaColonna + 1))
                    {
                        cell.CellValue = new CellValue(valorePrecedente);
                        cell.DataType = new EnumValue<CellValues>(CellValues.String);
                    }
                    indiceColonna++;
                    valorePrecedente = valoreAttuale;
                }

                indiceRiga++;

            }

            worksheetPart.Worksheet.Save();
            wbPart.Workbook.Save();
            document.Save();
            document.Close();
            return true;
        }

        private void AggiungiColonna(WorksheetPart worksheetPart, int indiceColonnaDaInserire)
        {
            Columns colonne = worksheetPart.Worksheet.GetFirstChild<Columns>();
            SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
            int numeroColonne = colonne.Count();
            Column c = new Column();
            UInt32Value u = new UInt32Value((uint)(numeroColonne + 1));
            c.Min = u;
            c.Max = u;
            c.Width = 25;
            c.CustomWidth = true;

            colonne.Append(c);

            bool primaRiga = true;
            int indiceRiga = 1;
            foreach (Row r in sheetData.Elements<Row>())
            {
                string riferimentoColonna = GetExcelColumnName(indiceColonnaDaInserire);
                string riferimento = riferimentoColonna + indiceRiga.ToString();
                r.Append(ConstructCell(string.Empty, CellValues.String, riferimento, primaRiga ? (uint)1 : (uint)0));
                primaRiga = false;
                indiceRiga++;
            }
        }

        private int GetRowReference(Cell c)
        {
            string refer = c.CellReference.Value;
            return Convert.ToInt32(Regex.Replace(refer, @"[^\d]*", ""));
        }
        private Cell InsertCell(uint rowIndex, uint columnIndex, Worksheet worksheet)
        {
            Row row = null;
            var sheetData = worksheet.GetFirstChild<SheetData>();

            // Check if the worksheet contains a row with the specified row index.
            row = sheetData.Elements<Row>().FirstOrDefault(r => r.RowIndex == rowIndex);
            if (row == null)
            {
                row = new Row() { RowIndex = rowIndex };
                sheetData.Append(row);
            }

            // Convert column index to column name for cell reference.
            var columnName = GetExcelColumnName((int)columnIndex);
            var cellReference = columnName + rowIndex;      // e.g. A1

            // Check if the row contains a cell with the specified column name.
            var cell = row.Elements<Cell>()
                       .FirstOrDefault(c => c.CellReference.Value == cellReference);
            if (cell == null)
            {
                cell = new Cell() { CellReference = cellReference };
                if (row.ChildElements.Count < columnIndex)
                    row.AppendChild(cell);
                else
                    row.InsertAt(cell, (int)columnIndex);
            }

            return cell;
        }
        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }
        private string estraiStringaLughezzaFissa(string stringa, int lunghezza)
        {
            if (stringa.Length == lunghezza) return stringa;

            if (stringa.Length > lunghezza) return stringa.Substring(stringa.Length - lunghezza);

            return stringa.PadLeft(lunghezza, '0');
        }

        public bool LeggiFileExcelOperaGucci(Stream stream, SpedizioniDS ds, out string messaggioErrore)

        {
            messaggioErrore = string.Empty;
            SpreadsheetDocument document = SpreadsheetDocument.Open(stream, true);
            SharedStringTable sharedStringTable = document.WorkbookPart.SharedStringTablePart.SharedStringTable;

            WorkbookPart wbPart = document.WorkbookPart;

            Sheet foglio = EstraiSheetPerNome(wbPart, "Foglio1");
            WorksheetPart worksheetPart = (WorksheetPart)wbPart.GetPartById(foglio.Id);
            SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

            CellFormats cellFormats = wbPart.WorkbookStylesPart.Stylesheet.CellFormats;
            NumberingFormats numberingFormats = wbPart.WorkbookStylesPart.Stylesheet.NumberingFormats;

            int rowCount = sheetData.Elements<Row>().Count();

            int scartaRighe = 1;
            int indiceRighe = 0;

            foreach (Row r in sheetData.Elements<Row>())
            {
                string prefisso = string.Empty;
                string parte = string.Empty;
                string colore = string.Empty;
                string fase = string.Empty;
                if (indiceRighe < scartaRighe)
                {
                    indiceRighe++;
                    continue;
                }
                bool esito = true;

                if (r.FirstChild.InnerText == string.Empty) continue;

                SpedizioniDS.SPOPERARow operaRow = ds.SPOPERA.NewSPOPERARow();
                operaRow.SEQUENZA = 1;
                operaRow.VALIDATA = false;

                string elemento = string.Empty;
                foreach (Cell cell in r.Elements<Cell>())
                {
                    string cella = EstraiValoreCella(cell, sharedStringTable, cellFormats, numberingFormats);
                    cella = cella.Trim();
                    string colonna = GetColumnReference(cell);
                    switch (colonna)
                    {
                        case "A":
                            if (string.IsNullOrEmpty(cella))
                                continue;
                            prefisso = estraiStringaLughezzaFissa(cella, 3);
                            //esito = EstraiValoreCellaDecimal(cella, "IDPRENOTAZIONE", cPiombo, out messaggioErrore);
                            break;
                        case "B":
                            {
                                parte = estraiStringaLughezzaFissa(cella, 5);
                            }
                            break;
                        case "C":
                            {
                                colore = estraiStringaLughezzaFissa(cella, 4);
                            }
                            break;
                        case "D":
                            {
                                operaRow.RIFERIMENTO_TESTATA = EstraiStringaDaCella(cella, ds.SPOPERA.Columns[3].MaxLength);
                            }
                            break;
                        case "E":
                            {
                                fase = estraiStringaLughezzaFissa(cella, 4);
                                string modello = string.Format("{0}-{1}-{2}-{3}", prefisso, parte, colore, fase);
                                operaRow.MODELLO_CODICE = modello;
                            }
                            break;
                        case "F":
                            {
                                if (!string.IsNullOrEmpty(cella))
                                    esito = EstraiValoreCellaDecimal(cella, "QTANOSPE", operaRow, out messaggioErrore);
                                break;
                            }
                        case "G":
                        case "H":
                        case "I":
                        case "J":
                        case "K":
                        case "L":
                        case "M":
                        case "N":
                        case "O":
                        case "P":
                        case "Q":
                            break;
                    }
                    if (!esito)
                        return false;
                }
                ds.SPOPERA.AddSPOPERARow(operaRow);
            }

            return true;
        }
    }
}
