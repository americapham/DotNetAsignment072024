﻿using AutoMapper;
using Bosch.Events.UseCases.DTOs.RoleDtos;
using Bosch.Events.UseCases.Features.Roles.Commands.CreateRole;
using Bosch.Events.UseCases.Features.Roles.Queries.GetAllRoles;
using Bosch.Events.UseCases.Features.Roles.Queries.GetRoleDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bosch.Events.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoschRolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BoschRolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<RoleDto>>> Get()
        {
            try
            {
                var roles = await _mediator.Send(new GetAllRolesQuery());
                if (roles == null || roles.Count == 0)
                {
                    return NotFound(new { Message = "Sorry! No Roles Found!" });
                }
                return Ok(roles);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<RoleDto>>> GetDetails(int id)
        {
            try
            {
                var role = await _mediator.Send(new GetEventDetailsQuery() { RoleId=id});
                if (role == null )
                {
                    return NotFound(new { Message = "Sorry! No Roles Found!" });
                }
                return Ok(role);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RoleDto>> Post(InsertRoleDto role)
        {
            if (ModelState.IsValid)
            {
                int result = await _mediator.Send(new CreateRoleCommand() { Role = role });
                if (result > 0)
                {
                    return Created("GetDetails", role);
                }
            }
            return BadRequest(new {Message="Role Creation Failed! Please retry!"});
        }
    }
}
