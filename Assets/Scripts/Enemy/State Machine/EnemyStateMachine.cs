using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
   public EnemyState CurrentEnemyState { get; set; }


    //Initalizes a state
    public void Initialize(EnemyState startingState)
    {
        CurrentEnemyState = startingState;
        CurrentEnemyState.EnterState();
    }

    //Ends last state and initializes a new one
    public void ChangeState(EnemyState newState)
    {
        CurrentEnemyState.ExitState();
        CurrentEnemyState = newState;
        CurrentEnemyState.EnterState();
    }
}
