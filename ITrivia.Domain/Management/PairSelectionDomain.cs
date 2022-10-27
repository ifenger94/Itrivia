using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Repository;
using ITrivia.Domain.Base;
using ITrivia.Helpers;
using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Domain.Management
{
    public class PairSelectionDomain : DomainBase<IPairSelectionRepository, GesTselecPare>, IPairSelectionDomain
    {
        public PairSelectionDomain(IPairSelectionRepository pairSelectionRepository) : base(pairSelectionRepository)
        {
        }

        public bool ValidatePairSelection(string option, string pair)
        {
            bool validate = false;

            if (!string.IsNullOrEmpty(option) && !string.IsNullOrEmpty(pair))
            {
                option = option.Replace(" ", string.Empty).ToLower();
                validate = HashHelper.CheckHash(option, pair);
            }

            return validate;
        }
    }
}
