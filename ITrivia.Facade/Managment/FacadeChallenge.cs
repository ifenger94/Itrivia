using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Facade.Managment
{
    public class FacadeChallenge : IFacadeChallenge
    {
        private IChallengeDomain challengeDomain { set; get; }
        private ISectionDomain sectionDomain { set; get; }
        private IAutocompleteDomain autocompleteDomain { set; get; }
        private IPairSelectionDomain pairSelectionDomain { set; get; }
        private IMultipleChoiceDomain multipleChoiceDomain { set; get; }
        private IStepDomain stepDomain { set; get; }

        public FacadeChallenge(IChallengeDomain challengeDomain, ISectionDomain sectionDomain, IAutocompleteDomain autocompleteDomain, IPairSelectionDomain pairSelectionDomain, IMultipleChoiceDomain multipleChoiceDomain, IStepDomain stepDomain)
        {
            this.challengeDomain = challengeDomain;
            this.sectionDomain = sectionDomain;
            this.autocompleteDomain = autocompleteDomain;
            this.pairSelectionDomain = pairSelectionDomain;
            this.multipleChoiceDomain = multipleChoiceDomain;
            this.stepDomain = stepDomain;
        }

        public void ExecuteDelete(int id)
        {
            var challenge = this.challengeDomain.Get(id);

            foreach (var step in challenge.GesTetapas)
            {
                this.stepDomain.Remove(step.Id);

                if (step.IdAutocompletado.HasValue) this.autocompleteDomain.Remove(step.IdAutocompletado.Value);
                if (step.IdMchoice.HasValue) this.multipleChoiceDomain.Remove(step.IdMchoice.Value);
                if (step.IdSpares.HasValue) this.pairSelectionDomain.Remove(step.IdSpares.Value);

            }

            var section = sectionDomain.Get(challenge.IdSeccion);
            this.challengeDomain.Remove(challenge.Id);
            section.Activated = false;
            sectionDomain.Update(section);
        }
    }
}
