using UnityEngine;

[CreateAssetMenu(fileName = "Attack-Straight-Single Projectile", menuName = "Enemy Logic/Attack Logic/Straight Single Projectile")]

public class EnemyAttackSingleStraightProjectile : EnemyAttackSOBase
{
    [SerializeField] private Rigidbody2D FireBallPrefab;

    //how much time between each shot
    [SerializeField] private float _timeBetweenShots = 2f;
    //how much time for enemy to exit state
    [SerializeField] private float _timeTillExit = 3f;
    //how big is the distance to exit state
    [SerializeField] private float _distanceToCountExit = 3f;
    [SerializeField] private float _fireBallSpeed = 10f;


    //time to start shot once triggered
    private float _timer;
    //timer that indicates how much time passed in exiting state
    private float _exitTimer;

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

        //this stops the enemy in place
        enemy.MoveEnemy(Vector2.zero);

        if (_timer > _timeBetweenShots)
        {
            _timer = 0f;

            Vector2 dir = (playerTransform.position - enemy.transform.position).normalized;

            //remember to initialize the prefab's rigidbody2D in the enemy class for this to work
            Rigidbody2D FireBall = GameObject.Instantiate(FireBallPrefab, enemy.transform.position, Quaternion.identity);
            FireBall.linearVelocity = dir * _fireBallSpeed;
        }

        //Distance checks are expensive to run every frame (Basically not inside FRAMEUPDATE, DINGUS) , CHANGE LATER
        if (Vector2.Distance(playerTransform.position, enemy.transform.position) > _distanceToCountExit)
        {
            _timer += Time.deltaTime;

            if (_exitTimer > _timeTillExit)
            {
                enemy.StateMachine.ChangeState(enemy.ChaseState);
            }
        }

        //if within the distance we reset the exit timer cause he doesnt need to chase us
        else
        {
            _exitTimer = 0f;
        }
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
