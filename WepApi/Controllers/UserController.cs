﻿using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTO;

namespace WepApi.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
  private readonly IUserLogic userLogic;

  public UserController(IUserLogic userLogic)
  {
    this.userLogic = userLogic;
  }
  
  [HttpPost]
  public async Task<ActionResult<User>> CreateAsync(UserCreationDto dto)
  {
    try
    {
      User user = await userLogic.CreateAsync(dto);
      return Created($"/users/{user.Id}", user);
    }
    catch (Exception e)
    {
      Console.WriteLine(e);
      return StatusCode(500, e.Message);
    }
  }

}