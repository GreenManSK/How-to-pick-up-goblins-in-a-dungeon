namespace Services.Events
{
    public class SeducedPickUpEvent : IEvent
    {
        public int Xp;

        public SeducedPickUpEvent(int xp)
        {
            Xp = xp;
        }
    }
}