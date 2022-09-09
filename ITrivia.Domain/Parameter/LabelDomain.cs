using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Repository;
using ITrivia.Domain.Base;
using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Domain.Parameter
{
    public class LabelDomain : DomainBase<ILabelRepository, ParPetiqueta>, ILabelDomain
    {
        public LabelDomain(ILabelRepository labelRepository) : base(labelRepository)
        {

        }

        public IDictionary<string, string> GetLabels(string languageCode)
        {
            Dictionary<string, string> Labels = new Dictionary<string, string>();

            switch (languageCode)
            {
                case "es":
                    Labels = GetAll().ToDictionary(e => e.Codigo, e => e.Espanol);
                    break;
                case "en":
                    Labels = GetAll().ToDictionary(e => e.Codigo, e => e.Ingles);
                    break;
            }

            return Labels;
        }
    }
}
