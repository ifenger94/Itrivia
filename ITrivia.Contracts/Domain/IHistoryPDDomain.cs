using ITrivia.Types.Dtos.HistoryPDDto;
using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Contracts.Domain
{
    public interface IHistoryPDDomain : IDomainBase<GesThistPerfilDesafio>
    {
        IEnumerable<GesThistPerfilDesafio> GetHpdByProfileId(int id);
        IEnumerable<ExperienceHistoryPDDto> GetExperenceAndHistory(int profileId,string language);
    }
}
