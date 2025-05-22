namespace BuilderPattern
{
    public class MyDateTimeAdapter : IMyDateTimeAdapter
    {
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
