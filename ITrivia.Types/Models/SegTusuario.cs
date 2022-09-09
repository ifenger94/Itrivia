using ITrivia.Types.Interfaces;
using System;
using System.Collections.Generic;

namespace ITrivia.Types.Models
{
    public partial class SegTusuario : IBaseClass
    {
        public int Id { get; set; }
        public bool Baja { get; set; }
        public DateTime AltaFecha { get; set; }
        public DateTime? ModiFecha { get; set; }
        public string Usuario { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int IdRol { get; set; }
        public int? IdPerfil { get; set; }
        public int? IdImagen { get; set; }

        public virtual ParPimagene? IdImagenNavigation { get; set; }
        public virtual GesTperfile? IdPerfilNavigation { get; set; }
        public virtual SegProle IdRolNavigation { get; set; } = null!;
    }
}
