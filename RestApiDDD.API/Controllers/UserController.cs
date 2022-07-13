﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApiDDD.Application.DTOs;
using RestApiDDD.Application.Interfaces;

namespace RestApiDDD.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserServiceApplication _userService;

    public UserController(IUserServiceApplication userService)
    {
        _userService = userService;
    }

    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(List<string>), 200)]
    [ProducesResponseType(typeof(List<UserDTO>), 200)]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid) return BadRequest();

        var result = await _userService.GetAll();
        return Ok(result);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(typeof(UserDTO), 200)]
    public async Task<IActionResult> GetById(int id)
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _userService.GetById(id);
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(UserDTO), 201)]
    public async Task<ActionResult> Create(UserDTO user)
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _userService.Add(user);
        return Created("", result);
    }

    [Authorize]
    [HttpPut]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<ActionResult> Update(UserDTO user)
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _userService.Update(user);
        return Ok(result);
    }

    [Authorize]
    [HttpDelete]
    [ProducesResponseType(typeof(string), 400)]
    [ProducesResponseType(typeof(string), 200)]
    public async Task<IActionResult> Delete(UserDTO user)
    {
        if (!ModelState.IsValid) return BadRequest();
        var result = await _userService.Remove(user);
        return Ok(result);
    }
}