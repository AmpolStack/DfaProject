using Microsoft.AspNetCore.Mvc;
using ProjectDfa;
using ProjectDfa.Custom;
using ProjectDfa.Dfa;
using ProjectDfa.Dfa.Implementations;
using ProjectDfa.Dfa.Inputs;
using ProjectDfa.Dfa.States;
using ProjectDfa.Services.Definitions;
using ProjectDfa.Services.Implementations;

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
    if(!result)
    {
        return Results.BadRequest(new ProcessResponse()
        {
            Message = "La entrada no cumple con los criterios especificados.",
            Result = false
        });
    }

    return Results.Ok(new ProcessResponse()
    {
        Message = "¡Validación exitosa! La entrada cumple con los criterios.",
        Result = true
    });
});

app.MapGet("/machine/insertCoin", async (
    [FromServices] IMachineService service) =>
{
    var result = await service.ExecuteInsertCoin();
    return GetMachineResult(result, "Moneda insertada correctamente.");
});

app.MapGet("/machine/selectProduct", async ([FromQuery] string name,
    [FromServices] IMachineService service) =>
{
    var result = await service.ExecuteSelectProduct();
    return GetMachineResult(result, $"Producto {name} seleccionado.");
});

app.MapGet("/machine/requestChange", async (
    [FromServices] IMachineService service) =>
{
    var result = await service.ExecuteRequestChange();
    return GetMachineResult(result, "Cambio expedido correctamente.");
});

app.MapGet("/machine/dispense", async (
    [FromServices] IMachineService service) =>
{
    var result = await service.ExecuteDispense();
    return GetMachineResult(result, "Producto dispensado correctamente.");
});


app.Run();


static IResult GetMachineResult(bool result, string successMessage)
    {
        if(!result){
           return Results.BadRequest(new ProcessResponse()
            {
                Message = "Operación Invalida, el estado no cambia.",
                Result = false 
            });
        }
    
        return Results.Ok(new ProcessResponse()
        {
            Message = successMessage,
            Result = true 
        }); 
    }

