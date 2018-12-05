using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnaucuraLogg.Model
{
    class Logging
    {
        public int Id { get; set; }
        public DateTime TidSkickat { get; set; }
        public string Djur { get; set; }
        public string Tel { get; set; }
        public string Agare { get; set; }
        public string InfoText { get; set; }

    }
}
