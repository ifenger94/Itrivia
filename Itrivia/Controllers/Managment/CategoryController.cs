using AutoMapper;
using ITrivia.Contracts.Domain;
using ITrivia.Types.Dtos.Category;
using ITrivia.Types.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Itrivia.WebApi.Controllers.Managment
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController:ControllerBase
    {
        private readonly ICategoryDomain _categoryCompleteDomain;
        private IMapper _mapper;

        public CategoryController(ICategoryDomain categoryCompleteDomain, IMapper mapper)
        {
            this._categoryCompleteDomain = categoryCompleteDomain;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<GesTcategoria> categorys = _categoryCompleteDomain.GetAll();
                IEnumerable<CategoryDto> categorysDto = _mapper.Map<List<CategoryDto>>(categorys);
                return Ok(categorysDto);
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
                GesTcategoria categ = _categoryCompleteDomain.Get(id);
                if (categ == null) return NotFound();
                CategoryDto categoryDto = _mapper.Map<CategoryDto>(categ);
                return Ok(categoryDto);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] GesTcategoria categ)
        {
            try
            {
                if (categ.Id != 0)
                {
                    GesTcategoria item = _categoryCompleteDomain.Create(categ);
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
        public IActionResult Put(int id, [FromBody] CategoryDto categ)
        {
            try
            {
                if (categ.Id != id)
                    return BadRequest();

                if (_categoryCompleteDomain.Get(id) == null)
                    return NotFound();

                _categoryCompleteDomain.Update(_mapper.Map<GesTcategoria>(categ));
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
                GesTcategoria categ = _categoryCompleteDomain.Get(id);
                if (categ == null) return NotFound();
                _categoryCompleteDomain.Delete(categ);
                return Ok();

            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
