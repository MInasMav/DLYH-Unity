using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BarthaSzabolcs.Tutorial_SpriteFlash; //adding the flash animations here 

public class Enemy : MonoBehaviour, IDamagable, IEnemyMovable, ITriggerCheckable
{
    //making it serializable with that bracket before the public float.
    [field: SerializeField] public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public Rigidbody2D RB { get; set; }
    public bool IsFacingRight { get; set; } = true;

    public bool IsAggroed { get ; set; }
    public bool IsWithinStrikingDistance { get; set; }

    [SerializeField] private SimpleFlash flashEffect; //setting up flash stuff


    #region State Machine Variables

    #region ScriptableObject Variables

    [SerializeField] private EnemyIdleSOBase EnemyIdleBase;
    [SerializeField] private EnemyChaseSOBase EnemyChaseBase;
    [SerializeField] private EnemyAttackSOBase EnemyAttackBase;


    //we're using all of these below to get the base instance info to customize states later. (thats why its public)
    public EnemyIdleSOBase EnemyIdleBaseInstance { get; set; }
    public EnemyChaseSOBase EnemyChaseBaseInstance { get; set; }
    public EnemyAttackSOBase EnemyAttackBaseInstance { get; set; }



    #endregion



    //initializing here cause its not a monobehaviour script, and therefore doesnt automatically
    //initialize itself on unity
    public EnemyStateMachine StateMachine { get; set; }
    public EnemyIdleState IdleState { get; set; }
    public EnemyChaseState ChaseState { get; set; }
    public EnemyAttackState AttackState { get; set; }
   

    #endregion

    private void Awake()
    {
        flashEffect = GetComponent<SimpleFlash>(); //more flash stuff here

        EnemyIdleBaseInstance = Instantiate(EnemyIdleBase);
        EnemyChaseBaseInstance = Instantiate(EnemyChaseBase);
        EnemyAttackBaseInstance = Instantiate(EnemyAttackBase);

        StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, StateMachine);
        ChaseState = new EnemyChaseState(this, StateMachine);
        AttackState = new EnemyAttackState(this, StateMachine);
    }

    
    private void Start()
    {
        CurrentHealth = MaxHealth;

        RB = GetComponent<Rigidbody2D>();

        //inititializing all public instances on start (can be called)
        EnemyIdleBaseInstance.Initialize(gameObject, this);
        EnemyChaseBaseInstance.Initialize(gameObject, this);
        EnemyAttackBaseInstance.Initialize(gameObject, this);

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentEnemyState.FrameUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentEnemyState.PhysicsUpdate();
    }


    //Neat little way to restrict sections of the code in segments
    #region Health/Die Functions

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;

        // FLASH WHEN HIT
        if (flashEffect != null)
        {
            flashEffect.Flash();
        }


        if (CurrentHealth <= 0) 
        {
            Die();
        }

    }

    public void Die()
    {
        Destroy(gameObject);
    }

    #endregion

    #region Movement Functions
    public void MoveEnemy(Vector2 velocity)
    {
        //RB.velocity = velocity; - this one is outdated
        RB.linearVelocity = velocity;
        CheckForLeftOrRightFacing(velocity);
    }

    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
        //tThis rotates the Y axis by 180 degrees whenever necessary, flipping our character.
        //Probably doesnt need to work with vec3s for a simple 2d topdown game but would be already
        //implemented in the case of 2.5D, which is cool.

        if (IsFacingRight && velocity.x < 0f) 
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }

        else if (!IsFacingRight && velocity.x > 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
    }

    #endregion

    #region Distance Checks

    public void SetAggroStatus(bool isAggroed)
    {
        IsAggroed = isAggroed;
    }

    //remember this rn is being used for a projectile test.
    public void SetStrikingDistanceBool(bool isWithinStrikingDistance)
    {
        IsWithinStrikingDistance = isWithinStrikingDistance;
    }

    #endregion

    #region Animation Triggers

    //this allows us to define a type of animation as a trigger to a specific code to run when it plays.
    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.CurrentEnemyState.AnimationTiggerEvent(triggerType);
    }

    //those are the type of animation triggers selectable on our animation inspector.
    public enum AnimationTriggerType
    {
        EnemyDamaged,
        PlayFootstepSound
    }

    #endregion
}
