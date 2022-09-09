using ITrivia.Types.Interfaces;
using System;
using System.Collections.Generic;

namespace ITrivia.Types.Models
{
    public partial class ParPimagene : IBaseClass
    {
        public ParPimagene()
        {
            SegTusuarios = new HashSet<SegTusuario>();
        }

        public int Id { get; set; }
        public bool Baja { get; set; }
        public DateTime AltaFecha { get; set; }
        public DateTime? ModiFecha { get; set; }
        public string Usuario { get; set; } = null!;
        public string? Codigo { get; set; }
        public string? UrlImagen { get; set; }

        public virtual ICollection<SegTusuario> SegTusuarios { get; set; }
    }
}
