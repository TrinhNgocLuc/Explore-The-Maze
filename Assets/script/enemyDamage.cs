using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    [SerializeField] private int damgeEnemy = 2;
    [SerializeField] private float attackInterval = 2f; 
    private bool canAttack = false; 
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Attack()
    {
        if (canAttack)
        {
            GameObject player = GameObject.Find("PLAYER");
            if (player != null)
            {
                playerHeal playerHealth = player.GetComponent<playerHeal>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damgeEnemy);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PLAYER")
        {
            animator.SetTrigger("attack");
            canAttack = true;
            InvokeRepeating("Attack", 0.5f, attackInterval);
        }
    }
     private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "PLAYER")
        {
            animator.SetTrigger("stopattack");
            canAttack = false;
            CancelInvoke("Attack");
        }
    }
}
