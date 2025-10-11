using Microsoft.AspNetCore.Mvc.Testing;
using Planner.Api;
using TUnit.Core.Interfaces;

namespace Planner.Tests;

public class WebApplicationFactory : WebApplicationFactory<Program>, IAsyncInitializer
{
    public Task InitializeAsync()
    {
        _ = Server;

        return Task.CompletedTask;
    }
}
