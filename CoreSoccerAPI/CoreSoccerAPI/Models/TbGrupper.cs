using System;
using System.Collections.Generic;

namespace CoreSoccerAPI.Models
{
    public partial class TbGrupper
    {
        public int Id { get; set; }
        public int? ForetagsId { get; set; }
        public string Grupp { get; set; }
    }
}
