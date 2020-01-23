using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly IDatingRepository _repo;

    private readonly IMapper _mapper;
    public UsersController(IDatingRepository repo, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
      var users = await _repo.GetUsersAsync();
      var userstoReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

      return Ok(userstoReturn);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
      var user = await _repo.GetUserAsync(id);
      var usertoReturn = _mapper.Map<UserForDetailedDto>(user);
      return Ok(usertoReturn);
    }
  }
}