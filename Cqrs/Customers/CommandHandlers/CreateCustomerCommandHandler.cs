using System.Threading.Tasks;
using CQRS.Customers.Commands;
using RepositoryPattern.Context;

namespace CQRS.Customers.CommandHandlers
{
    public class CreateCustomerCommandHandler : ICreateCustomerCommandHandler
    {
        private readonly WarehouseContext _context;

        public CreateCustomerCommandHandler(WarehouseContext context)
        {
            _context = context;
        }

        public async Task Execute(CreateCustomerCommand command)
        {
            var customer = new Customer
            {
                FirstName = command.FirstName,
                Surname = command.Surname,
            };

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
    }
}
