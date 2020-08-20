namespace Services.Events
{
    public class SeductionEvent : IEvent
    {
        public static readonly SeductionEvent Instance = new SeductionEvent();

        private SeductionEvent()
        {
        }
    }
}