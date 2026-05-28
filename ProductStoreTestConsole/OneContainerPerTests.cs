using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testcontainers.MsSql;

namespace ProductStoreTestConsole
{
    //TODO: write tests
    [TestClass]
    public class OneContainerPerTests
    {
        private MsSqlContainer _sqlContainer;
        private PersonDBContext _dbContext;
        private PeopleRepository _peopleRepository;

        [TestInitialize]
        public async Task InitializeAsync() {
            _sqlContainer = new MsSqlBuilder("mcr.microsoft.com/mssql/server:2022-CU14-ubuntu-22.04")
                .Build();

            await _sqlContainer.StartAsync();

            Console.WriteLine($"SQL Container started! Connection string: {_sqlContainer.GetConnectionString()}");

            var connectionString = _sqlContainer.GetConnectionString();
            var options = new DbContextOptionsBuilder<PersonDBContext>()
                .UseSqlServer(connectionString)
                .Options;

            _dbContext = new PersonDBContext(options);

            await _dbContext.Database.EnsureCreatedAsync();

            _peopleRepository = new PeopleRepository(_dbContext);
        }

        [TestCleanup]
        public async Task CleanupAsync() {
            await _sqlContainer.DisposeAsync();
            await _dbContext.DisposeAsync();
        }
    }
}
