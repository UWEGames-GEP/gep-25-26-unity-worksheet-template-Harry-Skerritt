using System;
using UnityEngine;

public class PauseState : GameState
{
    public PauseState(GameManager gameManager, StateMachine stateMachine) : base(gameManager, stateMachine) { }

    public override string stateID => "state_Paused";

    public override void OnEnter()
    {
        Debug.Log($"{stateID} Enter");

        // UI
        if (gameManager.pauseScreen != null && !gameManager.pauseScreen.activeInHierarchy)
        {
            gameManager.pauseScreen.SetActive(true);
        }
    }
    
    public override void Update()
    {

    }

    public override void TransitionEvent(TransitionParam param)
    {
        if(param == TransitionParam.PauseTrigger)
        {
            stateMachine.ChangeState(gameManager.playState);
        }
    }

    public override void LateUpdate()
    {
        Time.timeScale = 0f;
        gameManager.LockPlayerCamera(true);
    }

    public override void OnExit()
    {
        Debug.Log($"{stateID} Exit");

        // UI
        if (gameManager.pauseScreen != null && gameManager.pauseScreen.activeInHierarchy)
        {
            gameManager.pauseScreen.SetActive(false);
        }
    }
}