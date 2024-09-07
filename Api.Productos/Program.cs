using Api.Domain.Interfaces;
using Api.Domain.Services;
using Api.Infrastructure.Data;
using ChatBot_Test.Mappings;
using ChatBot_Test.Middlewares;
using Microsoft.EntityFrameworkCore;
using Sentry;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductsContext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.WebHost.UseSentry(options =>
{
    options.Dsn = "https://9d3a3fd56906bc0a996243056719a0df@o4507909615845376.ingest.us.sentry.io/4507909617745920"; 
    options.Debug = true;
    options.TracesSampleRate = 1.0; 
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductstService, ProductsService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProductsContext>();
    dbContext.Database.Migrate();
}

// Swager para cuando esta desplegado porque no funco
if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Diosito que esta ves si sirva");
        c.RoutePrefix = string.Empty;
    });
}

app.UseSentryTracing();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<DtoValidationMiddleware>();
app.Run();