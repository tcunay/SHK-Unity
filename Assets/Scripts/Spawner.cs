﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private Enemy _template;
    [SerializeField] private Vector2[] _transformsTemplate;

    private int _numberOfTemplate;

    private void Start()
    {
        RememberInitNumberOfTemplates();
        CreateTemplates();
    }

    private void OnDisable()
    {
        _template.Died -= CountTheRemainingEnemies;
    }

    private void CreateTemplates()
    {
        for (int i = 0; i < _transformsTemplate.Length; i++)
        {
            var enemy = Instantiate(_template, _transformsTemplate[i], Quaternion.identity);
            enemy.Died += CountTheRemainingEnemies;
        }
    }

    private void RememberInitNumberOfTemplates()
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
