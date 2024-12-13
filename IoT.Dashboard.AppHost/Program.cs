var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.IoT_Dashboard_SensorDataAPI>("apiservice");

builder.AddProject<Projects.IoT_Dashboard_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
