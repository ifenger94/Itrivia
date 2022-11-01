using AutoMapper;
using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Facade;
using ITrivia.Domain.Management;
using ITrivia.Types.Dtos.Challenge;
using ITrivia.Types.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Itrivia.WebApi.Controllers.Managment
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChallengeController : ControllerBase
    {
        private readonly IChallengeDomain _challengeDomain;
        private readonly ISectionDomain _sectionDomain;
        private readonly IFacadeChallenge _facadeChallenge;

        public IMapper _mapper;

        public ChallengeController(IChallengeDomain challengeDomain, ISectionDomain sectionDomain, IFacadeChallenge facadeChallenge, IMapper mapper)
        {
            this._challengeDomain = challengeDomain;
            this._sectionDomain = sectionDomain;
            this._facadeChallenge = facadeChallenge;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<GesTdesafio> challenges = _challengeDomain.GetAll();
                IEnumerable<ChallengeDto> challengesDto = _mapper.Map<List<ChallengeDto>>(challenges);
                return Ok(challengesDto);
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
                GesTdesafio challenge = _challengeDomain.Get(id);
                if (challenge == null) return NotFound();
                return Ok(_mapper.Map<ChallengeDto>(challenge));
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("/api/Section/{sectionId}/Challenge")]
        public IActionResult GetChallengeBySectionId(int sectionId)
        {
            try
            {
                if (sectionId == 0) return BadRequest();
                if (_sectionDomain.Get(sectionId) == null) return NotFound();

                IEnumerable<GesTdesafio> challenges = _challengeDomain.GetChallengeBySectionId(sectionId);
                IEnumerable<ChallengeDto> challengesDto = _mapper.Map<List<ChallengeDto>>(challenges);
                return Ok(challengesDto);

            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] ChallengeDto challenge)
        {
            try
            {
                if (challenge.Id == 0)
                {
                    GesTdesafio item = null;

                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                    {
                        item = _challengeDomain.Create(_mapper.Map<GesTdesafio>(challenge));
                        scope.Complete();
                    }

                    return Ok(item);

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] ChallengeDto challenge)
        {
            try
            {
                if (challenge.Id != id)
                    return BadRequest();

                if (_challengeDomain.Get(id) == null)
                    return NotFound();

                _challengeDomain.Update(_mapper.Map<GesTdesafio>(challenge));
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
                GesTdesafio challenge = _challengeDomain.Get(id);
                if (challenge == null) return NotFound();
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    _facadeChallenge.ExecuteDelete(id);
                    scope.Complete();
                }
                return Ok();

            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

    }
}
