using System;
using System.Collections.Generic;

namespace CoreSoccerAPI.Models
{
    public partial class TbInfo
    {
        public int Id { get; set; }
        public int? ForetagsId { get; set; }
        public string Info { get; set; }
        public DateTime? Datum { get; set; }
        public string Tag { get; set; }
        public int? GruppId { get; set; }
    }
}
