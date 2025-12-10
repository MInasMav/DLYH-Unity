using UnityEngine;

public class Knight : Enemy
{
    //Rigidbody2D RB { get; set; }

    public void ChangeHealth(int amount)
    {
        CurrentHealth += amount;

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        else if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }



}
