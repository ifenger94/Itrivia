using AutoMapper;
using ITrivia.Contracts.Domain;
using ITrivia.Types.Dtos.HistoryPS;
using ITrivia.Types.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Itrivia.WebApi.Controllers.Managment
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HistoryPSController : ControllerBase
    {
        private readonly IHistoryPSDomain _historyPSDomain;
        public IMapper _mapper;

        public HistoryPSController(IHistoryPSDomain historyPSDomain, IMapper mapper)
        {
            this._historyPSDomain = historyPSDomain;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_historyPSDomain.GetAll());
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
                GesThistPerfilSeccione histds = _historyPSDomain.Get(id);
                if (histds == null) return NotFound();
                return Ok(_mapper.Map<HistoryPSDto>(histds));
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] GesThistPerfilSeccione histds)
        {
            try
            {
                if (histds.Id != 0)
                {
                    GesThistPerfilSeccione item = _historyPSDomain.Create(histds);
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
        public IActionResult Put(int id, [FromBody] GesThistPerfilSeccione histds)
        {
            try
            {
                if (histds.Id != id)
                    return BadRequest();

                if (_historyPSDomain.Get(id) == null)
                    return NotFound();

                _historyPSDomain.Update(histds);
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
                GesThistPerfilSeccione histds = _historyPSDomain.Get(id);
                if (histds == null) return NotFound();
                _historyPSDomain.Delete(histds);
                return Ok();

            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
