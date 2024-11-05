using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class expPlayercontroller : MonoBehaviour
{
    public Image fillBar;
    public int level = 1;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI levelText;


    public void UpdateBar(float expNow, float expMax )
    {   
        fillBar.fillAmount = expNow / expMax; 
        expText.text = expNow.ToString() + "/" + expMax.ToString();
    }
    public void Updatelevel()
    {
        levelText.text = "Lv." + level.ToString();
    }
}
