using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Interfaces
{
    public interface IBaseClass
    {
        int Id { get; set; }
        bool Baja { get; set; }
        string Usuario { get; set; }
        System.DateTime AltaFecha { get; set; }
        Nullable<System.DateTime> ModiFecha { get; set; }
    }
}
