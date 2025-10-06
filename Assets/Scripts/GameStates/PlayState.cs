using System;
using UnityEngine;

public class PlayState : GameState
{
    public PlayState(StateMachine stateMachine) : base(stateMachine) { }
    
    public override void OnEnter()
    {
        Debug.Log("PlayState Enter");
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            stateMachine.ChangeState(stateMachine.gameManager.pauseState);
        }
    }

    public override void LateUpdate()
    {
        Time.timeScale = 1f;
    }

    public override void OnExit()
    {
        Debug.Log("PlayState Exit");
    }
}