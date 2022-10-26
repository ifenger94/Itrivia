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
    public class CategoryDomain : DomainBase<ICategoryRepository, GesTcategoria>, ICategoryDomain
    {
        public CategoryDomain(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }
    }
}
