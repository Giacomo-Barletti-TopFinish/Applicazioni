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
using System.Threading.Tasks;

namespace Applicazioni.Helpers
{
    public class ExcelHelper
    {

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
    }
}
