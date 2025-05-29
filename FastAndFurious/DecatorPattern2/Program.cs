using DecoratorPattern;

INotificator notificator = new BaseNotificator();
notificator.RaiseEvent();

Console.WriteLine("___");

notificator = new FacebookNotificatorDecorator(notificator);
notificator.RaiseEvent();

Console.WriteLine("___");

notificator = new InstagramNotificatorDecorator(notificator);
notificator.RaiseEvent();

Console.WriteLine("___");

notificator = new SlackNotificatorDecorator(notificator);
notificator.RaiseEvent();

Console.WriteLine("___");

notificator = new BaseNotificator();
notificator = new FacebookNotificatorDecorator(notificator);
notificator = new SlackNotificatorDecorator(notificator);
notificator.RaiseEvent();