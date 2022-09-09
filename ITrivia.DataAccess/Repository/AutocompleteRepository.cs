﻿using ITrivia.Contracts.Repository;
using ITrivia.Types;
using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.DataAccess.Repository
{
    public class AutocompleteRepository : GenericRepository<ITriviaDataBaseContext , GesTautocompletado >, IAutocompleteRepository
    {
    }
}
