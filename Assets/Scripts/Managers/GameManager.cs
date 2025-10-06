using System;
using UnityEngine;

public enum GameState
{
    GAMEPLAY,
    PAUSED
    
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameState state;
    private bool hasStateChanged = false;
    
    void Start()
    {
        state = GameState.GAMEPLAY;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (state == GameState.GAMEPLAY)
            {
                // Pause
                state = GameState.PAUSED;
                hasStateChanged = true;
            } 
            else if (state == GameState.PAUSED)
            {
                // Play
                state = GameState.GAMEPLAY;
                hasStateChanged = true;
            }
        }
    }

    private void LateUpdate()
    {
        if (hasStateChanged)
        {
            hasStateChanged = false;
            if (state == GameState.GAMEPLAY)
            {
                Time.timeScale = 1f;
            } 
            else if (state == GameState.PAUSED)
            {
                Time.timeScale = 0f;
            }
        }
    }
}
