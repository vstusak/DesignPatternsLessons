namespace ChainOfResponsibility2.Handlers;

public interface IExceptionHandlerFactory
{
    IExceptionHandler GetLoggerExceptionHandler();
    IExceptionHandler GetNotificationExceptionHandler();

    IExceptionHandler GetLoggerAndNotificationExceptionChainHandler();
}