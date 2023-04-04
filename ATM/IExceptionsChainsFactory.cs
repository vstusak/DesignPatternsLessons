using ATM.ExceptionHandlers;

namespace ATM;

public interface IExceptionsChainsFactory
{
    IExceptionHandler GetNotificationExceptionHandler();
    IExceptionHandler GetLogExceptionHandler();
    IExceptionHandler GetLogAndNotificationExceptionHandlers();
}