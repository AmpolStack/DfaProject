using Microsoft.AspNetCore.Mvc;
using src;
using src.Custom;
using src.Dfa;
using src.Dfa.Implementations;
using src.Dfa.Inputs;
using src.Dfa.States;
using src.Services.Definitions;
using src.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add CORS configuration
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("LocalhostPolicy", policy =>
//     {
//         policy.WithOrigins($"https://localhost:{port}") // The port should match your launchSettings.json
//              .AllowAnyMethod()
//              .AllowAnyHeader()
//              .WithExposedHeaders("*");
//     });
// });

builder.Services.AddScoped<IDfa<ValidateInputRequest, char, RegexValidatorStates>, RegexValidatorDfa>();
builder.Services.AddScoped<IDfa<EmailValidatorStates, char>, EmailValidatorDfa>();
builder.Services.AddScoped<IValidatorService, ValidatorService>();
builder.Services.AddScoped<IDfa<VendingMachineStates, VendingMachineInputs>, VendingMachineDfa>();
builder.Services.AddScoped<IMachineService, MachineService>();

var app = builder.Build();

// var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
// app.Urls.Add($"http://*:{port}");

app.UseHttpsRedirection();

// Enable CORS
// app.UseCors("LocalhostPolicy");

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

app.MapPost("/machine/insertCoin/{state}", async (
    [FromServices] IMachineService service,
    [FromRoute] VendingMachineStates state) =>
{
    var result = await service.ExecuteInsertCoin(state, out var newState);
    return GetMachineResultWithData(result, "Moneda insertada correctamente.", newState);
});

app.MapPost("/machine/selectProduct/{name}/{state}", async ([FromRoute] string name,
    [FromRoute] VendingMachineStates state,
    [FromServices] IMachineService service) =>
{
    var result = await service.ExecuteSelectProduct(state, out var newState);
    return GetMachineResultWithData(result, $"Producto {name} seleccionado.", newState);
});

app.MapPost("/machine/requestChange/{state}", async (
    [FromRoute] VendingMachineStates state,
    [FromServices] IMachineService service) =>
{
    var result = await service.ExecuteRequestChange(state, out var newState);
    return GetMachineResultWithData(result, "Cambio expedido correctamente.", newState);
});

app.MapPost("/machine/dispense/{state}", async (
    [FromRoute] VendingMachineStates state,
    [FromServices] IMachineService service) =>
{
    var result = await service.ExecuteDispense(state, out var newState);
    return GetMachineResultWithData(result, "Producto dispensado correctamente.", newState);
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

static IResult GetMachineResultWithData(bool result, string successMessage, VendingMachineStates state)
{
    if(!result){
        return Results.BadRequest(new ProcessResponse()
        {
            Message = "Operación Invalida, el estado no cambia.",
            Result = false,
            
        });
    }
    
    return Results.Ok(new ProcessResponse<string>()
    {
        Message = successMessage,
        Result = true,
        Data = state.ToString()
    }); 
}


