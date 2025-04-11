using Bug_Ticketing_System.BL.DTOs.User;
using Bug_Ticketing_System.DAL;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bug_Ticketing_System.Controllers
{
	[ApiController]
	[Route("api/users")]
	public class UserController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly UserManager<User> _userManager;
		private readonly IUnitOfWork _unitOfWork;

		public UserController(IConfiguration configuration,
			UserManager<User> userManager
			, IUnitOfWork unitOfWork)
		{
			_configuration = configuration;
			_userManager = userManager;
			_unitOfWork = unitOfWork;
		}

		[HttpPost]
		[Route("login")]
		public async Task<Results<Ok<TokenDto>, UnauthorizedHttpResult>>
				Login(LoginCredentials credentials)
		{
			var user = await _userManager.FindByNameAsync(credentials.UserName);
			if (user == null)
			{
				return TypedResults.Unauthorized();
			}
			var isPasswordValid = await _userManager.CheckPasswordAsync(user, credentials.Password);
			if (!isPasswordValid)
			{
				return TypedResults.Unauthorized();
			}
			var claims = await _userManager.GetClaimsAsync(user);
			var tokenDto = GenerateTokenAsync(claims.ToList());

			return TypedResults.Ok(tokenDto);
		}
		//////////////////////////////////////////////////////////////////////////////////////////////
		[HttpPost]
		[Route("register")]
		public async Task<Results<NoContent, BadRequest<List<string>>>>
				Register(RegisterDto registerDto)
		{
			var user = new User
			{
				UserName = registerDto.UserName,
				Email = registerDto.Email,
			};
			var creationResult = await _userManager.CreateAsync(user, registerDto.Password);
			if (!creationResult.Succeeded)
			{
				var errors = creationResult.Errors
					.Select(e => e.Description)
					.ToList();
				return TypedResults.BadRequest(errors);
			}

			var claims = new List<Claim>
			{
				new(ClaimTypes.NameIdentifier,user.Id),
				new(ClaimTypes.Email,user.Email),
			};

			await _userManager.AddClaimsAsync(user, claims);
			

			
			await _unitOfWork.CompleteAsync();
			return TypedResults.NoContent();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////////
		private TokenDto GenerateTokenAsync(List<Claim> claims)
		{
			var secretKey = _configuration.GetValue<string>("secretKey");
			var secretKeyInBytes = Encoding.UTF8.GetBytes(secretKey);
			var key = new SymmetricSecurityKey(secretKeyInBytes);

			var token = new JwtSecurityToken(
				expires: DateTime.Now.AddHours(1),
				claims: claims,
				signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
				);

			var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
			return new TokenDto(tokenString, token.ValidTo);
		}
	}
}
