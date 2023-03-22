using ChainOfResponsibility2.Handlers;

public class ExceptionChainFactory:IExceptionHandlerFactory
{
    private BankNotesResource _resource;

    public ExceptionChainFactory(BankNotesResource resource)
    {
        _resource = resource;
    }

    public IExceptionHandler GetLoggerExceptionHandler()
    {
        return new ValidationExceptionLoggerHandler(_resource);
    }

    public IExceptionHandler GetNotificationExceptionHandler()
    {
        return new ValidationExceptionNotificatorHandler(_resource);
    }

    public IExceptionHandler GetLoggerAndNotificationExceptionChainHandler()
    {
        var logger = new ValidationExceptionLoggerHandler(_resource);
        var notification = new ValidationExceptionNotificatorHandler(_resource);

        logger.SetNext(notification);

        return logger;
    }
}