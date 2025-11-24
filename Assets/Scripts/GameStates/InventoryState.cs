using UnityEngine;

public class InventoryState : GameState
{
   public InventoryState(GameManager gameManager, StateMachine stateMachine) : base(gameManager, stateMachine) { }

   public override string stateID => "state_Inventory";

    public override void OnEnter()
    {
        Debug.Log($"{stateID} Enter");

        // UI
        gameManager.SetInventoryActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public override void Update()
    {
        // Handle changing state back
        if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape))
        {
            stateMachine.ChangeState(gameManager.playState);
        }

        // Handle mouse in the inventory

    }

    public override void LateUpdate()
    {
        Time.timeScale = 0f;
    }

    public override void OnExit()
    {
        Debug.Log($"{stateID} Exit");
        gameManager.SetInventoryActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


}
