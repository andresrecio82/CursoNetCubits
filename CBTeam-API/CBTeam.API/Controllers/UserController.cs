using CBTeam.Application.Contracts;
using CBTeam.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CBTeam.API.Controllers
{
	[ApiController]
	[Route("/api/User")]
	public class UserController: ControllerBase
	{
		private readonly IMediator _mediator;

		public UserController(IMediator mediator)
		{
			this._mediator = mediator;
		}

		[HttpGet]
		[Route("")]
		public async Task<IActionResult> GetList([FromQuery] GetUserListRequest request) 
		{
			var response = await _mediator.Send(request);
			return Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		public IActionResult Get(int id)
		{
			return Ok();
		}

	}
}
