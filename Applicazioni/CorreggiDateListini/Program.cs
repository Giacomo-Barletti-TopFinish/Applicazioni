using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applicazioni.Data;
using Applicazioni.Data.CorreggiDateListini;
using Applicazioni.Entities;

namespace CorreggiDateListini
{
    class Program
    {
        static void Main(string[] args)
        {
            CorreggiDateListiniDS ds = new CorreggiDateListiniDS();
            using (CorreggiDateListiniBusiness bCorreggi = new CorreggiDateListiniBusiness())
            {
                bCorreggi.FillUSR_LIS_ACQ_COR(ds);
            }

            CorreggiListini(ds, "MP");
            CorreggiListini(ds, "TF");


            Console.WriteLine("***** UPDATE IN CORSO ****");
            using (CorreggiDateListiniBusiness bCorreggi = new CorreggiDateListiniBusiness())
            {
                bCorreggi.UpdateTable(ds.USR_LIS_ACQ_COR.TableName, ds);
            }
        }

        private static void CorreggiListini(CorreggiDateListiniDS ds, string Azienda)
        {
            List<string> articoliMP = ds.USR_LIS_ACQ_COR.Where(x => !x.IsIDMAGAZZNull() && x.AZIENDA == Azienda).Select(x => x.IDMAGAZZ).Distinct().ToList();
            int indice = 1;
            foreach (string idmagazz in articoliMP)
            {
                Console.WriteLine(string.Format("{2} {0} di {1}", indice, articoliMP.Count, Azienda));
                indice++;

                List<string> clifo = ds.USR_LIS_ACQ_COR.Where(x => !x.IsCODICECLIFONull() && !x.IsIDMAGAZZNull() && x.IDMAGAZZ == idmagazz && x.AZIENDA == Azienda).Select(x => x.CODICECLIFO).Distinct().ToList();

                List<CorreggiDateListiniDS.USR_LIS_ACQ_CORRow> listini = ds.USR_LIS_ACQ_COR.Where(x => x.IsCODICECLIFONull() && x.AZIENDA == Azienda && !x.IsIDMAGAZZNull() && x.IDMAGAZZ == idmagazz).OrderByDescending(x => x.VALIDITA).ToList();

                if (listini.Count > 1)
                {
                    DateTime dataInizioValidita = new DateTime(2000, 1, 1);
                    foreach (CorreggiDateListiniDS.USR_LIS_ACQ_CORRow listino in listini)
                    {
                        if (!(dataInizioValidita.Year == 2000 && dataInizioValidita.Month == 1 && dataInizioValidita.Day == 1))
                        {
                            listino.FINEVALIDITA = dataInizioValidita;
                        }
                        dataInizioValidita = listino.VALIDITA;
                    }
                }

                foreach (string cl in clifo)
                {
                    listini = ds.USR_LIS_ACQ_COR.Where(x => !x.IsCODICECLIFONull() && x.CODICECLIFO == cl && x.AZIENDA == Azienda && !x.IsIDMAGAZZNull() && x.IDMAGAZZ == idmagazz).OrderByDescending(x => x.VALIDITA).ToList();
                    if (listini.Count <= 1) continue;

                    DateTime dataInizioValidita = new DateTime(2000, 1, 1);
                    foreach (CorreggiDateListiniDS.USR_LIS_ACQ_CORRow listino in listini)
                    {
                        if (!(dataInizioValidita.Year == 2000 && dataInizioValidita.Month == 1 && dataInizioValidita.Day == 1))
                        {
                            listino.FINEVALIDITA = dataInizioValidita;
                        }
                        dataInizioValidita = listino.VALIDITA;
                    }

                }

            }
        }
    }
}
