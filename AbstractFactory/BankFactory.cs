using System;
using System.ComponentModel;

namespace AbstractFactory
{
    internal class BankFactory
    {
        public BankFactory()
        {
        }

        public  IBankServicesFactory CreateBankServicesFactory(ServiceType serviceType)
        {
            switch (serviceType)
            {
                case ServiceType.UNKNON:
                    throw new InvalidEnumArgumentException();
                case ServiceType.VIP:
                    return new PremiumBankServicesFactory();
                case ServiceType.P:
                    return new FreeBankServicesFactory();
                default:
                    throw new ArgumentOutOfRangeException(nameof(serviceType), serviceType, null);
            }
        }
    }
}