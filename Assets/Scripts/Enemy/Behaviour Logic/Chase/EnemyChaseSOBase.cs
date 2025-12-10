using UnityEngine;

public class EnemyChaseSOBase : ScriptableObject
{
    protected Enemy enemy;
    protected Transform transform;
    protected GameObject gameObject;

    protected Transform playerTransform;

    public virtual void Initialize(GameObject gameObject, Enemy enemy)
    {
        this.gameObject = gameObject;
        transform = gameObject.transform;
        this.enemy = enemy;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    public virtual void DoEnterLogic()
    {

    }

    //Reset values is needed to null every value when changing states, unless we want to keep certain values intact
    //from state to state.
    public virtual void DoExitLogic()
    {
        ResetValues();
    }

    public virtual void DoFrameUpdateLogic()
    {
        //TODO - this will probably become IsWithinProjectileDistance later, since the code is setting up the projectile.
        if (enemy.IsWithinStrikingDistance)
        {
            enemy.StateMachine.ChangeState(enemy.AttackState);
        }
    }

    public virtual void DoPhysicsLogic()
    {

    }

    public virtual void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {

    }

    public virtual void ResetValues()
    {

    }

}

