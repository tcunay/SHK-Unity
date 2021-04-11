using System.Collections;
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
        RememberStartNumberOfTemplates();
        CreateTemplates();
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Dying -= CountTheRemainingEnemies;
        }
    }

    private void CreateTemplates()
    {
        for (int i = 0; i < _transformsTemplate.Length; i++)
        {
            var enemy = Instantiate(_template, _transformsTemplate[i], Quaternion.identity);
            _enemies.Add(enemy);
            enemy.Dying += CountTheRemainingEnemies;
        }
    }

    private void RememberStartNumberOfTemplates()
    {
        _numberOfTemplate = _transformsTemplate.Length;
    }

    private void CountTheRemainingEnemies()
    {
        --_numberOfTemplate;
        if(_numberOfTemplate == 0)
        {
            _game.GameOver();
        }
    }
}
