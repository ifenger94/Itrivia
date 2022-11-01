using AutoMapper;
using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Facade;
using ITrivia.Domain.Management;
using ITrivia.Facade.Managment;
using ITrivia.Types.Dtos.Profile;
using ITrivia.Types.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Itrivia.WebApi.Controllers.Managment
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileDomain _profileDomain;
        private readonly IFacadeProfile _facadeProfile;
        private readonly IMapper _mapper;

        public ProfileController(IProfileDomain profileDomain, IFacadeProfile facadeProfile, IMapper mapper)
        {
            this._profileDomain = profileDomain;
            this._facadeProfile = facadeProfile;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_profileDomain.GetAll());
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
                GesTperfile profile = _profileDomain.Get(id);
                if (profile == null) return NotFound();
                return Ok(_mapper.Map<ProfileDto>(profile));
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] ProfileDto profile)
        {
            try
            {
                if (profile.Id != 0)
                {
                    GesTperfile item = _profileDomain.Create(_mapper.Map<GesTperfile>(profile));
                    return Ok(item);
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProfileDto profile)
        {
            try
            {
                if (profile.Id != id)
                    return BadRequest();

                if (_profileDomain.Get(id) == null)
                    return NotFound();

                _profileDomain.Update(_mapper.Map<GesTperfile>(profile));
                return Ok();

            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("AddExperence/{id}")]
        public IActionResult AddExperence(int id, [FromQuery] int challengeId)
        {
            try
            {
                if (_profileDomain.Get(id) == null)
                    return NotFound();

                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    _facadeProfile.AddExperenceAndHistory(id, challengeId);
                    scope.Complete();
                }

                return Ok();

            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                GesTperfile profile = _profileDomain.Get(id);
                if (profile == null) return NotFound();
                _profileDomain.Delete(profile);
                return Ok();

            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
