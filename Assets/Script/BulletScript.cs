using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletRadius;
    public int bulletDamage = 30;

    // private BoxCollider2D myBoxCollider;
    private Rigidbody2D myRigidbody;
    // private EnemyScript theEnemyScript;

    // Start is called before the first frame update
    void Start()
    {
        // myBoxCollider = GetComponent<BoxCollider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        // theEnemyScript = FindObjectOfType<EnemyScript>();

        Invoke("DestroySelf", bulletRadius);
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(bulletSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyScript enemy1 = collision.GetComponent<EnemyScript>();
            if (enemy1 != null)
            {
                enemy1.TakeDamage(bulletDamage);
            }
            // Debug.Log(collision.name);
            // theEnemyScript.TakeDamage(bulletDamage);
            DestroySelf();
        }
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            DestroySelf();
        }

        
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
    
}
