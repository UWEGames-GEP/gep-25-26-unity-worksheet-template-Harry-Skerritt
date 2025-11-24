using StarterAssets;
using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // State Machine
    private StateMachine stateMachine;
    
    // Game States
    public GameState pauseState;
    public GameState playState;
    public GameState inventoryState;
    
    // UI
    [Header("UI")]
    public GameObject pauseScreen;
    public InventoryUI inventoryUI;
    
    // Inventory Manager
    private InventoryManager inventoryManager;

    // Player Controller
    private ThirdPersonController playerController;

    private void Awake()
    {
        stateMachine = new StateMachine(this);
        
        if (stateMachine != null)
        {
            pauseState = new PauseState(this, stateMachine);
            playState = new PlayState(this, stateMachine);
            inventoryState = new InventoryState(this, stateMachine);
        }
    }

    private void Start()
    {
        stateMachine.ChangeState(playState);
        
        inventoryManager = FindAnyObjectByType<InventoryManager>();

        playerController = FindAnyObjectByType<ThirdPersonController>();

        if(inventoryUI == null)
        {
            inventoryUI = FindAnyObjectByType<InventoryUI>();
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
    
    
    // Inventory Manager
    public void AddItemToInventory(Item item, InventoryType targetInventory)
    {
        inventoryManager.AddItemToInventory(item, targetInventory);
    }

    public void RemoveItemFromInventory(Item item, InventoryType targetInventory)
    {
        inventoryManager.RemoveItemFromInventory(item, targetInventory);
    }

    // Inventory UI
    public void ToggleInventory()
    {
        inventoryUI.ToggleUI();
    }

    public void SetInventoryActive(bool active)
    {
        inventoryUI.SetInventoryActive(active);
    }

    
    // Player Controller
    public void LockPlayerCamera(bool locked)
    {
        playerController.LockCameraPosition = locked;
    }

    
}
