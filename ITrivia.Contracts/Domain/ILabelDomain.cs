using ITrivia.Contracts.Repository;
using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Contracts.Domain
{
    public interface ILabelDomain : IDomainBase<ParPetiqueta>
    {
        IDictionary<string, string> GetLabels(string languageCode);
    }
}
