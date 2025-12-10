using UnityEngine;


[CreateAssetMenu(fileName = "Chase - Run Away", menuName = "Enemy Logic/Chase Logic/Run Away" )]
public class EnemyChaseRunAway : EnemyChaseSOBase
{
    //good for a skittish enemy
    [SerializeField] private float _RunAwaySpeed = 1.5f;
    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        //this calculates and normalizes the direction the enemy should run to.
        //its literally the just negative of the regular chase function lol
        Vector2 runDir = -(playerTransform.position - transform.position).normalized;
        enemy.MoveEnemy(runDir * _RunAwaySpeed);
    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();
    }

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
}
