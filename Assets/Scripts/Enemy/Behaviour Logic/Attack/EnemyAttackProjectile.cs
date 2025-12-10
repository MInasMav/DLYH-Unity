using UnityEngine;

public class EnemyAttackProjectile : MonoBehaviour
{

    [Header("Projectile Settings")]
    public int damage = 1;
    //this below specifies how the our specific tag, in this case, "Player" is read by the code - we initialize it as so.
    public string playerTag = "Player";
   // public Transform attackPoint;
   // public float projectileRange;
    public LayerMask playerLayer;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    //public void Attack()
    //{
    //    Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, projectileRange, playerLayer);

    //    if (hits.Length > 0)
    //    {
    //        hits[0].GetComponent<PlayerHealth>().ChangeHealth(-damage);
    //        //hits[0].GetComponent<PlayerMovement>().Knockback(transform);
    //        //knockbackForce, stunTime);
    //    }
    //}

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag(playerTag))
        {
            Debug.Log("Capsule colliders started overlapping!");

            other.GetComponent<PlayerHealth>().ChangeHealth(-damage);

            Destroy(gameObject);
        }
        // Destroy one of the objects
        // Destroy(gameObject);

        // Play sound
        // AudioSource.PlayClipAtPoint(overlapSound, transform.position);
    }
}
