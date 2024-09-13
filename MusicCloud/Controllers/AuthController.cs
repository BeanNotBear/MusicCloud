using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicCloud.API.Models.Dto;

namespace MusicCloud.API.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<IdentityUser> userManager;

		public AuthController(UserManager<IdentityUser> userManager)
		{
			this.userManager = userManager;
		}

		[HttpPost]
		[Route("register")]
		public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequest)
		{
			var identityUser = new IdentityUser
			{
				UserName = registerRequest.Username,
				Email = registerRequest.Email
			};

			var identityResult = await userManager.CreateAsync(identityUser, registerRequest.Password);

			if (identityResult.Succeeded)
			{
				// Add roles for user
				if (registerRequest.Roles != null && registerRequest.Roles.Any())
				{
					identityResult = await userManager.AddToRolesAsync(identityUser, registerRequest.Roles);

					if (identityResult.Succeeded)
					{
						return Created();
					}
				}
			}
			return BadRequest("Something went wrong!");
		}
	}
}
