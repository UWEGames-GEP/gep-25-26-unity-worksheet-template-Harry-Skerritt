using System;
using UnityEngine;

public abstract class GameState
{
    protected StateMachine stateMachine;
    protected GameManager gameManager;

    protected GameState(GameManager gameManager, StateMachine stateMachine)
    {
        this.gameManager = gameManager;
        this.stateMachine = stateMachine; 
    }
    
    public abstract void OnEnter(); 
    public abstract void Update();
    public abstract void LateUpdate();
    public abstract void OnExit();
}