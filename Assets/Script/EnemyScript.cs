using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int enemyHealth = 100;
    private int scoreToGive = 100;

    [SerializeField] private float enemyDamage;

    private Animator myAnimator;
    private BoxCollider2D myBoxCollider;
    private ScoreManager theScoreManager;
    private EnemyGenerator theEnemyGenerator;
    // public AudioSource playerTakeDamageSound;
    // private AudioSource sourceAudio;
    // public AudioClip enemyDeathSound;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        theScoreManager = FindObjectOfType<ScoreManager>();
        theEnemyGenerator = FindObjectOfType<EnemyGenerator>();
        // sourceAudio = GetComponent<AudioSource>();
    }
    
    public void TakeDamage (int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            myBoxCollider.enabled = false;
            myAnimator.SetTrigger("death");
            theEnemyGenerator.PlayAudio();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().PlayerTakeDamage(enemyDamage);
            // playerTakeDamageSound.Play();
        }
    }

    void Die()
    {
        // enemyDeathSound.Play();
        // sourceAudio.PlayOneShot(enemyDeathSound);
        Destroy(gameObject);
        // gameObject.SetActive(false);
        theScoreManager.AddScore(scoreToGive);
    }
}
