namespace Services.Events
{
    public class KillEvent : IEvent
    {
        public int Xp;

        public KillEvent(int xp)
        {
            Xp = xp;
        }
    }
}