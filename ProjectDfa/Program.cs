using Microsoft.AspNetCore.Mvc;
using ProjectDfa;
using ProjectDfa.Custom;
using ProjectDfa.Dfa;
using ProjectDfa.Dfa.EmailValidator;
using ProjectDfa.Dfa.RegexValidator;
using ProjectDfa.Dfa.VendingMachine;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDfa<ValidateInputRequest, char, RegexValidatorStates>, RegexValidatorDfa>();
builder.Services.AddScoped<IDfa<EmailValidatorStates, char>, EmailValidatorDfa>();
builder.Services.AddScoped<IValidatorService, ValidatorService>();
builder.Services.AddScoped<IDfa<VendingMachineStates, VendingMachineInputs>, VendingMachineDfa>();
builder.Services.AddScoped<IMachineService, MachineService>();

var app = builder.Build();

app.UseHttpsRedirection();

//If 'permanent' parameter is set the response code is 301, else is 302
app.MapGet("/", () => Results.Redirect("/home", permanent: true));

//For Frontend Endpoints
var components = new List<ViewRouteComponent>();
app.Configuration.GetSection("Components").Bind(components);

app.MapComponents(Directory.GetCurrentDirectory(), components);

//For backend endpoints
app.MapPost("/validate", ([FromBody] ValidateInputRequest request,
    [FromServices] IValidatorService service) =>
{
    var result = service.Validate(request);
    return result.Equals(false) ? Results.BadRequest("The request is invalid") : Results.Ok("The request is valid");
});

app.MapGet("/machine/insertCoin", async (
    [FromServices] IMachineService service) =>
{
    var result = await service.ExecuteInsertCoin();
    return result ? Results.Ok() : Results.BadRequest("The request is invalid");
});

app.MapGet("/machine/selectProduct", async (
    [FromServices] IMachineService service) =>
{
    var result = await service.ExecuteSelectProduct();
    return result ? Results.Ok() : Results.BadRequest("The request is invalid");
});

app.MapGet("/machine/requestChange", async (
    [FromServices] IMachineService service) =>
{
    var result = await service.ExecuteRequestChange();
    return result ? Results.Ok() : Results.BadRequest("The request is invalid");
});

app.MapGet("/machine/wait", async (
    [FromServices] IMachineService service) =>
{
    var result = await service.ExecuteDispense();
    return result ? Results.Ok() : Results.BadRequest("The request is invalid");
});


app.Run();

