var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

builder.Services.Configure<InfluxDbSettings>(builder.Configuration.GetSection("InfluxDb"));

// Register InfluxDBClient
builder.Services.AddSingleton<IInfluxDBClient, InfluxDBClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<InfluxDbSettings>>().Value;
    return new InfluxDBClient(settings.Url, settings.Token);
});

builder.Services.AddSignalR();

// Register hosted service
builder.Services.AddHostedService<DataCollectionService>();

builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddProblemDetails();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");

app.MapHub<SensorHub>("/sensorHub");


app.Run();