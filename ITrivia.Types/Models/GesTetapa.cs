using ITrivia.Types.Interfaces;
using System;
using System.Collections.Generic;

namespace ITrivia.Types.Models
{
    public partial class GesTetapa : IBaseClass
    {
        public int Id { get; set; }
        public bool Baja { get; set; }
        public DateTime AltaFecha { get; set; }
        public DateTime? ModiFecha { get; set; }
        public string Usuario { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int IdDesafio { get; set; }
        public int IdTipoJuego { get; set; }
        public int? IdAutocompletado { get; set; }
        public int? IdMchoice { get; set; }
        public int? IdSpares { get; set; }

        public virtual GesTautocompletado? IdAutocompletadoNavigation { get; set; }
        public virtual GesTdesafio IdDesafioNavigation { get; set; } = null!;
        public virtual GesTmultiplechoice? IdMchoiceNavigation { get; set; }
        public virtual GesTselecPare? IdSparesNavigation { get; set; }
        public virtual GesPtipoJuego IdTipoJuegoNavigation { get; set; } = null!;
    }
}
