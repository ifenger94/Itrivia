using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Dtos.Challenge
{
    public class ChallengeDto
    {
        public int Id { set; get; }
        public bool IsDeleted { set; get; }
        public DateTime CreateDate { set; get; }
        public DateTime? ModifyDate { set; get; }
        public string User { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public int SectionId { set; get; }
        public int Experience { set; get; }
        public int StepsCount { set; get; }
        public bool Activated { set; get; }
    }
}
