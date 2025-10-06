using UnityEngine;


public class StateMachine
{
    
    public GameManager gameManager;
    
    private GameState currentState;

    public StateMachine(GameManager gameManager)
    {
        this.gameManager = gameManager;
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
    
}