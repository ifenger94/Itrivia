using ITrivia.Types.Dtos.Category;
using ITrivia.Types.Dtos.Challenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Dtos.Section
{
    public class SectionDetailDto : SectionDto
    {
        public CategoryDto Category { set; get; }
        public List<ChallengeDto> Challenges { set; get; }
    }
}
