using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Contracts.Facade
{
    public interface IFacadePairSelection
    {
        void Save(GesTselecPare pair, GesTetapa step);

        void Update(GesTselecPare aut, GesTetapa step);
    }
}
