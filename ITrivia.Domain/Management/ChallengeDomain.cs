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
    public class ChallengeDomain : DomainBase<IChallengeRepository, GesTdesafio>, IChallengeDomain
    {
        public ChallengeDomain(IChallengeRepository challengeRepository) : base(challengeRepository)
        {
        }

        public IEnumerable<GesTdesafio> GetChallengeBySectionId(int sectionId)
        {
            return this.GetAllBy(e => e.Baja == false && e.IdSeccion == sectionId);
        }

        public void VerifyStateChallenge(int id)
        {
            GesTdesafio currentChallenge = Get(id);
            int totalCount = currentChallenge.GesTetapas.Count();

            if (currentChallenge.Activated)
            {
                if (totalCount != currentChallenge.CantEtapas)
                {
                    currentChallenge.Activated = false;
                    Update(currentChallenge);
                }
            }
            else
            {
                if (totalCount == currentChallenge.CantEtapas)
                {
                    currentChallenge.Activated = true;
                    Update(currentChallenge);
                }
            }
        }
    }
}
