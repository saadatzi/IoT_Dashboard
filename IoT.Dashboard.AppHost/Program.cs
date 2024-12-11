var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.IoT_Dashboard_SensorDataAPI>("apiservice");

var redis = builder.AddRedis("redis");

builder.AddProject<Projects.IoT_Dashboard_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(redis)
    .WaitFor(apiService);

builder.Build().Run();
