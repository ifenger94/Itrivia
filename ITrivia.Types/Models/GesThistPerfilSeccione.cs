using ITrivia.Types.Interfaces;
using System;
using System.Collections.Generic;

namespace ITrivia.Types.Models
{
    public partial class GesThistPerfilSeccione : IBaseClass
    {
        public int Id { get; set; }
        public bool Baja { get; set; }
        public DateTime AltaFecha { get; set; }
        public DateTime? ModiFecha { get; set; }
        public string Usuario { get; set; } = null!;
        public int IdPerfil { get; set; }
        public int IdSeccion { get; set; }

        public virtual GesTseccione IdSeccionNavigation { get; set; } = null!;
    }
}
