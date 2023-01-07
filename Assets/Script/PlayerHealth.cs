using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth { get; private set; }

    private Animator myAnimator;
    public GameManager theGameManager;
    public AudioSource playerGetHealthSound;
    public AudioSource playerTakeDamageSound;

    private void Awake()
    {
        currentHealth = startingHealth;
        myAnimator = GetComponent<Animator>();
    }

    public void PlayerTakeDamage(float damageTaken)
    {
        currentHealth = Mathf.Clamp(currentHealth - damageTaken, 0, startingHealth);

        if (currentHealth > 0)
        {
            playerTakeDamageSound.Play();
            myAnimator.SetTrigger("hurt");
        }
        else
        {
            theGameManager.RestartGame();
        }
    }

    public void AddHealth(float healthAdd)
    {
        if (healthAdd == 1)
        {
            playerGetHealthSound.Play();
        }
        currentHealth = Mathf.Clamp(currentHealth + healthAdd, 0, startingHealth);
    }
}
