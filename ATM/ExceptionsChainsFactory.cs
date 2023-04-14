using ATM.ExceptionHandlers;

namespace ATM;

public class ExceptionsChainsFactory : IExceptionsChainsFactory
{
    private readonly IExceptionHandler _notificationExceptionHandler;
    private readonly IExceptionHandler _logExceptionHandler;

    //@TODO Make concrete interfaces for every exception handler
    public ExceptionsChainsFactory(INotificationExceptionsHandler notificationExceptionHandler,
        ILogExceptionHandler logExceptionHandler)
    {
        _notificationExceptionHandler = notificationExceptionHandler;
        _logExceptionHandler = logExceptionHandler;
    }

    public IExceptionHandler GetNotificationExceptionHandler()
    {
        return _notificationExceptionHandler;
    }

    public IExceptionHandler GetLogExceptionHandler()
    {
        return _logExceptionHandler;
    }

    public IExceptionHandler GetLogAndNotificationExceptionHandlers()
    {
        var handler = _logExceptionHandler;
        handler.SetNext(_notificationExceptionHandler);
        return handler;
    }
}