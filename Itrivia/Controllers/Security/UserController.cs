using AutoMapper;
using ITrivia.Contracts.Domain;
using ITrivia.Contracts.Facade;
using ITrivia.Domain.Parameter;
using ITrivia.Helpers;
using ITrivia.Types.Dtos.User;
using ITrivia.Types.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Transactions;

namespace Itrivia.WebApi.Controllers.Security
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserDomain _userDomain;
        private readonly IFacadeUser _facadeUser;
        private readonly IMessageDomain _messageDomain;
        private readonly IMapper _mapper;

        public UserController(IUserDomain userDomain, IFacadeUser facadeUser, IMessageDomain messageDomain,IMapper mapper)
        {
            this._userDomain = userDomain;
            this._facadeUser = facadeUser;
            this._messageDomain = messageDomain;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<SegTusuario> s = _userDomain.GetAll().ToList();
                return Ok(_userDomain.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                UserDto user = _mapper.Map<UserDto>(_userDomain.Get(id));
                if (user == null) return NotFound();
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet("detail/{id}")]
        public IActionResult GetUserDetail(int id)
        {
            try
            {
                SegTusuario user = _userDomain.Get(id);
                if (user == null) return NotFound();
                UserDetailDto userDetail = _mapper.Map<UserDetailDto>(user);
                return Ok(userDetail);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet("SummaryUserProfile")]
        public IActionResult GetSumaryUserProfile()
        {
            try
            {
                return Ok(this._facadeUser.GetSummaryUserProfile());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] UserRequestDto userRequestDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                if (_userDomain.GetByEmail(userRequestDto.Email) != null) return BadRequest(_messageDomain.GetMessagetranslated("toast-failed2", LanguageHelper.CurrentLanguage(Request)));

                SegTusuario user;

                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    user = _facadeUser.GenerateUser(_mapper.Map<SegTusuario>(userRequestDto));
                    scope.Complete();
                }

                if (user == null)
                    return BadRequest();
                else
                    return CreatedAtRoute(null, new { id = user.Id }, userRequestDto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
        
        [HttpPut]
        public IActionResult Put(int id, [FromBody] UserUpdateRequestDto userRequestDto)
        {
            try
            {
                if (userRequestDto.Id != id || !ModelState.IsValid)
                    return BadRequest();

                if (_userDomain.Get(id) == null)
                    return NotFound();

                _userDomain.UpdateUser(_mapper.Map<SegTusuario>(userRequestDto));
                return Ok();

            }
            catch (InvalidOperationException e)
            {
                return BadRequest(_messageDomain.GetMessagetranslated("toast-failed2", LanguageHelper.CurrentLanguage(HttpContext.Request)));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPut("api/user/resetpassword/{id}")]
        public IActionResult ResetPassword(int id, [FromBody] UserResetPasswordDto userResetPassword)
        {
            try
            {
                if (userResetPassword.Id != id || !ModelState.IsValid || userResetPassword.Password != userResetPassword.Password2)
                    return BadRequest();

                if (_userDomain.Get(id) == null)
                    return NotFound();

                _userDomain.ResetPassword(userResetPassword.Id, userResetPassword.Password);
                return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
        
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                SegTusuario user = _userDomain.Get(id);
                if (user == null) return NotFound();
                _userDomain.Delete(user);
                return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}
