using ITrivia.Types.Interfaces;
using System;
using System.Collections.Generic;

namespace ITrivia.Types.Models
{
    public partial class GesTmultiplechoice : IBaseClass
    {
        public GesTmultiplechoice()
        {
            GesTetapas = new HashSet<GesTetapa>();
        }

        public int Id { get; set; }
        public bool Baja { get; set; }
        public DateTime AltaFecha { get; set; }
        public DateTime? ModiFecha { get; set; }
        public string Usuario { get; set; } = null!;
        public string Enunciado { get; set; } = null!;
        public string OpcionCorrecta { get; set; } = null!;
        public string Opcion1 { get; set; } = null!;
        public string Opcion2 { get; set; } = null!;

        public virtual ICollection<GesTetapa> GesTetapas { get; set; }
    }
}
