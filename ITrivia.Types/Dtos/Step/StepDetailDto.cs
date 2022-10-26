using ITrivia.Types.Dtos.Autocomplete;
using ITrivia.Types.Dtos.Challenge;
using ITrivia.Types.Dtos.GameType;
using ITrivia.Types.Dtos.MultipleChoice;
using ITrivia.Types.Dtos.PairSelection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Dtos.Step
{
    public class StepDetailDto : StepDto
    {
        public ChallengeDto Challenge { set; get; }
        public GameTypeDto GameType { set; get; }
        public AutocompleteGameDto AutoComplete { set; get; }
        public MultipleChoiceDto MultipleChoice { set; get; }
        public PairSelectionGameDto PairSelection { set; get; }
    }
}
