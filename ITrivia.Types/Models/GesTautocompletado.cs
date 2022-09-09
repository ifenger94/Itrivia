using ITrivia.Types.Interfaces;
using System;
using System.Collections.Generic;

namespace ITrivia.Types.Models
{
    public partial class GesTautocompletado : IBaseClass
    {
        public GesTautocompletado()
        {
            GesTetapas = new HashSet<GesTetapa>();
        }

        public int Id { get; set; }
        public bool Baja { get; set; }
        public DateTime AltaFecha { get; set; }
        public DateTime? ModiFecha { get; set; }
        public string Usuario { get; set; } = null!;
        public string Enunciado { get; set; } = null!;
        public string Respuesta { get; set; } = null!;

        public virtual ICollection<GesTetapa> GesTetapas { get; set; }
    }
}
