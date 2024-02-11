using Microsoft.EntityFrameworkCore;
using Subscriber.Data;
using Subscriber.WebApi.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;


builder.Services.AddControllers();
builder.Services.Configurations();

builder.Host.UseSerilog((context, configuration) =>
{

    configuration.ReadFrom.Configuration(context.Configuration);

});

builder.Services.AddDbContext<Weight_WatchersContext>(option =>
{
    
    option.UseSqlServer(builder.Configuration.GetConnectionString("Weight_WatchersConnectionString"), b => b.MigrationsAssembly("Weight_Watchers"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt => opt.AddPolicy("Policy", policy => {
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
})
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();
app.UseAuthorization();
app.UseCors("Policy");
app.MapControllers();
app.UseMiddleware(typeof(MiddleWare));
app.Run();
