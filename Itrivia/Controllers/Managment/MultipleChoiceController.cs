using AutoMapper;
using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Facade;
using ITrivia.Types.Dtos.MultipleChoice;
using ITrivia.Types.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Itrivia.WebApi.Controllers.Managment
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MultipleChoiceController : ControllerBase
    {
        private readonly IMultipleChoiceDomain _multipleChoiceDomain;
        private readonly IFacadeMultipleChoice _facadeMultipleChoice;
        public IMapper _mapper;
        public MultipleChoiceController(IMultipleChoiceDomain multipleChoiceDomain, IFacadeMultipleChoice facadeMultipleChoice, IMapper mapper)
        {
            this._multipleChoiceDomain = multipleChoiceDomain;
            this._facadeMultipleChoice = facadeMultipleChoice;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_multipleChoiceDomain.GetAll());
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
                GesTmultiplechoice multchoice = _multipleChoiceDomain.Get(id);
                if (multchoice == null) return NotFound();
                return Ok(_mapper.Map<MultipleChoiceDto>(multchoice));
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] MultipleChoiceAndStepDto item)
        {
            try
            {
                if (item.MultipleChoiceDto.Id == 0)
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                    {
                        _facadeMultipleChoice.Save(_mapper.Map<GesTmultiplechoice>(item.MultipleChoiceDto), _mapper.Map<GesTetapa>(item.StepDto));
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
        public IActionResult Put(int id, [FromBody] MultipleChoiceAndStepDto multc)
        {
            try
            {
                if (multc.MultipleChoiceDto.Id != id)
                    return BadRequest();

                if (_multipleChoiceDomain.Get(id) == null)
                    return NotFound();
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    _facadeMultipleChoice.Update(_mapper.Map<GesTmultiplechoice>(multc.MultipleChoiceDto), _mapper.Map<GesTetapa>(multc.StepDto));
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
                GesTmultiplechoice multchoice = _multipleChoiceDomain.Get(id);
                if (multchoice == null) return NotFound();
                _multipleChoiceDomain.Delete(multchoice);
                return Ok();

            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }

}
