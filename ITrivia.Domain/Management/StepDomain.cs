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
    public class StepDomain : DomainBase<IStepRepository, GesTetapa>, IStepDomain
    {
        public StepDomain(IStepRepository stepRepository) : base(stepRepository)
        {
        }

        public IEnumerable<GesTetapa> GetStepsByChallengeId(int id)
        {
            return GetAllBy(e => e.IdDesafio == id && e.Baja == false);
        }
    }
}
