using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5;
    public int facingDirection = 1;

    public Rigidbody2D rb;
    public Animator anim;

    private bool isKnockedBack;

    public Player_Combat player_Combat;

    private void Update()
    {
        if (Input.GetButtonDown("Slash")) {

            player_Combat.Attack();

        }
    }

    void FixedUpdate()  // if for some reason this screws things up u can find your old code in gpt
    {
        if (isKnockedBack == false)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector2 input = new Vector2(horizontal, vertical);

            // Only normalize if the player is actually moving
            if (input.magnitude > 0.1f)
            {
                input = input.normalized;
            }
            else
            {
                input = Vector2.zero;
            }

            rb.linearVelocity = input * speed;

            if (horizontal > 0 && transform.localScale.x < 0 ||
                horizontal < 0 && transform.localScale.x > 0)
            {

                Flip();
            }

            anim.SetFloat("horizontal", Mathf.Abs(horizontal));
            anim.SetFloat("vertical", vertical); // i think you need to comment out this line and make it 
                                                 // so that when vertical is positive OR negative the
                                                 // different animations will trigger.

            //when i normalize velocity it does make the movment equal
                                                                           // but it makes it so that even a little press will move a
                                                                           //a whole space.
        }
    }
    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void Knockback(Transform enemy, float force, float stunTime)
    {
        isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity = direction * force;
        StartCoroutine(KnockbackCounter(stunTime));
    }

    IEnumerator KnockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false;
    }
}
