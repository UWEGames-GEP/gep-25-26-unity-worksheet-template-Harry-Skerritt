using UnityEngine;
using UnityEngine.Events;

public enum TransitionParam { PauseTrigger, InventoryTrigger };

public class StateMachine
{   
    public GameManager gameManager;

    public UnityEvent<TransitionParam> transitionEvent;
    
    private GameState currentState;

    public StateMachine(GameManager gameManager)
    {
        this.gameManager = gameManager;

        // Event handler
        if(transitionEvent == null)
            transitionEvent = new UnityEvent<TransitionParam>();

        transitionEvent.AddListener(TransitionEvent);
    }
    
    public void Update()
    {
        if (currentState != null)
            currentState.Update();
    }
    
    public void LateUpdate()
    {
        if(currentState != null)
            currentState.LateUpdate();
    }
    
    public void ChangeState(GameState state)
    {
        if(currentState != null)
            currentState.OnExit();
        
        currentState = state;
        
        currentState.OnEnter();
    }

    public void TransitionEvent(TransitionParam param)
    {
        if(currentState != null)
            currentState.TransitionEvent(param);
    }


    public string GetCurrentStateID()
    {
        return currentState.stateID;
    }
    
}