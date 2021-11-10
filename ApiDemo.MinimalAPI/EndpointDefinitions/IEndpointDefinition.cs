﻿
namespace ApiDemo.MinimalAPI.EndpointDefinitions
{
    public interface IEndpointDefinition
    {
        void DefineServices(IServiceCollection services);
        void DefineEndpoints(WebApplication app);
    }
}