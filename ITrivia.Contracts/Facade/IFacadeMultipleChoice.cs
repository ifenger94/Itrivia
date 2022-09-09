using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITrivia.Types.Models;

namespace ITrivia.Contracts.Facade
{
    public interface IFacadeMultipleChoice
    {
        void Save(GesTmultiplechoice aut, GesTetapa step);

        void Update(GesTmultiplechoice aut, GesTetapa step);
    }
}
