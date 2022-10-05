using Microsoft.AspNetCore.Mvc;
using MinimalAPI_Basics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IService, Service>();

var app = builder.Build();

app.Urls.Add("https://localhost:9000");

//API Endpoints 

app.MapGet("/", () => "Hello From Get Method");
app.MapPost("/", () => "Hello From Post Method");
app.MapPut("/", () => "Hello From Put Method");
app.MapDelete("/", () => "Hello From Delete Method");



//##ROUTE HANDLERS//

//Lambda Expression
app.MapGet("/routeHandlers/lambda", () => "Hello from Lambda Expression!");

//Local Function
var localFunction = () => "Hello from Local Function!";
app.MapGet("/routeHandlers/localFunction", localFunction);

//Instance Method
Hello hello = new Hello();
app.MapGet("/routeHandlers/instance", hello.Message);

//Static Method
app.MapGet("/routeHandlers/static", HelloStatic.Message);

app.MapGet("/parameterBinding/{routeValue}", ([FromRoute] string routeValue,
    [FromQuery] string queryString, [FromHeader] string fromHeader,
    [FromBody] Task task, [FromServices] IService service) =>
{
    return new
    {
        FromRoute = routeValue,
        FromQuery = queryString,
        FromHeader = fromHeader,
        FromBody = task,
        FromService = service.GetNames()
    };
});

app.MapGet("/JSON", () => Results.Json(new { Message = "This is a JSON Result" }));
app.MapGet("/IResult", (IService service) => Results.Ok(service.GetNames()));

app.Run();

//Instance Method
class Hello
{
    public string Message()
    {
        return "Hello from Instance Method";
    }
}

//Static Method
class HelloStatic
{
    public static string Message()
    {
        return "Hello from Static Method";
    }
}

class Task
{
    public string TaskName { get; set; }
    public bool IsCompleted { get; set; }
}


