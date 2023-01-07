using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform attackPoint;

    public GameObject bulletObject;
    public AudioSource playerAttackSound;
        
    private Animator myAnimator;
    private float cooldownTimer = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown) {
            myAnimator.SetTrigger("attack");
            cooldownTimer = 0;

            if (playerAttackSound.isPlaying)
            {
                playerAttackSound.Stop();
                playerAttackSound.Play();
            }
            else
            {
                playerAttackSound.Play();
            }
            
            Instantiate(bulletObject, attackPoint.transform.position, transform.rotation);
        }

        cooldownTimer += Time.deltaTime;
    }

}
