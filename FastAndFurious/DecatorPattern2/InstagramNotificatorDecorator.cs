namespace DecoratorPattern
{
    class InstagramNotificatorDecorator : INotificator
    {
        private readonly INotificator _baseNotificator;

        public InstagramNotificatorDecorator(INotificator baseNotificator)
        {
            _baseNotificator = baseNotificator;
        }
        public void RaiseEvent()
        {
            _baseNotificator.RaiseEvent();
            Console.WriteLine("Notification has been sent to Instagram.");
        }
    }
}
