using System;
using UnityEngine;

public class PlayState : GameState
{
    public PlayState(GameManager gameManager, StateMachine stateMachine) : base(gameManager, stateMachine) { }

    public override string stateID => "state_Play";

    public override void OnEnter()
    {
        Debug.Log($"{stateID} Enter");
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
        Debug.Log($"{stateID} Exit");
    }
}