using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class healplayercontroller : MonoBehaviour
{
    public Image fillBar;
    public TextMeshProUGUI healText;
    

    public void UpdateBar(float healNow, float maxHeal)
    {   
        fillBar.fillAmount = healNow / maxHeal; 
        healText.text = healNow.ToString() + "/" + maxHeal.ToString();   
    }
}
