using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Repository;
using ITrivia.Domain.Base;
using ITrivia.Helpers;
using ITrivia.Types.Dtos.HistoryPDDto;
using ITrivia.Types.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrivia.Domain.Management
{
    public class HistoryPDDomain : DomainBase<IHistoryPDRepository, GesThistPerfilDesafio>, IHistoryPDDomain
    {
        public HistoryPDDomain(IHistoryPDRepository historyPDRepository) : base(historyPDRepository)
        {
        }

        public IEnumerable<GesThistPerfilDesafio> GetHpdByProfileId(int id)
        {
            return GetAllBy(e => e.Baja == false && e.IdPerfil == id);
        }

        public override GesThistPerfilDesafio Create(GesThistPerfilDesafio entity)
        {
            //entity.usuario = JwtHelper.instace.GetCurrentUser();
            entity.Usuario = "a";
            return base.Create(entity);
        }

        public IEnumerable<ExperienceHistoryPDDto> GetExperenceAndHistory(int profileId,string language)
        {
            CultureInfo culture;

            if (language == "es")
                culture = new System.Globalization.CultureInfo("es-ES");
            else
                culture = new System.Globalization.CultureInfo("en-EN");

            List<ExperienceHistoryPDDto> experienceHistoryPDDtos = new List<ExperienceHistoryPDDto>();

            Dictionary<DayOfWeek, int> keyValuePairs = new Dictionary<DayOfWeek, int>();

            DayOfWeek currentDayOfWeek = DateTime.Now.DayOfWeek;

            DateTime dateToFilter = DateTime.Now.AddDays(-6);

            List<IGrouping<DayOfWeek, GesThistPerfilDesafio>> history = GetAllBy(e => e.IdPerfil == profileId && e.AltaFecha >= dateToFilter)
                .GroupBy(e => e.AltaFecha.DayOfWeek).ToList();


            history.ForEach(e => keyValuePairs.Add(e.Key, e.Sum(f => f.IdDesafioNavigation.Experiencia)));

            foreach (DayOfWeek item in Enum.GetValues(typeof(DayOfWeek)))
            {
                if (!keyValuePairs.Any(e => e.Key == item))
                {
                    keyValuePairs.Add(item, 0);
                }
            }


            List<KeyValuePair<DayOfWeek, int>> expWeeklyCalculate = keyValuePairs.OrderBy(x => (x.Key - currentDayOfWeek + 7) % 7).ToList();

            for (int i = 1; i < expWeeklyCalculate.Count; i++)
            {
                experienceHistoryPDDtos.Add(new ExperienceHistoryPDDto { DayOfWeek = culture.DateTimeFormat.GetDayName(expWeeklyCalculate[i].Key).ToString(), Experience = expWeeklyCalculate[i].Value });
            }

            experienceHistoryPDDtos.Add(new ExperienceHistoryPDDto { DayOfWeek = culture.DateTimeFormat.GetDayName(expWeeklyCalculate[0].Key).ToString(), Experience = expWeeklyCalculate[0].Value });


            return experienceHistoryPDDtos;

        }
    }
}
