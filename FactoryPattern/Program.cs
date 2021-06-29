using System;
using System.Text;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart();
            Console.WriteLine(cart.FinalizeOrder("SK", ""));

        }

    }

    public class ShoppingCart
    {

        public string FinalizeOrder(string DestinationCountry, string ShippingProvider)
        {
            if (DestinationCountry == "CR")
            {
                CzechPostShippingProvider czechProvider = new CzechPostShippingProvider("Lojza", "Klikař", "Úvoz 10, 60200, Brno", "Prepaid");
                return czechProvider.GenerateShippingLabel();
            }
            else if (DestinationCountry == "SK")
            {
                SlovakPostShippingProvider slovakProvider = new SlovakPostShippingProvider("Dežo", "Lakatoš", "Slovenská 654, 85622, Nové Zámky-Štůrovo", "Paid during delivery", 35);
                return slovakProvider.GenerateShippingLabel();
            }
            else
            {
                throw new Exception("Unknown destination country");
            }
        }
    }

    interface IShippingProvider
    {
        string GenerateShippingLabel();

    }


    class CzechPostShippingProvider : IShippingProvider
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _address;
        private readonly string _paymentOptions;

        public CzechPostShippingProvider(string FirstName, string LastName, string Address, string PaymentOptions)
        {
            _firstName = FirstName;
            _lastName = LastName;
            _address = Address;
            _paymentOptions = PaymentOptions;
        }
        public string GenerateShippingLabel() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{_firstName} {_lastName}");
            sb.AppendLine($"{_address}");
            sb.AppendLine($"Payment: {_paymentOptions}");
            return sb.ToString();
        }
    }


    class SlovakPostShippingProvider : IShippingProvider
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _address;
        private readonly string _paymentOptions;
        private readonly double _tax;

        public SlovakPostShippingProvider(string FirstName, string LastName, string Address, string PaymentOptions, double Tax)
        {
            _firstName = FirstName;
            _lastName = LastName;
            _address = Address;
            _paymentOptions = PaymentOptions;
            _tax = Tax;
        }
        public string GenerateShippingLabel() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{_lastName} {_firstName}");
            sb.AppendLine($"{_address}");
            sb.AppendLine($"Payment: {_paymentOptions}");
            sb.AppendLine($"Tax: {_tax}");
            return sb.ToString();
        }
    }


}
