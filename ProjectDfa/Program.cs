using Microsoft.AspNetCore.Mvc;
using ProjectDfa.RequestObjects;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseDefaultFiles();     // finds index.html automatically
app.UseStaticFiles();   

//For backend endpoints
app.MapPost("/validate", ([FromBody] RegexRequest request) => Results.Ok("ok"));

app.Run();

