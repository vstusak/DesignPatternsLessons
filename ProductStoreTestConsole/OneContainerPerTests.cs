using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testcontainers.MsSql;

namespace ProductStoreTestConsole
{

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
            var noPeople = await _peopleRepository.GetAllAsync();
            Assert.AreEqual(0, noPeople.Count);
        }

        [TestMethod]
        public async Task TestInsertMoreAsync()
        {
            var person1 = new Person { Name = "Person 1", Age = 25 };
            var person2 = new Person { Name = "Person 2", Age = 30 };
            var person3 = new Person { Name = "Person 3", Age = 35 };

            await _peopleRepository.InsertAsync(person1);
            await _peopleRepository.InsertAsync(person2);
            await _peopleRepository.InsertAsync(person3);

            var people = await _peopleRepository.GetAllAsync();
            Assert.AreEqual(3, people.Count);
            Assert.AreEqual("Person 1", people[0].Name);
            Assert.AreEqual("Person 2", people[1].Name);
            Assert.AreEqual("Person 3", people[2].Name);
        }
    }

    [TestClass]
    public class SharedContainerForAllTests
    {
        private static MsSqlContainer _sqlContainer;
        private PersonDBContext _dbContext;
        private PeopleRepository _peopleRepository;

        [ClassInitialize]
        public static async Task ClassInitialize(TestContext context)
        {
            _sqlContainer = new MsSqlBuilder("mcr.microsoft.com/mssql/server:2022-CU14-ubuntu-22.04")
            .Build();

            await _sqlContainer.StartAsync(context.CancellationToken);
        }

        [TestInitialize]
        public async Task InitializeAsync()
        {
            Console.WriteLine($"SQL Container started! Connection string: {_sqlContainer.GetConnectionString()}");

            var connectionString = _sqlContainer.GetConnectionString().Replace("Database=master", "Database=PersonDB");
            var options = new DbContextOptionsBuilder<PersonDBContext>()
                .UseSqlServer(connectionString)
                .Options;

            _dbContext = new PersonDBContext(options);

            await _dbContext.Database.EnsureDeletedAsync();
            await _dbContext.Database.EnsureCreatedAsync();

            _peopleRepository = new PeopleRepository(_dbContext);
        }

        [TestCleanup]
        public async Task CleanupAsync()
        {
            await _dbContext.DisposeAsync();
        }

        [ClassCleanup]
        public static async Task ClassCleanupAsync()
        {
            await _sqlContainer.DisposeAsync();
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
            var noPeople = await _peopleRepository.GetAllAsync();
            Assert.AreEqual(0, noPeople.Count);
        }

        [TestMethod]
        public async Task TestInsertMoreAsync()
        {
            var person1 = new Person { Name = "Person 1", Age = 25 };
            var person2 = new Person { Name = "Person 2", Age = 30 };
            var person3 = new Person { Name = "Person 3", Age = 35 };

            await _peopleRepository.InsertAsync(person1);
            await _peopleRepository.InsertAsync(person2);
            await _peopleRepository.InsertAsync(person3);

            var people = await _peopleRepository.GetAllAsync();
            Assert.AreEqual(3, people.Count);
            Assert.AreEqual("Person 1", people[0].Name);
            Assert.AreEqual("Person 2", people[1].Name);
            Assert.AreEqual("Person 3", people[2].Name);
        }
    }
}
