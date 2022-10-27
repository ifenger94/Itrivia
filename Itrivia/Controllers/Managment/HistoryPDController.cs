using AutoMapper;
using ITrivia.Contracts.Domain;
using ITrivia.Domain.Management;
using ITrivia.Helpers;
using ITrivia.Types.Dtos.HistoryPD;
using ITrivia.Types.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Itrivia.WebApi.Controllers.Managment
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HistoryPDController : ControllerBase
    {
        private readonly IHistoryPDDomain _historyPDDomain;
        private readonly IProfileDomain _profileDomain;
        public IMapper _mapper;

        public HistoryPDController(IHistoryPDDomain historyPDDomain, IProfileDomain profileDomain, IMapper mapper)
        {
            this._historyPDDomain = historyPDDomain;
            this._profileDomain = profileDomain;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_historyPDDomain.GetAll());
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                GesThistPerfilDesafio histdd = _historyPDDomain.Get(id);
                if (histdd == null) return NotFound();
                return Ok(_mapper.Map<HistoryPDDto>(histdd));
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetHpdByProfileId")]
        public IActionResult GetHpdByProfileId([FromQuery] int profileId)
        {
            try
            {
                if (_profileDomain.Get(profileId) == null) return NotFound();
                List<GesThistPerfilDesafio> histdd = _historyPDDomain.GetHpdByProfileId(profileId).ToList();
                return Ok(_mapper.Map<List<HistoryPDDto>>(histdd));
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("WeeklyExperienceByProfile/{id}")]
        public IActionResult GetExpHistoryByProfile(int id)
        {
            try
            {
                if (_profileDomain.Get(id) == null) NotFound();
                return Ok(_historyPDDomain.GetExperenceAndHistory(id,LanguageHelper.CurrentLanguage(Request)));
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] GesThistPerfilDesafio histdd)
        {
            try
            {
                if (histdd.Id != 0)
                {
                    GesThistPerfilDesafio item = _historyPDDomain.Create(histdd);
                    return Ok(item);
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] GesThistPerfilDesafio histdd)
        {
            try
            {
                if (histdd.Id != id)
                    return BadRequest();

                if (_historyPDDomain.Get(id) == null)
                    return NotFound();

                _historyPDDomain.Update(histdd);
                return Ok();

            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                GesThistPerfilDesafio histdd = _historyPDDomain.Get(id);
                if (histdd == null) return NotFound();
                _historyPDDomain.Delete(histdd);
                return Ok();

            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
