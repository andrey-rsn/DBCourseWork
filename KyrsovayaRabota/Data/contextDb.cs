using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyrsovayaRabota.Data
{
    internal class contextDb:KyrsovayaRabotaDBEntities1
    {
        public static contextDb _context;
        
         public static contextDb getContext()
         {
             if (_context == null)
                 _context = new contextDb();
             return _context;
         }
        public contextDb():base()
        {

        }
    }
}
