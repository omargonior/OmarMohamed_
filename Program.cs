
using System.Text;
using Bug_Ticketing_System.BL;
using Bug_Ticketing_System.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddBusinessServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region Identity
builder.Services.AddIdentityCore<User>(options =>
{
	options.Password.RequiredUniqueChars = 1;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireDigit = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireUppercase = false;
	options.Password.RequiredLength = 6;
	options.User.RequireUniqueEmail = true;
})
	.AddEntityFrameworkStores<BugDbContext>();
#endregion

#region Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		var secretKey = builder.Configuration.GetValue<string>("secretKey");
		var secretKeyInBytes = Encoding.UTF8.GetBytes(secretKey);
		var key = new SymmetricSecurityKey(secretKeyInBytes);

		options.TokenValidationParameters = new()
		{
			ValidateIssuer = false,
			ValidateAudience = false,
			IssuerSigningKey = key
		};
	});
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
