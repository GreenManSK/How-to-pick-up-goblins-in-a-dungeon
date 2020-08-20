using System.Collections.Generic;
using Characters.Enemy;
using Characters.Player;
using Dating;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static Input _input;

    public static Input Input => _input ?? (_input = new Input());

    public static GameController Instance;

    public PlayerDataController payerDataController;
    public PlayerController player;
    public HashSet<EnemyController> enemies = new HashSet<EnemyController>();

    protected void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        player.statsBlock = payerDataController.playerStatsBlock;
    }

    public void AddEnemies(IEnumerable<EnemyController> enemyControllers)
    {
        foreach (var enemy in enemyControllers)
        {
            enemies.Add(enemy);
            enemy.SetTarget(player.transform, () => enemies.Remove(enemy));
        }
    }
}