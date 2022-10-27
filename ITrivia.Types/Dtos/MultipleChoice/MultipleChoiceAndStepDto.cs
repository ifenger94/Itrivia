using ITrivia.Types.Dtos.Step;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Dtos.MultipleChoice
{
    public class MultipleChoiceAndStepDto
    {
        public MultipleChoiceDto MultipleChoiceDto { set; get; }
        public StepDto StepDto { set; get; }
    }
}
