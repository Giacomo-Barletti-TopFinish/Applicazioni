using Applicazioni.Data.Core;
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
        public void FillBOLLE_VENDITATESTATA(Entities.MigrazioneODLDS ds, DateTime Dal, DateTime Al)
        {
            //EDIFornitoriAdapter a = new EDIFornitoriAdapter(DbConnection, DbTransaction);
            //a.FillBOLLE_VENDITATESTATASQL(ds, Dal, Al);
        }

      
    }
}
