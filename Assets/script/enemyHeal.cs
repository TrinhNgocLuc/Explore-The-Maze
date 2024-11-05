using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHeal : MonoBehaviour
{
    public float maxHealth;
    [SerializeField] private float damageDuration = 0.2f; 
    [SerializeField] private Color damageColor = Color.red; 
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    public seachPlayer tim;
    [SerializeField] private GameObject textHeal ;
    public Transform textPosision;
    public int boExp = 5;
    [SerializeField] private AudioSource audioSourcePain;
    [SerializeField] private AudioSource audioSourceWinboss;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        tim = GetComponent<seachPlayer>();
        textHeal = GameObject.Find("pointHeal");
        audioSourcePain = GameObject.Find("lính").GetComponent<AudioSource>();
        audioSourceWinboss = GameObject.Find("game win").GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        maxHealth -= damage;
        textHeal.GetComponent<TextMesh>().text = "-" + damage.ToString();
        GameObject newtextHeal = Instantiate(textHeal,textPosision.position,Quaternion.identity);
        Destroy(newtextHeal,0.7f);
        if (maxHealth <= 0)
        {
            Die();

        }
        else
        {
            StartCoroutine(DamageEffect());
        }
    }

    private IEnumerator DamageEffect()
    {
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(damageDuration);
        PlaySoundPain();
        spriteRenderer.color = Color.white;
    }

    public void Die()
    {
        tim.detectionRange = -2;
        bonus();
        animator.SetTrigger("die");
        PlaySoundPain();
        Invoke("Destroy",0.5f);
        if (gameObject.name == "Fly boss" || gameObject.name == "Slime boss" || gameObject.name == "Golem boss")
        {
            PlaySoundWinboss();
        }
        Debug.Log("Die");
    }
    void bonus()
    {
        GameObject player = GameObject.Find("PLAYER");
            if (player != null)
            {
                playerExp playerExp = player.GetComponent<playerExp>();
                if (playerExp != null)
                {
                    playerExp.killEnemy(boExp);
                }
            }
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
     void PlaySoundPain()
    {
        audioSourcePain.PlayOneShot(audioSourcePain.clip);
    }
     void PlaySoundWinboss()
    {
        audioSourceWinboss.PlayOneShot(audioSourceWinboss.clip);
    }
}
