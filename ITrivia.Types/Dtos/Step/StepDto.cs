using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Dtos.Step
{
    public class StepDto
    {
        public int Id { set; get; }
        public bool IsDeleted { set; get; }
        public DateTime CreateDate { set; get; }
        public DateTime? ModifyDate { set; get; }
        public string User { set; get; }
        public string Name { set; get; }
        public string ChallengeId { set; get; }
        public int GameTypeId { set; get; }
        public int? AutocompleteId { set; get; }
        public int? MultipleChoiceId { set; get; }
        public int? PairSelectionId { set; get; }
    }
}
