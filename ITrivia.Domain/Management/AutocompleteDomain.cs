using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Repository;
using ITrivia.Domain.Base;
using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Domain.Management
{
    public class AutocompleteDomain : DomainBase<IAutocompleteRepository, GesTautocompletado>, IAutocompleteDomain
    {
        public AutocompleteDomain(IAutocompleteRepository autocompleRepository) : base(autocompleRepository)
        {
        }

        public string CorrectAnswer(int id)
        {
            GesTautocompletado entity = this.Get(id);
            return entity != null ? entity.Respuesta : string.Empty;
        }
    }
}
