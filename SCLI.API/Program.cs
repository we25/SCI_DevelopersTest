using Microsoft.EntityFrameworkCore;
using SCLI.Application.Contacts.Presisence;
using SCLI.Application.Contracts;
using SCLI.Application.Contracts.IRepository.Lookups;
using SCLI.Application.Contracts.IRepository.Operation;
using SCLI.Application.Contracts.IRepository.SystemCodes;
using SCLI.Application.Services;
using SCLI.Infrastructure;
using SCLI.Infrastructure.BaseRepositoryAsync;
using SCLI.Infrastructure.RepositoryAsync.Lookups;
using SCLI.Infrastructure.RepositoryAsync.Operation;
using SCLI.Infrastructure.RepositoryAsync.SystemCodes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<SCLIAppContext>();
builder.Services.AddTransient(typeof(IBaseRepositoryAsync<>), typeof(BaseRepositoryAsync<>));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContextPool<SCLIAppContext>(options =>
{
    options.UseSqlServer(new ConfigurationManager().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection"));
});

#region EntityRepository
builder.Services.AddScoped<IDepartmentRepositoryAsync, DepartmentRepositoryAsync>();
builder.Services.AddScoped<IJobTitleRepositoryAsync, JobTitleRepositoryAsync>();
builder.Services.AddScoped<IEmployeeRepositoryAsync, EmployeeRepositoryAsync>();
builder.Services.AddScoped<ISystemCodeRepositoryAsync, SystemCodeRepositoryAsync>();
//builder.Services.AddScoped<, >();
#endregion

#region AppService
builder.Services.AddScoped<IDepartmentAppService, DepartmentAppService>();
builder.Services.AddScoped<IJobTitleAppService, JobTitleAppService>();
builder.Services.AddScoped<IEmployeeAppService, EmployeeAppService>();
builder.Services.AddScoped<ISystemCodeAppService, SystemCodeAppService>();
//builder.Services.AddScoped<, >();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
