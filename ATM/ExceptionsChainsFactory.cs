using ATM.ExceptionHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class ExceptionsChainsFactory
    {
        public IExceptionHandler GetNotificationExceptionHandler()
        {
            return new NotificationExceptionsHandler();
        }

        public IExceptionHandler GetLogExceptionHandler()
        {
            return new LogExceptionHandler();
        }

        public IExceptionHandler GetLogAndNotificationExceptionHandlers()
        {
            var handler = new LogExceptionHandler();
            handler.SetNext(new NotificationExceptionsHandler());
            return handler;
        }
    }
}
