using System;
using System.Collections.Generic;

namespace CoreSoccerAPI.Models
{
    public partial class KalenderUser
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Pwd { get; set; }
        public string KundMamut { get; set; }
        public int? Demo { get; set; }
        public DateTime? Startdatum { get; set; }
        public DateTime? Slutdatum { get; set; }
        public int? FtgIdMamut { get; set; }
        public string Doman { get; set; }
        public string Discover { get; set; }
    }
}
