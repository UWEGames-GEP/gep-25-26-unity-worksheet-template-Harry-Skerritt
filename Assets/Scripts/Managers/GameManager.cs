using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private StateMachine stateMachine;
    
    public GameState pauseState;
    public GameState playState;
    

    private void Awake()
    {
        stateMachine = new StateMachine(this);
        
        if (stateMachine != null)
        {
            pauseState = new PauseState(stateMachine);
            playState = new PlayState(stateMachine);
        }
    }

    private void Start()
    {
        stateMachine.ChangeState(playState);
    }

    private void Update()
    {
        stateMachine.Update();
    }

    private void LateUpdate()
    {
        stateMachine.LateUpdate();
    }
    
}
