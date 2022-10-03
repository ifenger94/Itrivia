using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Repository;
using ITrivia.Domain.Base;
using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Domain.Management
{

    public class ProfileDomain : DomainBase<IProfileRepository, GesTperfile>, IProfileDomain
    {
        public ProfileDomain(IProfileRepository profileRepository) : base(profileRepository)
        {
        }
      
        public void AddExperience(int idProfile, int experience)
        {
            GesTperfile profile = this.Get(idProfile);
            if (profile == null) throw new ArgumentNullException();
            profile.Exp += experience;
            Update(profile);
        }
    }

}
