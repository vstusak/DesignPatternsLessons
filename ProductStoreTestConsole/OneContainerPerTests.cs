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


        [TestMethod]
        public async Task TestInsertAsync()
        {
            var personName = "Test Person";
            var person = new Person { Name = personName, Age = 30 }; 
            var result = await _peopleRepository.InsertAsync(person);
            Assert.AreNotEqual(0, result.Id);
            Assert.AreEqual(personName, result.Name);
            var people = await _peopleRepository.GetAllAsync();
            Assert.AreEqual(1, people.Count);
            Assert.AreEqual(personName, people[0].Name);
        }

        [TestMethod]
        public async Task TestGetAllAsync()
        {

        }

        [TestMethod]
        public async Task TestInsertMoreAsync()
        {

        }
    }
}
