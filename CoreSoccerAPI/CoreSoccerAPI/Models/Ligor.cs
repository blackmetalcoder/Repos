using System;
using System.Collections.Generic;

namespace CoreSoccerAPI.Models
{
    public partial class Ligor
    {
        public int Id1 { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Livescore { get; set; }
    }
}
