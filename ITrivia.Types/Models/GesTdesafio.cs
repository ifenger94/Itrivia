using ITrivia.Types.Interfaces;
using System;
using System.Collections.Generic;

namespace ITrivia.Types.Models
{
    public partial class GesTdesafio : IBaseClass
    {
        public GesTdesafio()
        {
            GesTetapas = new HashSet<GesTetapa>();
            GesThistPerfilDesafios = new HashSet<GesThistPerfilDesafio>();
        }

        public int Id { get; set; }
        public bool Baja { get; set; }
        public DateTime AltaFecha { get; set; }
        public DateTime? ModiFecha { get; set; }
        public string Usuario { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int IdSeccion { get; set; }
        public int Experiencia { get; set; }
        public int CantEtapas { get; set; }
        public bool Activated { get; set; }

        public virtual GesTseccione IdSeccionNavigation { get; set; } = null!;
        public virtual ICollection<GesTetapa> GesTetapas { get; set; }
        public virtual ICollection<GesThistPerfilDesafio> GesThistPerfilDesafios { get; set; }
    }
}
