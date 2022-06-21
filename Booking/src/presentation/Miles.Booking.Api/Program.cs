using Miles.Booking.Api;

var builder = WebApplication.CreateBuilder(args);

#region add
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
#endregion

var app = builder.Build();

//add
startup.Configure(app, app.Environment);

app.Run();
