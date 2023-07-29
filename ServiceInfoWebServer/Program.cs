using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceInfoWebServer.Contexts;
using ServiceInfoWebServer.Managers;
using ServiceInfoWebServer.Mapper;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServiceInfoManager, ServiceInfoManager>();
builder.Services.AddAutoMapper(typeof(AppMappingProfile));
string connection = builder.Configuration.GetConnectionString("ServiceInfoContext");
builder.Services.AddDbContext<ServiceInfoContext>(options => options.UseSqlite(connection));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}


app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();