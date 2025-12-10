using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BarthaSzabolcs.Tutorial_SpriteFlash;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public SpriteRenderer playerSr;
    public PlayerMovement playerMovement;

    [SerializeField] private SimpleFlash flashEffect;

    public void ChangeHealth(int amount)
    {
        Debug.Log("Change Health");
        currentHealth += amount;

        // Only flash when we are *losing* health
        if (amount < 0 && flashEffect != null)
        {
            flashEffect.Flash();
        }

        if (currentHealth <= 0) {

            playerSr.enabled = false;
            playerMovement.enabled = false;
        }

    }
}
