using System;
using UnityEngine;

public class PlayState : GameState
{
    public PlayState(GameManager gameManager, StateMachine stateMachine) : base(gameManager, stateMachine) { }
    
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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gameManager.AddItemToInventory("Generic Item", InventoryType.Player);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameManager.RemoveItemFromInventory("Generic Item", InventoryType.Player);
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