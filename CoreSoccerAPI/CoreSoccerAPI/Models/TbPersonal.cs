using System;
using System.Collections.Generic;

namespace CoreSoccerAPI.Models
{
    public partial class TbPersonal
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Titel { get; set; }
        public string Bild { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Info { get; set; }
    }
}
