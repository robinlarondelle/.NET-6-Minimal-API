# .NET-6-Minimal-API
Just a small repo to test some new Minimal API functionality from the new .NET 6 release

Just look at how small that `Program.cs` is, isn't it cute?


## EndpointDefinitions
The available endpoints are dynamically added using an Assembly scan, which searches for all `IEndpointDefinition` implementations. Using this, we can clean up our `IHostBuilder` and Depencency Injection registration.
