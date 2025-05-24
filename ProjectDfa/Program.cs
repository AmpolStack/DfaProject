using Microsoft.AspNetCore.Mvc;
using ProjectDfa.RequestObjects;
using ProjectDfa.Views;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

//If 'permanent' parameter is set the response code is 301, else is 302
app.MapGet("/", () => Results.Redirect("/home", permanent: true));

//For Frontend Endpoints
app.MapGet("/home", () => Results.Content(IndexView.Build(), "text/html; charset=utf-8"));

app.MapGet("/regex", () => Results.Content(RegexView.Build(), "text/html; charset=utf-8"));


//For backend endpoints
app.MapPost("/validate", ([FromBody] RegexRequest request) => Results.Ok("ok"));

app.Run();

