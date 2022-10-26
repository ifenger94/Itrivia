using AutoMapper;
using ITrivia.Contracts.Domain;
using ITrivia.Types.Dtos.GameType;
using ITrivia.Types.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Itrivia.WebApi.Controllers.Managment
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GameTypeController : ControllerBase
    {
        private readonly IGameTypeDomain _gameTypeDomain;
        public IMapper _mapper;

        public GameTypeController(IGameTypeDomain gameTypeDomain, IMapper mapper)
        {
            this._gameTypeDomain = gameTypeDomain;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<List<GameTypeDto>>(_gameTypeDomain.GetAll()));
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
                GesPtipoJuego tipojuego = _gameTypeDomain.Get(id);
                if (tipojuego == null) return NotFound();
                return Ok(_mapper.Map<GameTypeDto>(tipojuego));
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] GesPtipoJuego tipojuego)
        {
            try
            {
                if (tipojuego.Id != 0)
                {
                    GesPtipoJuego item = _gameTypeDomain.Create(tipojuego);
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
        public IActionResult Put(int id, [FromBody] GesPtipoJuego tipojuego)
        {
            try
            {
                if (tipojuego.Id != id)
                    return BadRequest();

                if (_gameTypeDomain.Get(id) == null)
                    return NotFound();

                _gameTypeDomain.Update(tipojuego);
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
                GesPtipoJuego tipojuego = _gameTypeDomain.Get(id);
                if (tipojuego == null) return NotFound();
                _gameTypeDomain.Delete(tipojuego);
                return Ok();

            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
