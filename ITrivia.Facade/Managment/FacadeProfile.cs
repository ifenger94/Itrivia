using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Facade;
using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Facade.Managment
{
    public class FacadeProfile : IFacadeProfile
    {
        private IProfileDomain profileDomain { set; get; }
        private IChallengeDomain challengeDomain { set; get; }
        private IHistoryPDDomain historyPDDomain { set; get; }
        public FacadeProfile(IProfileDomain profileDomain, IChallengeDomain challengeDomain, IHistoryPDDomain historyPDDomain)
        {
            this.challengeDomain = challengeDomain;
            this.profileDomain = profileDomain;
            this.historyPDDomain = historyPDDomain;
        }

        public void AddExperenceAndHistory(int profileId, int challengeId)
        {

            GesTdesafio challenge = challengeDomain.Get(challengeId);

            if (challenge == null)
                throw new ArgumentNullException();

            if (historyPDDomain.GetAllBy(e => e.IdDesafio == challengeId && e.IdPerfil == profileId && e.Baja == false).FirstOrDefault() != null)
                throw new InvalidOperationException();

            historyPDDomain.Create(new GesThistPerfilDesafio()
            {
                IdDesafio = challengeId,
                IdPerfil = profileId
            });

            profileDomain.AddExperience(profileId, Convert.ToInt32(challenge.Experiencia));
        }

    }
}
