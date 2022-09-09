using ITrivia.Types.Interfaces;
using System;
using System.Collections.Generic;

namespace ITrivia.Types.Models
{
    public partial class GesTperfile : IBaseClass
    {
        public GesTperfile()
        {
            GesThistPerfilDesafios = new HashSet<GesThistPerfilDesafio>();
        }

        public int Id { get; set; }
        public bool Baja { get; set; }
        public DateTime AltaFecha { get; set; }
        public DateTime? ModiFecha { get; set; }
        public string Usuario { get; set; } = null!;
        public int Exp { get; set; }

        public virtual SegTusuario? SegTusuario { get; set; }
        public virtual ICollection<GesThistPerfilDesafio> GesThistPerfilDesafios { get; set; }
    }
}
