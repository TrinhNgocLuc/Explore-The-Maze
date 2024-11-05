using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamage : MonoBehaviour
{
    [SerializeField] private int attackDamage = 5; 
    private float enlargedSize = 1.15f; 
    private float lastSpacePress = 0f;
    public float delayBetweenSpacePresses = 0.8f;
    private Vector2 originalSize; 
    private bool isEnlarged = false;
    [SerializeField] private AudioClip sound;
    [SerializeField] private AudioSource audioSource;
    private bool isAttacking = false;
    private Animator animator;
    private BoxCollider2D playerCollider; 
 
    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        originalSize = playerCollider.size;
        audioSource.clip = sound;
    }

    void Update()
    {
       if (Time.time - lastSpacePress >= delayBetweenSpacePresses)
        {
        if (!isEnlarged && Input.GetKeyDown(KeyCode.Space)&& !isAttacking)
        {
            animator.SetTrigger("attack");
            isAttacking = true; 
            playerCollider.size *= enlargedSize;
            isEnlarged = true;
            PlaySound();
            lastSpacePress = Time.time;
        }
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isEnlarged)
            {
                animator.SetTrigger("attack");
                isAttacking = false; 
                playerCollider.size= originalSize;
                isEnlarged = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (isEnlarged)
        {
            if (collision.gameObject.CompareTag("enemy"))
            {
                collision.gameObject.GetComponent<enemyHeal>().TakeDamage(attackDamage);
            }
        }
    }
    public void bonusAT(int bonusAT)
    {
        attackDamage += bonusAT;
    } 
    void PlaySound()
    {
        audioSource.PlayOneShot(sound);
    }
}
