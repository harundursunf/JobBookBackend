using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstarct;
using DataAccess.Context;
using DataAccess.Ef;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<DataAccessContext>(options =>                                                                                     
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors();

builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserDal, EFUserDal>();

builder.Services.AddScoped<IJobService, JobManager>();
builder.Services.AddScoped<IJobDal, EFJobDal>();  


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        c.RoutePrefix = string.Empty; // Swagger UI'yi ana sayfada açmak için
    });
}
app.UseCors(x=> x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.UseAuthorization();
app.MapControllers();
app.Run();
