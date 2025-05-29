namespace DecoratorPattern
{
    class SlackNotificatorDecorator : INotificator
    {
        private readonly INotificator _baseNotificator;

        public SlackNotificatorDecorator(INotificator baseNotificator)
        {
            _baseNotificator = baseNotificator;
        }

        public void RaiseEvent()
        {
            _baseNotificator.RaiseEvent();
            Console.WriteLine("Notification has been sent to Slack.");
        }
    }
}
