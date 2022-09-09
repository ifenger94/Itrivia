using ITrivia.Types.Interfaces;
using System;
using System.Collections.Generic;

namespace ITrivia.Types.Models
{
    public partial class GesPtipoJuego : IBaseClass
    {
        public GesPtipoJuego()
        {
            GesTetapas = new HashSet<GesTetapa>();
        }

        public int Id { get; set; }
        public bool Baja { get; set; }
        public DateTime AltaFecha { get; set; }
        public DateTime? ModiFecha { get; set; }
        public string Usuario { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Codigo { get; set; } = null!;

        public virtual ICollection<GesTetapa> GesTetapas { get; set; }
    }
}
