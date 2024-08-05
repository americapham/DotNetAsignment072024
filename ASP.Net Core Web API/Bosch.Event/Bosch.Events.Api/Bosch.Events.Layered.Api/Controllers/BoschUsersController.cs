using AutoMapper;
using Bosch.Events.Domain.Entities;
using Bosch.Events.Layered.Api.Jwt;
using Bosch.Events.UseCases;
using Bosch.Events.UseCases.Contracts;
using Bosch.Events.UseCases.DTOs.UserDtos;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Bosch.Events.Layered.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoschUsersController : ControllerBase
    {
        private readonly ICommonRepository<User> _userRepository;
        private readonly IBoschAuthenticator _userAuthenticator;
        private readonly ICommonRepository<Role> _roleRepository;
        private readonly IMapper _mapper;
        private readonly ITokenManager _tokenManager;

        public BoschUsersController(ICommonRepository<User> userRepository, IMapper mapper, IBoschAuthenticator userAuthenticator, ICommonRepository<Role> roleRepository, ITokenManager tokenManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userAuthenticator = userAuthenticator;
            _roleRepository = roleRepository;
            _tokenManager = tokenManager;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]

        public async Task<ActionResult<List<UserDto>>> GetBoschUsers()
        {
            try
            {
                var users = _mapper.Map<List<UserDto>>(await _userRepository.GetAllAsync());
                if (users == null || users.Count > 0)
                {
                    return Ok(users);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> GetBoschUserDetails(int id)
        {
            try
            {
                var boschUser = _mapper.Map<UserDto>(await _userRepository.GetDetailsAsync(id));
                if (boschUser != null)
                    return Ok(boschUser);
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]

        public async Task<ActionResult<UserDto>> PostBoschUser(InsertUserDto userDto)
        {

            var newUser = _mapper.Map<User>(userDto);
            if (ModelState.IsValid)
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
                newUser.Password = hashedPassword;
                int result = await _userRepository.InsertAsync(newUser);
                if (result > 0)
                {
                    return Created("GetBoschUserDetails", newUser);
                }
            }
            return BadRequest();
        }

        /*[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[HttpPost]
 
		public async Task<ActionResult<UserDto>> DeleteBoschUser(int id)
		{
            var existingUser = _mapper.Map<User>(await _userRepository.GetDetailsAsync(id));
			if (ModelState.IsValid)
			{
			}
			return BadRequest();
		}*/

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("CheckCrendentialsPost")]

        public async Task<ActionResult<UserDto>> CheckCrendentialsPost(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                var boschUser = _mapper.Map<User>(userDto);
                var result = await _userAuthenticator.Authenticate(boschUser);
                if (result != null)
                {

                    var passwordVerification = BCrypt.Net.BCrypt.Verify(userDto.Password, result.Password);
                    if (passwordVerification)
                    {
                        var role = await _roleRepository.GetDetailsAsync(result.RoleId);
                        return Ok(new AuthResponse() { Email = boschUser.UserName, Role = role.RoleName, Token = _tokenManager.GenerateToken(result, role.RoleName) });
                    }
                    else
                        return BadRequest(new { Message = "Authentication Failed" });
                }
                return BadRequest(new { message = $"User with Email/Name:{boschUser.UserName} doesn't exist!!" });
            }
            return BadRequest(new { message = "Please check Input" });
        }
    }
}