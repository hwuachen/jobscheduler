using Hangfire;
using Microsoft.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add Hangfire to the container
//builder.Services.AddHangfire(x => x.UseSqlServerStorage(<your data soruce>));
builder.Services.AddHangfire(x => x.UseSqlServerStorage(<your data source>);
builder.Services.AddHangfireServer();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add HangfireDashboard to the HTTP request pipeline.
app.UseHangfireDashboard("/jobscheduler"
//, new DashboardOptions {   Authorization = new[] { new HangfireAuthorizationFilter()}}
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
