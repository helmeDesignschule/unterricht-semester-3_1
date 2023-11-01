using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameState
{
    public enum State
    {
        MainMenu,
        InGame,
        GameOver,
    }

    public enum Scenes
    {
        MainMenu = 0,
        Level1 = 1,
    }

    public static event System.Action<State> onStateChanged;

    private static State currentState = State.MainMenu;

    public static void SetState(State newState)
    {
        if (currentState == newState)
            return;

        if (newState == State.MainMenu)
        {
            SceneManager.LoadScene((int)Scenes.MainMenu);
            Time.timeScale = 1;
        }
        else if (newState == State.InGame)
        {
            SceneManager.LoadScene((int)Scenes.Level1);
            Time.timeScale = 1;
        }
        else if (newState == State.GameOver)
        {
            Time.timeScale = 0;
        }

        currentState = newState;
        if (onStateChanged != null)
            onStateChanged(currentState);
    }
}
