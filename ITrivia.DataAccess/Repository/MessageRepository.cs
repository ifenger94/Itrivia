using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Repository;
using ITrivia.Types;
using ITrivia.Types.Models;

namespace ITrivia.DataAccess.Repository
{
    public class MessageRepository : GenericRepository<ITriviaDataBaseContext, ParPmensaje>, IMessagelRepository
    {
        
    }
}
