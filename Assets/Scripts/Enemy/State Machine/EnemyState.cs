using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy;

public class EnemyState
{
    //protected: acts like private for most stuff, but as public
    //for classes that derive from this script.
    //aka all our individual states will have access to these variables.
    protected Enemy enemy;
    protected EnemyStateMachine enemyStateMachine;

    //contructor to pass that data whenever we create an instance of this script.
    public EnemyState(Enemy enemy, EnemyStateMachine enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
    }

    //those are all being set as virtual - we can override these in the state later, but we are not forced to,
    //as oposed to abstract methods (Optional)
    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicsUpdate() { }
    public virtual void AnimationTiggerEvent(Enemy.AnimationTriggerType triggerType) { }

    public virtual void CollisionUpdate() { }

    //maybe add collision triggers if needed (damage on collision)



}
