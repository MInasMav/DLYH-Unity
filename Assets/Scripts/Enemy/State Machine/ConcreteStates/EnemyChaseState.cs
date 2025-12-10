using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    //initializing the values for us to call
   
    //the function below acts like an awake function, since we initialized it on "Awake" inside the master script, Enemy
    public EnemyChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {

    }

    public override void AnimationTiggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTiggerEvent(triggerType);

        enemy.EnemyChaseBaseInstance.DoAnimationTriggerEventLogic(triggerType);
    }


    //what happens when enemy enters state
    public override void EnterState()
    {
        base.EnterState();

        enemy.EnemyChaseBaseInstance.DoEnterLogic();

        Debug.Log("chasing happening");
    }

    //what happens when enemy exits state
    public override void ExitState()
    {
        base.ExitState();

        enemy.EnemyChaseBaseInstance.DoExitLogic();
    }

    //Updates on frame
    public override void FrameUpdate()
    {
        base.FrameUpdate();

        enemy.EnemyChaseBaseInstance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        enemy.EnemyChaseBaseInstance.DoPhysicsLogic();
    }
}
