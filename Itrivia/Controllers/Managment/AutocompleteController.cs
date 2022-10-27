using AutoMapper;
using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Facade;
using ITrivia.Facade.Managment;
using ITrivia.Types.Dtos.Autocomplete;
using ITrivia.Types.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Itrivia.WebApi.Controllers.Managment
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AutocompleteController : ControllerBase
    {
        private readonly IAutocompleteDomain _autoCompleteDomain;
        private readonly IFacadeAutoComplete _facadeAutocomplete;
        public IMapper _mapper;

        public AutocompleteController(IAutocompleteDomain autocompleteDomain, IFacadeAutoComplete facadeAutoComplete, IMapper mapper)
        {
            this._autoCompleteDomain = autocompleteDomain;
            this._facadeAutocomplete = facadeAutoComplete;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<GesTautocompletado> autocp = _autoCompleteDomain.GetAll();
                return Ok(_mapper.Map<IEnumerable<AutoCompleteDto>>(autocp));
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
                GesTautocompletado autocp = _autoCompleteDomain.Get(id);
                if (autocp == null) return NotFound();
                return Ok(_mapper.Map<AutoCompleteDto>(autocp));
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        //[HttpGet("{id}")]
        //public IActionResult ValidateAnswer(int id, [FromQuery] string answer)
        //{
        //    try
        //    {
        //        GesTautocompletado autocp = _autoCompleteDomain.Get(id);

        //        if (autocp == null) return NotFound();

        //        string curretAnswer = this._autoCompleteDomain.CorrectAnswer(id);

        //        AutoCompleteResultDto auto = new AutoCompleteResultDto()
        //        {
        //            answer = curretAnswer
        //        };

        //        if (curretAnswer.ToUpper() == answer.ToUpper()) auto.valid = true;

        //        return Ok(auto);
        //    }
        //    catch (Exception e)
        //    {
        //        return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
        //    }
        //}
        
        [HttpPost]
        public IActionResult Post([FromBody] AutoCompleteAndStepDto item)
        {
            try
            {
                if (item.AutoCompleteDto.Id == 0)
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                    {
                        _facadeAutocomplete.Save(_mapper.Map<GesTautocompletado>(item.AutoCompleteDto), _mapper.Map<GesTetapa>(item.StepDto));
                        scope.Complete();
                    }

                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] AutoCompleteAndStepDto autocp)
        {
            try
            {
                if (autocp.AutoCompleteDto.Id != id)
                    return BadRequest();

                if (_autoCompleteDomain.Get(id) == null)
                    return NotFound();
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    _facadeAutocomplete.Update(_mapper.Map<GesTautocompletado>(autocp.AutoCompleteDto), _mapper.Map<GesTetapa>(autocp.StepDto));
                    scope.Complete();
                }
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
                GesTautocompletado autocp = _autoCompleteDomain.Get(id);
                if (autocp == null) return NotFound();
                _autoCompleteDomain.Delete(autocp);
                return Ok();

            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
