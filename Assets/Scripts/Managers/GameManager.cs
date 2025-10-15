using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // State Machine
    private StateMachine stateMachine;
    
    // Game States
    public GameState pauseState;
    public GameState playState;
    
    // Inventory Manager
    private InventoryManager inventoryManager;

    private void Awake()
    {
        stateMachine = new StateMachine(this);
        
        if (stateMachine != null)
        {
            pauseState = new PauseState(this, stateMachine);
            playState = new PlayState(this, stateMachine);
        }
    }

    private void Start()
    {
        stateMachine.ChangeState(playState);
        
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void LateUpdate()
    {
        stateMachine.LateUpdate();
    }
    
    
    // Inventory Manager
    public void AddItemToInventory(string itemName)
    {
        inventoryManager.AddItemToInventory(itemName);
    }

    public void RemoveItemFromInventory(string itemName)
    {
        inventoryManager.RemoveItemFromInventory(itemName);
    }
    
    
}
