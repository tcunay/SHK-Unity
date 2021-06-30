using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private Enemy _template;
    [SerializeField] private Vector2[] _transformsTemplate;

    private List<Enemy> _enemies = new List<Enemy>();
    private int _numberOfTemplate;

    private void Start()
    {
        CreateTemplates();
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Dying -= HandleEnemyDying;
        }
    }

    private void CreateTemplates()
    {
        for (int i = 0; i < _transformsTemplate.Length; i++)
        {
            var enemy = Instantiate(_template, _transformsTemplate[i], Quaternion.identity);
            _enemies.Add(enemy);
            enemy.Dying += HandleEnemyDying;
            _numberOfTemplate++;
        }
    }

    private void HandleEnemyDying()
    {
        SubtractEnemy();
        TryFinishGame();
    }

    private void SubtractEnemy()
    {
        --_numberOfTemplate;
    }

    private void TryFinishGame()
    {
        if (_numberOfTemplate == 0)
        {
            _game.GameOver();
        }
    }
}
