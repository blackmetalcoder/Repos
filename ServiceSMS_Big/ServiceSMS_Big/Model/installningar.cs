using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSMS_Big.Model
{
    class installningar
    {
        public string KorTid { get; set; }
        public string Meddelande { get; set; }
        public string MeddelandeOP { get; set; }
        public string User { get; set; }
        public string Pwd { get; set; }
        public bool ExtededLogging { get; set; }
        public int Dagar { get; set; }
        public int DagarOP { get; set; }
        public decimal Operationskod { get; set; }
        public List<BokningsId> bokningsId { get; set; }
        public List<BokningsIdOP> bokningsIdOP { get; set; }
        public List<KlinikKod> klinikKod { get; set; }
    }
    public class BokningsId
    {
        public decimal value { get; set; }
    }
    public class BokningsIdOP
    {
        public decimal value { get; set; }
    }
    public class KlinikKod
    {
        public string value { get; set; }
    }
}
