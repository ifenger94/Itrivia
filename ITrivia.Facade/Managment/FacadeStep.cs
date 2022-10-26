using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Facade;
using ITrivia.Helpers;
using ITrivia.Types.Dtos.PairSelection;
using ITrivia.Types.Dtos.Step;
using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Facade.Managment
{
    public class FacadeStep : IFacadeStep
    {
        private IPairSelectionDomain pairSelectionDomain { set; get; }
        private IMultipleChoiceDomain multipleChoiceDomain { set; get; }
        private IAutocompleteDomain autocompleteDomain { set; get; }
        private ISectionDomain sectionDomain { set; get; }
        private IStepDomain stepDomain { set; get; }
        private IChallengeDomain challengeDomain { set; get; }

        public FacadeStep(IPairSelectionDomain pairSelectionDomain, IMultipleChoiceDomain multipleChoiceDomain, IAutocompleteDomain autocompleteDomain, ISectionDomain sectionDomain, IStepDomain stepDomain, IChallengeDomain challengeDomain)
        {
            this.pairSelectionDomain = pairSelectionDomain;
            this.multipleChoiceDomain = multipleChoiceDomain;
            this.autocompleteDomain = autocompleteDomain;
            this.stepDomain = stepDomain;
            this.challengeDomain = challengeDomain;
            this.sectionDomain = sectionDomain;
        }

        public void GeneratePairSelection(List<StepDetailDto> stepDetails)
        {
            if (stepDetails != null && stepDetails.Count > 0)
            {
                PairSelectionGameDto pairSelectionGame;

                foreach (var e in stepDetails)
                {
                    if (e.PairSelectionId != null)
                    {
                        pairSelectionGame = new PairSelectionGameDto() { };
                        var item = this.pairSelectionDomain.Get(e.PairSelectionId.Value);

                        pairSelectionGame.Id = item.Id;

                        List<PairOption> pairOptions = new List<PairOption>() {
                            new PairOption{Option = item.Opcion1 , Pair = HashHelper.Hash(item.Respuesta1.Replace(" ", string.Empty).ToLower())},
                            new PairOption{Option = item.Respuesta1 , Pair = HashHelper.Hash(item.Opcion1.Replace(" ", string.Empty).ToLower())},
                            new PairOption{Option = item.Opcion2 , Pair = HashHelper.Hash(item.Respuesta2.Replace(" ", string.Empty).ToLower())},
                            new PairOption{Option = item.Respuesta2 , Pair = HashHelper.Hash(item.Opcion2.Replace(" ", string.Empty).ToLower())},
                            new PairOption{Option = item.Opcion3 , Pair = HashHelper.Hash(item.Respuesta3.Replace(" ", string.Empty).ToLower())},
                            new PairOption{Option = item.Respuesta3 , Pair = HashHelper.Hash(item.Opcion3.Replace(" ", string.Empty).ToLower())},
                            new PairOption{Option = item.Opcion4 , Pair = HashHelper.Hash(item.Respuesta4.Replace(" ", string.Empty).ToLower())},
                            new PairOption{Option = item.Respuesta4 , Pair = HashHelper.Hash(item.Opcion4.Replace(" ", string.Empty).ToLower())}
                        };

                        pairSelectionGame.PairOptions = UtilHelper.ShuffleList(pairOptions);
                        e.PairSelection = pairSelectionGame;
                    }
                }
            }
        }

        public void DeleteAndUpdateStates(GesTetapa entity)
        {
            int challengeId = entity.IdDesafio;
            int sectionId = entity.IdDesafioNavigation.IdSeccion;

            stepDomain.Remove(entity.Id);

            if (entity.IdAutocompletado.HasValue)
                autocompleteDomain.Remove(entity.IdAutocompletado.Value);
            if (entity.IdMchoice.HasValue)
                multipleChoiceDomain.Remove(entity.IdMchoice.Value);
            if (entity.IdSpares.HasValue)
                pairSelectionDomain.Remove(entity.IdSpares.Value);

            challengeDomain.VerifyStateChallenge(challengeId);
            sectionDomain.VerifyStateSection(sectionId);
        }
    }
}
