namespace BuilderPattern
{
    public class MyDateTimeProvider : IMyDateTimeProvider
    {
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
