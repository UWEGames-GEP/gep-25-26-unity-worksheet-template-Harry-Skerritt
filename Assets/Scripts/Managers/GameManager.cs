using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // State Machine
    private StateMachine stateMachine;
    
    // Game States
    public GameState pauseState;
    public GameState playState;
    
    // UI
    [Header("UI")]
    public GameObject pauseScreen;

    // Inventory Manager
    [Header("Inventory Manager")]
    [SerializeField] private InventoryManager inventoryManager;

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

        if (inventoryManager == null)
        {
            inventoryManager = FindAnyObjectByType<InventoryManager>();
        }
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void LateUpdate()
    {
        stateMachine.LateUpdate();
    }
    

    // Getters
    public string GetCurrentState()
    {
        return stateMachine.GetCurrentStateID();
    }
    
    // Inventory Manager
/*
    public void AddItemToInventory(string itemName, InventoryType targetInventory)
    {
        inventoryManager.AddItemToInventory(itemName, targetInventory);
    }

    public void RemoveItemFromInventory(string itemName, InventoryType targetInventory)
    {
        inventoryManager.RemoveItemFromInventory(itemName, targetInventory);
    }
*/
    
    
}
