using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Contracts.Facade
{
    public interface IFacadeUser
    {
        SegTusuario GenerateUser(SegTusuario user);

        //IEnumerable<SummaryUserProfileDto> GetSummaryUserProfile();

    }
}
