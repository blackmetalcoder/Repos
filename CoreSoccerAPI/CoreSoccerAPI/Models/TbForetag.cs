using System;
using System.Collections.Generic;

namespace CoreSoccerAPI.Models
{
    public partial class TbForetag
    {
        public int Id { get; set; }
        public string Foretag { get; set; }
        public string Losenord { get; set; }
        public string Adress { get; set; }
        public string Postnr { get; set; }
        public string Ort { get; set; }
        public string Epost { get; set; }
        public string Telefon { get; set; }
    }
}
