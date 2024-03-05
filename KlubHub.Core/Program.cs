using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using KlubHub.Data;
using KlubHub.Repository;
using KlubHub.Service;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["sqlConnection"];
//var databaseName = builder.Configuration["sqlConnection"];
//builder.Services.AddDbContext<KlubHubDbContext>(options =>
//    options.UseCosmos(
//        connectionString,
//        databaseName
//    ));
builder.Services.AddDbContext<KlubHubDbContext>(options =>
    options.UseSqlServer(
        connectionString        
    ));
// Add services to the container.

//add jwt
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;    
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        //ValidAudience = builder.Configuration["JwtSettings:Audience"],
        ValidAudience = builder.Configuration["JwtSettings:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!)),
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
};
});

builder.Services.AddAuthorization();

builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IMemberRoleRepository, MemberRoleRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();


builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IMemberRoleService, MemberRoleService>();
builder.Services.AddScoped<IMemberService, MemberService>();





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "localPolicy",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200/", "*").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

builder.Services.ConfigureSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Three in one Store",
        Version = "v1"
    });
});

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("localPolicy");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
