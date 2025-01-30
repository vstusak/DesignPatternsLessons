

/*
  Regular customer
   - Regular account
   - Debet card
||
   - Savings acc
   - None card

   Authorized customer
   - Credit account
   - Credit card

   Businessman
   - FeesFree acc
   - Credit card

   Regular -> Debet card (Regular customer)
   Savings -> None (Regular customer with regular account)
   Credit -> Credit card (Authorized customer),
   FeesFree -> Credit card (businessman)
*/

using AbstractFactory;

var customer = new Customer()
{
    CustomerType = CustomerType.Regular,
    Name = "Pepa"
};

var account = GetAccount(customer.CustomerType);

var card = GetCard(customer.CustomerType);

var customerAccount = new CustomerAccount
{
    Account = account,
    Card = card,
    Customer = customer
};

Account GetAccount(CustomerType customerType)
{
    switch (customerType)
    {
        case CustomerType.Undefined:
            break;
        case CustomerType.Regular:
            break;
        case CustomerType.Authorized:
            break;
        case CustomerType.Businessman:
            break;
        default:
            throw new ArgumentOutOfRangeException(nameof(customerType), customerType, null);
    }
}

Card GetCard(CustomerType customerType)
{
    switch (customerType)
    {
        case CustomerType.Undefined:
        case CustomerType.Regular:
        case CustomerType.Authorized:
        case CustomerType.Businessman:
        default:
            throw new ArgumentOutOfRangeException(nameof(customerType), customerType, null);
    }
}