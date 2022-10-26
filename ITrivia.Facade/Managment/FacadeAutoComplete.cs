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
    public class FacadeAutoComplete : IFacadeAutoComplete
    {
        private IAutocompleteDomain autocompleteDomain { set; get; }
        private IStepDomain stepDomain { set; get; }
        private IChallengeDomain challengeDomain { set; get; }
        private ISectionDomain sectionDomain { set; get; }


        public FacadeAutoComplete(IAutocompleteDomain autocompleteDomain, IStepDomain stepDomain, IChallengeDomain challengeDomain, ISectionDomain sectionDomain)
        {
            this.autocompleteDomain = autocompleteDomain;
            this.stepDomain = stepDomain;
            this.challengeDomain = challengeDomain;
            this.sectionDomain = sectionDomain;
        }

        public void Save(GesTautocompletado aut, GesTetapa step)
        {
            autocompleteDomain.Create(aut);
            step.IdAutocompletado = aut.Id;
            stepDomain.Create(step);
            challengeDomain.VerifyStateChallenge(step.IdDesafio);
            var challenge = challengeDomain.Get(step.IdDesafio);
            sectionDomain.VerifyStateSection(challenge.IdSeccion);
        }

        public void Update(GesTautocompletado aut, GesTetapa step)
        {
            autocompleteDomain.Update(aut);
            step.IdAutocompletado = aut.Id;
            stepDomain.Update(step);
        }

    }
}
