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
    public class FacadePairSelection : IFacadePairSelection
    {
        private IPairSelectionDomain _pairSelectionDomain { set; get; }
        private IStepDomain stepDomain { set; get; }
        private IChallengeDomain challengeDomain { set; get; }
        private ISectionDomain sectionDomain { set; get; }

        public FacadePairSelection(IPairSelectionDomain pairSelectionDomain, IStepDomain stepDomain, IChallengeDomain challengeDomain, ISectionDomain sectionDomain)
        {
            this._pairSelectionDomain = pairSelectionDomain;
            this.stepDomain = stepDomain;
            this.challengeDomain = challengeDomain;
            this.sectionDomain = sectionDomain;
        }

        public void Save(GesTselecPare sel, GesTetapa step)
        {
            _pairSelectionDomain.Create(sel);
            step.IdSpares = sel.Id;
            stepDomain.Create(step);
            challengeDomain.VerifyStateChallenge(step.IdDesafio);
            var challenge = challengeDomain.Get(step.IdDesafio);
            sectionDomain.VerifyStateSection(challenge.IdSeccion);
        }

        public void Update(GesTselecPare selp, GesTetapa step)
        {
            _pairSelectionDomain.Update(selp);
            step.IdSpares = selp.Id;
            stepDomain.Update(step);
        }
    }
}
