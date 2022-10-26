using AutoMapper;
using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Facade;
using ITrivia.Types.Dtos.PairSelection;
using ITrivia.Types.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Itrivia.WebApi.Controllers.Managment
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PairSelectionController : ControllerBase
    {
        private readonly IPairSelectionDomain _pairSelectionDomain;
        private readonly IFacadePairSelection _facadePairSelection;
        public IMapper _mapper;


        public PairSelectionController(IPairSelectionDomain pairSelectionDomain, IFacadePairSelection facadePairSelection, IMapper mapper)
        {
            this._pairSelectionDomain = pairSelectionDomain;
            this._facadePairSelection = facadePairSelection;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_pairSelectionDomain.GetAll());
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
                GesTselecPare select = _pairSelectionDomain.Get(id);
                if (select == null) return NotFound();
                return Ok(_mapper.Map<PairSelectionDto>(select));
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("Validate")]
        public IActionResult PairSelectionValidate(RequestPairSelectionDto request)
        {
            try
            {
                return Ok(_pairSelectionDomain.ValidatePairSelection(request.Option, request.Pair));
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] PairSelectionAndStepDto item)
        {
            try
            {
                if (item.PairSelectionDto.Id == 0)
                {
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                    {
                        _facadePairSelection.Save(_mapper.Map<GesTselecPare>(item.PairSelectionDto), _mapper.Map<GesTetapa>(item.StepDto));
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
        public IActionResult Put(int id, [FromBody] PairSelectionAndStepDto selp)
        {
            try
            {
                if (selp.PairSelectionDto.Id != id)
                    return BadRequest();

                if (_pairSelectionDomain.Get(id) == null)
                    return NotFound();
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    _facadePairSelection.Update(_mapper.Map<GesTselecPare>(selp.PairSelectionDto), _mapper.Map<GesTetapa>(selp.StepDto));
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
                GesTselecPare select = _pairSelectionDomain.Get(id);
                if (select == null) return NotFound();
                _pairSelectionDomain.Delete(select);
                return Ok();

            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
