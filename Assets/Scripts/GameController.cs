﻿using System.Collections.Generic;
using System.Linq;
using Characters;
using Controlls;
using Dating;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static Input Input;
    public static GameController Instance;

    public PlayerController player;
    public DatingController datingController;
    public HashSet<EnemyController> enemies = new HashSet<EnemyController>();

    private bool _isDating = false;

    protected void Awake()
    {
        Instance = this;
        Input = new Input();

        Input.Dating.Stop.performed += ctx => TogglePlayMode();

        GamepadSystem.Instance.SetColor(Color.clear);
    }

    private void Start()
    {
        player.gameObject.SetActive(true);
        datingController.gameObject.SetActive(false);
    }

    private void TogglePlayMode()
    {
        if (!enemies.Any())
            return;
        _isDating = !_isDating;
        player.TogglePlayMode(_isDating);
        foreach (var enemy in enemies)
        {
            enemy.SetTarget(_isDating ? null : player.transform);
        }

        if (_isDating)
        {
            datingController.gameObject.SetActive(true);
            datingController.SetData(enemies);
        }
        else
        {
            datingController.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        Input.Dating.Enable();
    }

    private void OnDisable()
    {
        Input.Dating.Disable();
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