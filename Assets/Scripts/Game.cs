using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
