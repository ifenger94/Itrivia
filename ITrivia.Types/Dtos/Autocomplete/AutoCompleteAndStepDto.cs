using ITrivia.Types.Dtos.Step;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Dtos.Autocomplete
{
    public class AutoCompleteAndStepDto
    {
        public AutoCompleteDto AutoCompleteDto { set; get; }
        public StepDto StepDto { set; get; }
    }
}
