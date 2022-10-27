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
    public class SectionDomain : DomainBase<ISectionRepository, GesTseccione>, ISectionDomain
    {
        public SectionDomain(ISectionRepository sectionRepository) : base(sectionRepository)
        {
        }

        public void VerifyStateSection(int id)
        {
            GesTseccione currentSection = Get(id);
            int totalCount = currentSection.GesTdesafios.Where(e => e.Activated).Count();

            if (currentSection.Activated)
            {
                if (totalCount != currentSection.CantDesafios)
                {
                    currentSection.Activated = false;
                    Update(currentSection);
                }
            }
            else
            {
                if (totalCount == currentSection.CantDesafios)
                {
                    currentSection.Activated = true;
                    Update(currentSection);
                }
            }
        }
    }
}
