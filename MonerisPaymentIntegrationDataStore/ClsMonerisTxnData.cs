using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonerisPaymentIntegrationDataStore
{
    public static class ClsMonerisTxnData
    {
        public static long Save(tblMonerisTxnData obj)
        {
            using (var db = new DustControl_Entities())
            {
                db.tblMonerisTxnDatas.Add(obj);
                db.SaveChanges();

                return obj.ID;
            }
        }
    }
}
