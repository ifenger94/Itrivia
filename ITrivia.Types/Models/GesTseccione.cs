using ITrivia.Types.Interfaces;
using System;
using System.Collections.Generic;

namespace ITrivia.Types.Models
{
    public partial class GesTseccione : IBaseClass
    {
        public GesTseccione()
        {
            GesTdesafios = new HashSet<GesTdesafio>();
            GesThistPerfilSecciones = new HashSet<GesThistPerfilSeccione>();
        }

        public int Id { get; set; }
        public bool Baja { get; set; }
        public DateTime AltaFecha { get; set; }
        public DateTime? ModiFecha { get; set; }
        public string Nombre { get; set; } = null!;
        public string Usuario { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int IdCategoria { get; set; }
        public string? UrlImagen { get; set; }
        public int CantDesafios { get; set; }
        public bool Activated { get; set; }

        public virtual GesTcategoria IdCategoriaNavigation { get; set; } = null!;
        public virtual ICollection<GesTdesafio> GesTdesafios { get; set; }
        public virtual ICollection<GesThistPerfilSeccione> GesThistPerfilSecciones { get; set; }
    }
}
