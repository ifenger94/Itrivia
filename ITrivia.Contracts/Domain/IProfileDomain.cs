using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Contracts.Domain
{
    public interface IProfileDomain : IDomainBase<GesTperfile>
    {
        void AddExperience(int idProfile, int experience);
    }
}
