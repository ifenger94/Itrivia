using ITrivia.Types.Dtos.Section;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Dtos.Challenge
{
    public class ChallengeDetailDto : ChallengeDto
    {
        public SectionDto Section { get; set; }

    }
}
