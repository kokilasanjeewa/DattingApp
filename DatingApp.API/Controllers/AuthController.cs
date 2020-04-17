using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    private readonly IConfiguration _config;

    private readonly UserManager<User> _userManager;
     private readonly SignInManager<User> _signinManager;
     private readonly IMapper _mapper;

    public AuthController(IConfiguration config,UserManager<User> userManager,SignInManager<User> signinManager,IMapper mapper) 
    {
      _config = config;
      _userManager=userManager;
      _signinManager=signinManager;
      _mapper=mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
    {
      var userToCreate=_mapper.Map<User>(userForRegisterDto);
      var result=await _userManager.CreateAsync(userToCreate,userForRegisterDto.Password);
      var userToReturn=_mapper.Map<UserForDetailedDto>(userToCreate);
      if(result.Succeeded) {

        return CreatedAtRoute("GetUser",new { controller="Users",id=userToCreate.Id},userToReturn);
      }
      return BadRequest(result.Errors);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserForLogOnDto userForLogonDto)
    {
      userForLogonDto.UserName = userForLogonDto.UserName.ToLower();
      var user= await _userManager.FindByNameAsync(userForLogonDto.UserName);
      var result = await _signinManager.CheckPasswordSignInAsync(user,userForLogonDto.Password,false);

      if(result.Succeeded) {
            var appUser=_mapper.Map<UserForListDto>(user);
            return Ok(new {token = GenerateJwtToken(user),user=appUser});
      }

      return Unauthorized();
    }
    private string GenerateJwtToken(User user)
    {
      var claims = new[]
     {
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Name,user.UserName)
        };
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

      var credts = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddHours(24),
        SigningCredentials = credts
      };

      var tokenHandler = new JwtSecurityTokenHandler();

      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }

  }
}