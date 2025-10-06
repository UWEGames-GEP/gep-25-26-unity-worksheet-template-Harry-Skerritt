using System;
using UnityEngine;

public abstract class GameState
{
    protected StateMachine stateMachine;

    protected GameState(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine; 
    }
    
    public abstract void OnEnter(); 
    public abstract void Update();
    public abstract void LateUpdate();
    public abstract void OnExit();
}