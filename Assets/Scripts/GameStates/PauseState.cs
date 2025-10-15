using System;
using UnityEngine;

public class PauseState : GameState
{
    public PauseState(GameManager gameManager, StateMachine stateMachine) : base(gameManager, stateMachine) { }

    public override void OnEnter()
    {
        Debug.Log("PauseState Enter");
    }
    
    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            stateMachine.ChangeState(stateMachine.gameManager.playState);
        }
    }

    public override void LateUpdate()
    {
        Time.timeScale = 0f;
    }

    public override void OnExit()
    {
        Debug.Log("PauseState Exit");
    }
}