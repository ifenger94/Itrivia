using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Facade;
using ITrivia.Helpers;
using ITrivia.Types.Filters;
using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Facade.Managment
{
    public class FacadeSection : IFacadeSection
    {
        private ISectionDomain sectionDomain { set; get; }
        private IUserDomain userDomain { set; get; }

        public FacadeSection(ISectionDomain sectionDomain, IUserDomain userDomain)
        {
            this.sectionDomain = sectionDomain;
            this.userDomain = userDomain;
        }

        public IEnumerable<GesTseccione> GetSectionByProfile(FilterSectionManagment filter)
        {
            List<GesTseccione> sections = new List<GesTseccione>();

            var user = this.userDomain.GetAllBy(e => e.IdPerfil == filter.ProfileId).FirstOrDefault();

            if (user != null)
            {
                Expression<Func<GesTseccione, bool>> expression = (e => e.Baja == false && e.Activated);

                if (filter.CategoryId.HasValue)
                    expression = ExpressionMethods.ExpressionAppend(ExpressionMethods.ExpressionOperation.AND, expression, (e => e.IdCategoria == filter.CategoryId));

                if (!string.IsNullOrEmpty(filter.Search))
                    expression = ExpressionMethods.ExpressionAppend(ExpressionMethods.ExpressionOperation.AND, expression, e => e.Nombre.Contains(filter.Search));

                sections = sectionDomain.GetAllBy(expression).ToList();

            }

            return sections;
        }
    }
}
