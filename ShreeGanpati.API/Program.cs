using ShreeGanpati.API.Data;
using Microsoft.EntityFrameworkCore;
using ShreeGanpati.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<TokenService>().AddTransient<PaswordService>();
builder.Services.AddAuthentication(options =>
{

    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwtOptions => {
    jwtOptions.TokenValidationParameters = TokenService.GetTokenValidationParameters(builder.Configuration);
});

builder.Services.AddAuthentication();


var connectionstring = builder.Configuration.GetConnectionString("constring");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionstring));
//builder.Services.AddDbContext<DataContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString
//    ("constring"));
//});
var app = builder.Build();
#if DEBUG
MigrationDatabase(app.Services);
#endif
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();

static void MigrationDatabase(IServiceProvider sp) 
{

    var scope = sp.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    if(dataContext.Database.GetPendingMigrations().Any()) dataContext.Database.Migrate();
}