using ITrivia.Types.Interfaces;
using System;
using System.Collections.Generic;

namespace ITrivia.Types.Models
{
    public partial class GesTselecPare : IBaseClass
    {
        public GesTselecPare()
        {
            GesTetapas = new HashSet<GesTetapa>();
        }

        public int Id { get; set; }
        public bool Baja { get; set; }
        public DateTime AltaFecha { get; set; }
        public DateTime? ModiFecha { get; set; }
        public string Usuario { get; set; } = null!;
        public string Opcion1 { get; set; } = null!;
        public string Respuesta1 { get; set; } = null!;
        public string Opcion2 { get; set; } = null!;
        public string Respuesta2 { get; set; } = null!;
        public string Opcion3 { get; set; } = null!;
        public string Respuesta3 { get; set; } = null!;
        public string Opcion4 { get; set; } = null!;
        public string Respuesta4 { get; set; } = null!;

        public virtual ICollection<GesTetapa> GesTetapas { get; set; }
    }
}
