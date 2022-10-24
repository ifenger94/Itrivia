using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Types.Dtos.Profile
{

    public class ProfileDto
    {
        public int Id { set; get; }
        public bool IsDeleted { set; get; }
        public DateTime CreateDate { set; get; }
        public DateTime? ModifyDate { set; get; }
        public string User { set; get; }
        public int Experience { set; get; }
    }
}
