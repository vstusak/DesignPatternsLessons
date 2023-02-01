﻿using ChainOfResponsibility1.Entities;

namespace ChainOfResponsibility1.Handlers
{
    public class AdultValidationHandler:Handler<Person>
    {
        public override void Handle(Person request)
        {

            if (request.DateOfBirth.AddYears(18) < DateTime.Now)
            {
                throw new ArgumentNullException(nameof(request.Name));
            }

            base.Handle(request);
        }
    }
}
