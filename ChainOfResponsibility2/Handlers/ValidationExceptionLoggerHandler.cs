﻿namespace ChainOfResponsibility2.Handlers;

public class ValidationExceptionLoggerHandler : ExceptionHandler, IExceptionLoggerHandler
{
    private readonly IBankNotesResource _resource;

    public ValidationExceptionLoggerHandler(IBankNotesResource resource)
    {
        _resource = resource;
    }

    public override void Handle(int balanceToPay, string handler, string message)
    {
        Console.WriteLine($"I'm logging exception from {handler}: {message}");
        base.Handle(balanceToPay, handler, message);
    }
}