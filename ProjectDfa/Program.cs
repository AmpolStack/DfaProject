using Microsoft.AspNetCore.Mvc;
using ProjectDfa;
using ProjectDfa.Custom;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseStaticFiles();
app.UseHttpsRedirection();

//If 'permanent' parameter is set the response code is 301, else is 302
app.MapGet("/", () => Results.Redirect("/home", permanent: true));

//For Frontend Endpoints
app.MapComponents(Directory.GetCurrentDirectory());

//For backend endpoints
app.MapPost("/validate", ([FromBody] ValidateInputRequest request) => Results.Ok("ok"));

app.Run();

