﻿using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Contracts.Domain
{
    public interface IPairSelectionDomain : IDomainBase<GesTselecPare>
    {
        bool ValidatePairSelection(string option,string pair);
    }
}
