using AutoMapper;
using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Facade;
using ITrivia.Domain.Management;
using ITrivia.Domain.Parameter;
using ITrivia.Helpers;
using ITrivia.Types.Dtos.Section;
using ITrivia.Types.Filters;
using ITrivia.Types.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Itrivia.WebApi.Controllers.Managment
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SectionController : ControllerBase
    {
        private readonly ISectionDomain _sectionDomain;
        private readonly IFacadeSection _facadeSection;
        private readonly IMessageDomain _messageDomain;

        public IMapper _mapper;

        public SectionController(ISectionDomain sectionDomain, IFacadeSection facadeSection, IMessageDomain messageDomain, IMapper mapper)
        {
            this._sectionDomain = sectionDomain;
            this._facadeSection = facadeSection;
            this._messageDomain = messageDomain;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<GesTseccione> section = _sectionDomain.GetAll();
                IEnumerable<SectionDto> sectionDto = _mapper.Map<List<SectionDto>>(section);
                return Ok(sectionDto);
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
                GesTseccione section = _sectionDomain.Get(id);
                if (section == null) return NotFound();
                return Ok(_mapper.Map<SectionDto>(section));
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetSectionFilter")]
        public IActionResult GetSectionFilter([FromQuery] int profileId, [FromQuery] int? categoryId, [FromQuery] string? search)
        {
            try
            {
                FilterSectionManagment filter = new FilterSectionManagment { ProfileId = profileId, CategoryId = categoryId, Search = search };
                if (filter.ProfileId == 0) BadRequest();
                IEnumerable<GesTseccione> sections = this._facadeSection.GetSectionByProfile(filter);
                return Ok(_mapper.Map<List<SectionDto>>(sections));
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] SectionDto seccion)
        {
            try
            {
                if (seccion.Id == 0)
                {
                    GesTseccione item = _sectionDomain.Create(_mapper.Map<GesTseccione>(seccion));
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

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SectionDto seccion)
        {
            try
            {
                if (seccion.Id != id)
                    return BadRequest();

                if (_sectionDomain.Get(id) == null)
                    return NotFound();

                _sectionDomain.Update(_mapper.Map<GesTseccione>(seccion));
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
                GesTseccione section = _sectionDomain.Get(id);

                if (section == null) return NotFound();

                if (section.GesTdesafios.Any())
                    return BadRequest(_messageDomain.GetMessagetranslated("err-delete-section", LanguageHelper.CurrentLanguage(HttpContext.Request)));

                _sectionDomain.Remove(section.Id);

                return Ok();

            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
