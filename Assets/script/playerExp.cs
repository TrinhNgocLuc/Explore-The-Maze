using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerExp : MonoBehaviour
{
    public int maxExp = 10;
    [SerializeField] private AudioSource powerup;
    [SerializeField] private expPlayercontroller expController;
    private playerDamage playerDamgegayra;
    private playerMove moveplayer;
    private playerHeal healPlayer;
    private int minExp;
    private void Start()
    {
        playerDamgegayra = GetComponent<playerDamage>();
        moveplayer = GetComponent<playerMove>();
        healPlayer = GetComponent<playerHeal>();
        UpdateExpUI();
    }

    public void killEnemy(int boExp)
    {
        minExp += boExp;
        if (minExp >= maxExp)
        {
            levelUP();
        }
        UpdateExpUI(); 
    }
    public void UpdateExpUI()
    {

        expController.UpdateBar(minExp, maxExp);
        expController.Updatelevel();
    }
    public void levelUP()
    {
         maxExp = maxExp + 15;
         minExp = 0;
         expController.level += 1;
         if (maxExp == 30)
         {
         powerup.Play();
         playerDamgegayra.bonusAT(5);
         healling();
         playerDamgegayra.delayBetweenSpacePresses -= 0.1f; 
         moveplayer.moveSpeed += 1;
         }
         else if (maxExp == 45)
         {
         powerup.Play();
         playerDamgegayra.bonusAT(10);
         healling();
         playerDamgegayra.delayBetweenSpacePresses -= 0.1f; 
         moveplayer.moveSpeed += 1;}
         else if (maxExp == 60 )
         {
         powerup.Play();
         playerDamgegayra.bonusAT(15);
         healling();
         playerDamgegayra.delayBetweenSpacePresses -= 0.1f; 
         moveplayer.moveSpeed += 1;}
         else if (maxExp == 75)
        {
         powerup.Play();
         playerDamgegayra.bonusAT(20);
         healling();
         playerDamgegayra.delayBetweenSpacePresses -= 0.1f; 
         moveplayer.moveSpeed += 1;}
         else if (maxExp == 90)
        {
         powerup.Play();
         playerDamgegayra.bonusAT(25);
         healling();
         playerDamgegayra.delayBetweenSpacePresses -= 0.1f;
         moveplayer.moveSpeed += 1;}
         else if (maxExp == 105)
        {
         powerup.Play();
         playerDamgegayra.bonusAT(25);
         healling();
         playerDamgegayra.delayBetweenSpacePresses -= 0.1f;
         moveplayer.moveSpeed += 1;}
        Debug.Log("level up");
    }
    public void healling()
    {
        if (healPlayer.currentHealth < 100)
        {
            healPlayer.currentHealth += 10;
        }
        if (healPlayer.currentHealth > 100)
        {
            healPlayer.currentHealth = 100;
        }
        healPlayer.UpdateHealUI();
    }
}
