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
    public class MessageDomain : DomainBase<IMessagelRepository, ParPmensaje>, IMessageDomain
    {
        public MessageDomain(IMessagelRepository messageRepository) : base(messageRepository)
        {
        }


        public IDictionary<string, string> GetMessages(string languageCode)
        {
            Dictionary<string, string> Messages = new Dictionary<string, string>();

            switch (languageCode)
            {
                case "es":
                    Messages = GetAll().ToDictionary(e => e.Codigo, e => e.Espanol);
                    break;
                case "en":
                    Messages = GetAll().ToDictionary(e => e.Codigo, e => e.Ingles);
                    break;
            }

            return Messages;
        }

        public string GetMessagetranslated(string code, string language)
        {
            string message = string.Empty;

            switch (language)
            {
                case "es":
                    message = GetAllBy(e => e.Codigo == code).Select(e => e.Espanol).FirstOrDefault();
                    break;
                case "en":
                    message = GetAllBy(e => e.Codigo == code).Select(e => e.Ingles).FirstOrDefault();
                    break;
            }

            return message;

        }
    }
}
