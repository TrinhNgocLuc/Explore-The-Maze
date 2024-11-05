using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHeal : MonoBehaviour
{
    private int maxHealth = 100;
    private float damageDuration = 0.2f; 
    private Color damageColor = Color.red; 
    public healplayercontroller healController;
    public int currentHealth;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] private GameObject gameOver;
    public AudioSource audioSourceThemne;
    [SerializeField] private AudioSource audioSourcePain;
    [SerializeField] private AudioSource audioSourceDie;
    [SerializeField] private AudioSource audioSourceGameover;



    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealUI();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        gameOver.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(DamageEffect());
        }
         UpdateHealUI(); 
    }
    public void UpdateHealUI()
    {
        healController.UpdateBar(currentHealth, maxHealth);
    }
    private IEnumerator DamageEffect()
    {  
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(damageDuration);
        PlaySoundPain();
        spriteRenderer.color = Color.white;
    }

    private void Die()
    {
        animator.SetTrigger("die");
        PlaySoundDie();
        gameOver.SetActive(true);
        PlaySoundGameover();
        audioSourceThemne.Stop();
        Time.timeScale = 0;
        Debug.Log("die");
    }
    public void Heal()
    {
        currentHealth = maxHealth;
        UpdateHealUI();
        
    }
    void PlaySoundPain()
    {
        audioSourcePain.PlayOneShot(audioSourcePain.clip);
    }
     void PlaySoundDie()
    {
        audioSourceDie.PlayOneShot(audioSourceDie.clip);
    }
    void PlaySoundGameover()
    {
        audioSourceGameover.PlayOneShot(audioSourceGameover.clip);
    }
}

