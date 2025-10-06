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
        // Switches state on key 
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (state)
            {
                case GameState.GAMEPLAY:
                    hasStateChanged = true;
                    state = GameState.PAUSED;
                    break;
                case GameState.PAUSED:
                    hasStateChanged = true;
                    state = GameState.GAMEPLAY;
                    break;
            }
        }
    }

    private void LateUpdate()
    {
        // Applies state behaviour
        if (hasStateChanged)
        {
            hasStateChanged = false;
            
            switch (state)
            {
                case GameState.GAMEPLAY:
                    Time.timeScale = 1f;
                    break;
                case GameState.PAUSED:
                    Time.timeScale = 0f;
                    break;
            }
        }
    }
}
