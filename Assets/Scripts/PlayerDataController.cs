using Services;
using Services.Events;
using Stats;
using UnityEngine;

public class PlayerDataController : MonoBehaviour, IEventListener<SeductionEvent>, IEventListener<KillEvent>,
    IEventListener<SeducedPickUpEvent>
{
    public PlayerStatsBlock playerStatsBlock = new PlayerStatsBlock();
    public int experience = 0;
    public int seductionCount = 0;
    public int killCount = 0;

    private bool _subscribed = false;
    
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        EventSystem.Subscribe<SeductionEvent>(this);
        EventSystem.Subscribe<KillEvent>(this);
        EventSystem.Subscribe<SeducedPickUpEvent>(this);
        _subscribed = true;
    }

    private void OnDisable()
    {
        if (!_subscribed)
            return;
        EventSystem.Unsubscribe<SeductionEvent>(this);
        EventSystem.Unsubscribe<KillEvent>(this);
        EventSystem.Unsubscribe<SeducedPickUpEvent>(this);
        _subscribed = false;
    }

    public void OnEvent(SeductionEvent @event)
    {
        seductionCount++;
    }

    public void OnEvent(KillEvent @event)
    {
        killCount++;
        experience += @event.Xp;
    }

    public void OnEvent(SeducedPickUpEvent @event)
    {
        experience += @event.Xp;
    }
}