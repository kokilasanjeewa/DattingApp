﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
  //GET method https://localhost:5001/api/controllername/
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    private readonly OwnerConsumer _consumer;
    private readonly DataContext _context;
    public ValuesController(DataContext context, OwnerConsumer consumer)
    {
      _context = context;
      _consumer = consumer;
    }
    //GET method https://localhost:5001/api/controllername/
    // GET api/values
    //default program code
    /*    public ActionResult<IEnumerable<string>> Get()
    {
        var values=_context.Values.ToList();
      //return new string[] { "value0", "value1" };
        return Ok(values);
    }*/
     [AllowAnonymous]
     [HttpGet]
    public async Task<IActionResult> Get()
    {
        var owners = await _consumer.GetAllOwners();
        return Ok(owners);
    }
     [AllowAnonymous]
     [HttpPost]
    public async Task<IActionResult> Create()
    {
        var owners = await _consumer.GetAllOwners();
        return Ok(owners);
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetValues()
    {
      var values = await _context.Values.ToListAsync();
      return Ok(values);
    }
    //GET method https://localhost:5001/api/controllername/parametervalue
    // GET api/values/5
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetValue(int id)
    {
      var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
      return Ok(value);

    }
    /* public ActionResult<string> Get(int id)
     {
       return "value";
     }*/
    //POST method https://localhost:5001/api/controllername/
    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }
    //UPDATE method https://localhost:5001/api/controllername/parametervalue
    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }
    //DELETE method https://localhost:5001/api/controllername/parametervalue
    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
