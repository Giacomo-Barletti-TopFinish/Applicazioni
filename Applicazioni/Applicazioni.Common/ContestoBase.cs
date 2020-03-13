using Applicazioni.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Common
{
    public class ContestoBase
    {
        public bool Connesso;
        public UtenteDominio Utente;

        public static ContestoBase CreaContesto()
        {
            ContestoBase contesto = new ContestoBase();

            contesto.Connesso = true;
            contesto.Utente = new UtenteDominio();

            return contesto;
        }

    }

}
