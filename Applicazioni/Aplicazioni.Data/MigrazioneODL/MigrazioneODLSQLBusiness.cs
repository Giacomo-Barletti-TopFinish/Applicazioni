using Applicazioni.Data.Core;
using Applicazioni.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data.MigrazioneODL
{
    public class MigrazioneODLSQLBusiness : BusinessBaseSQL
    {
        [DataContext]
        public void GetDistinteBCTestata(MigrazioneODLDS ds, string codiceTestata)
        {
            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetDistinteBCTestata(ds, codiceTestata);
        }

        [DataContext]
        public void GetDistinteBCDettaglio(MigrazioneODLDS ds, string codiceTestata)
        {
            MigrazioneODLAdapter a = new MigrazioneODLAdapter(DbConnection, DbTransaction);
            a.GetDistinteBCDettaglio(ds, codiceTestata);
        }

    }
}
