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
    public class FacadeMultipleChoice : IFacadeMultipleChoice
    {
        private IMultipleChoiceDomain _multipleChoiceDomain { set; get; }
        private IStepDomain stepDomain { set; get; }
        private IChallengeDomain challengeDomain { set; get; }
        private ISectionDomain sectionDomain { set; get; }

        public FacadeMultipleChoice(IMultipleChoiceDomain multipleChoiceDomain, IStepDomain stepDomain, IChallengeDomain challengeDomain, ISectionDomain sectionDomain)
        {
            this._multipleChoiceDomain = multipleChoiceDomain;
            this.stepDomain = stepDomain;
            this.challengeDomain = challengeDomain;
            this.sectionDomain = sectionDomain;
        }

        public void Save(GesTmultiplechoice mult, GesTetapa step)
        {
            _multipleChoiceDomain.Create(mult);
            step.IdMchoice = mult.Id;
            stepDomain.Create(step);
            challengeDomain.VerifyStateChallenge(step.IdDesafio);
            var challenge = challengeDomain.Get(step.IdDesafio);
            sectionDomain.VerifyStateSection(challenge.IdSeccion);
        }

        public void Update(GesTmultiplechoice aut, GesTetapa step)
        {
            _multipleChoiceDomain.Update(aut);
            step.IdMchoice = aut.Id;
            stepDomain.Update(step);
        }
    }
}
