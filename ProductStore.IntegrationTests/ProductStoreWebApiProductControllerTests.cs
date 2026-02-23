using Testcontainers.MsSql;
using Xunit;

namespace ProductStore.IntegrationTests
{
    public class ProductStoreWebApiProductControllerTests: IAsyncLifetime    
    {
        private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder("mcr.microsoft.com/mssql/server:2025-latest").Build();

        public Task InitializeAsync()
        {
            return _msSqlContainer.StartAsync();
        }

        public Task DisposeAsync()
        {
            return _msSqlContainer.DisposeAsync().AsTask();
        }
    }
}
