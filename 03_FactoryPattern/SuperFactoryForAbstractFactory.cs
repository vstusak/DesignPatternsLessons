using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_FactoryPattern
{
    public class SuperFactoryForAbstractFactory
    {
        public IBankServicesFactory CreateBankServicesFactory(BankServiceType serviceType)
        {
            IBankServicesFactory bankServicesFactory = null;

            switch (serviceType)
            {
                case BankServiceType.standard:
                    bankServicesFactory = new StandardBankServicesFactory();
                    break;
                case BankServiceType.premium:
                    bankServicesFactory = new PremiumBankServicesFactory();
                    break;
            }

            return bankServicesFactory;
        }
    }
}
