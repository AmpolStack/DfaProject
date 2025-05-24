using Microsoft.AspNetCore.Mvc;
using ProjectDfa;
using ProjectDfa.Custom;
using ProjectDfa.Dfa;
using ProjectDfa.Dfa.RegexValidator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDfa<ValidateInputRequest, RegexStates>, RegexDfa>();

var app = builder.Build();

app.UseStaticFiles();
app.UseHttpsRedirection();

//If 'permanent' parameter is set the response code is 301, else is 302
app.MapGet("/", () => Results.Redirect("/home", permanent: true));

//For Frontend Endpoints
var components = new List<ViewRouteComponent>();
app.Configuration.GetSection("Components").Bind(components);

app.MapComponents(Directory.GetCurrentDirectory(), components);

//For backend endpoints
app.MapPost("/validate", ([FromBody] ValidateInputRequest request) => Results.Ok("ok"));

app.Run();

