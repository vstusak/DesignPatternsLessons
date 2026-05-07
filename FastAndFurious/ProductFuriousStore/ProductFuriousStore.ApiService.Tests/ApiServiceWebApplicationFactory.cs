using Microsoft.AspNetCore.Mvc.Testing;

namespace ProductFuriousStore.ApiService.Tests;

/// <summary>
/// Custom WebApplicationFactory for integration testing the API service.
/// </summary>
public class ApiServiceWebApplicationFactory : WebApplicationFactory<Program>;
