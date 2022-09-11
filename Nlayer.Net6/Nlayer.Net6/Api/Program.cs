
using Api.Filters;
using Api.Middlewares;
using Api.Modules;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Repositories;
using Repository.UnitOfWorks;
using Service.Services;
using Service.Services.Mapping;
using Service.Validations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
//Fluent api DI 
//Filter genel olarak ValidateAttribute kurtulma classlarýn tepesine yazmamak için 
builder.Services.AddControllers(options =>
options.Filters.Add(new ValidateFilterAttiribute())).
AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtValidator>());

//api tarafýnda gelen diðer hatalarýnda baskýlanmasý sadece filterda gösterilmesi istenilen hatayý gösterme 
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//notfound filter için
builder.Services.AddScoped(typeof(NotFoundFilter<>));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));

//connection string 
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConn"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

//autofac di
builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));


//cache memorycache 

builder.Services.AddMemoryCache();

//autofac tarafýnda implement edildi.
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped(typeof(IService<>), typeof(Service<>)); 

//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IProductService, ProductService>();

//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

//global handler 
app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();



