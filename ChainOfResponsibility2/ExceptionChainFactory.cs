using ChainOfResponsibility2.Handlers;

public class ExceptionChainFactory:IExceptionHandlerFactory
{
    private readonly IExceptionHandler _exceptionLoggerHandler;
    private readonly IExceptionHandler _exceptionNotificationHandler;

    public ExceptionChainFactory(IExceptionLoggerHandler exceptionLoggerHandler, IExceptionNotificationHandler exceptionNotificationHandler)
    {
        _exceptionLoggerHandler = exceptionLoggerHandler;
        _exceptionNotificationHandler = exceptionNotificationHandler;
    }

    public IExceptionHandler GetLoggerExceptionHandler()
    {
        return _exceptionLoggerHandler;
    }

    public IExceptionHandler GetNotificationExceptionHandler()
    {
        return _exceptionNotificationHandler;
    }

    public IExceptionHandler GetLoggerAndNotificationExceptionChainHandler()
    {
        _exceptionLoggerHandler.SetNext(_exceptionNotificationHandler);

        return _exceptionLoggerHandler;
    }
}