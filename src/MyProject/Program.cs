using MyProject;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/ping", () =>
{
  var pong = new Hello().HelloWorld();
  
  Console.WriteLine("Returning response {0}", pong);

  return pong;
});


app.Run();
