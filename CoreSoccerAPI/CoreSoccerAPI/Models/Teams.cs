using System;
using System.Collections.Generic;

namespace CoreSoccerAPI.Models
{
    public partial class Teams
    {
        public int Id { get; set; }
        public int? TeamId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Stadium { get; set; }
        public string HomePageUrl { get; set; }
        public string Wikilink { get; set; }
    }
}
