using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [AllowAnonymous]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRepository _repo;
    private readonly IConfiguration _config;

    public AuthController(IAuthRepository repo, IConfiguration config)
    {
      _config = config;
      _repo = repo;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
    {
      userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();
      if (await _repo.UserExists(userForRegisterDto.UserName)) { return BadRequest("Username allready exsits"); }
      var usertoCreate = new User
      {
        UserName = userForRegisterDto.UserName
      };
      var createdUser = await _repo.Register(usertoCreate, userForRegisterDto.Password);
      return StatusCode(201);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserForLogOnDto userForLogonDto)
    {
      userForLogonDto.UserName = userForLogonDto.UserName.ToLower();
      var userfromrepo = await _repo.Login(userForLogonDto.UserName, userForLogonDto.Password);
      if (userfromrepo == null)
      {
        return Unauthorized();
      }
     

      var tokenHandler = new JwtSecurityTokenHandler();

      var token = tokenHandler.CreateToken(tokenDescriptor);

      return Ok(new
      {
        token = tokenHandler.WriteToken(token)
      });
    }
    private string GenerateJwt 

  }
}