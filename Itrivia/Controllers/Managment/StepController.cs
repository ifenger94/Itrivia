using AutoMapper;
using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Facade;
using ITrivia.Facade.Managment;
using ITrivia.Types.Dtos.Step;
using ITrivia.Types.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Itrivia.WebApi.Controllers.Managment
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StepController : ControllerBase
    {
        private readonly IStepDomain _stepDomain;
        private readonly IFacadeStep _facadeStep;
        public IMapper _mapper;


        public StepController(IStepDomain stepDomain, IFacadeStep facadeStep, IMapper mapper)
        {
            this._stepDomain = stepDomain;
            this._facadeStep = facadeStep;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_stepDomain.GetAll());
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpGet("detail")]
        public IActionResult Get([FromQuery]int id)
        {
            try
            {
                GesTetapa etapa = _stepDomain.Get(id);
                if (etapa == null) return NotFound();
                return Ok(_mapper.Map<StepDto>(etapa));
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpGet("GetStepByChallenge")]
        public IActionResult GetStepByChallenge([FromQuery]int challengeId)
        {
            try
            {
                List<GesTetapa> steps = _stepDomain.GetStepsByChallengeId(challengeId).ToList();
                List<StepDetailDto> stepDetail = _mapper.Map<List<StepDetailDto>>(steps);
                _facadeStep.GeneratePairSelection(stepDetail);
                return Ok(stepDetail);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] GesTetapa etapa)
        {
            try
            {
                if (etapa.Id != 0)
                {
                    GesTetapa item = _stepDomain.Create(etapa);
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
        public IActionResult Put(int id, [FromBody] GesTetapa etapa)
        {
            try
            {
                if (etapa.Id != id)
                    return BadRequest();

                if (_stepDomain.Get(id) == null)
                    return NotFound();

                _stepDomain.Update(etapa);
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
                GesTetapa etapa = _stepDomain.Get(id);
                if (etapa == null) return NotFound();
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    _facadeStep.DeleteAndUpdateStates(etapa);
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
