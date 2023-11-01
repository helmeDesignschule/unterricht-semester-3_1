using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        GameState.onStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameState.onStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState.State newState)
    {
        gameOverScreen.SetActive(newState == GameState.State.GameOver);
    }
    
    public void RestartLevel()
    {
        GameState.SetState(GameState.State.InGame);
    }

    public void ToMainMenu()
    {
        GameState.SetState(GameState.State.MainMenu);
    }
}
