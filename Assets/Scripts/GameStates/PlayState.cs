using System;
using UnityEngine;

public class PlayState : GameState
{
    public PlayState(GameManager gameManager, StateMachine stateMachine) : base(gameManager, stateMachine) { }

    public override string stateID => "state_Play";
    
    public override void OnEnter()
    {
        Debug.Log($"{stateID}: Enter");
    }

    public override void Update()
    {

    }

    public override void TransitionEvent(TransitionParam param)
    {
        if(param == TransitionParam.PauseTrigger)
        {
            stateMachine.ChangeState(gameManager.pauseState);
        }
        else if (param == TransitionParam.InventoryTrigger)
        {
            stateMachine.ChangeState(gameManager.inventoryState);
        }
    }

    public override void LateUpdate()
    {
        Time.timeScale = 1f;
        gameManager.LockPlayerCamera(false);
    }

    public override void OnExit()
    {
        Debug.Log($"{stateID}: Exit");
    }
}