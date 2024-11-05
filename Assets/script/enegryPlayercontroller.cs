using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class enegryPlayercontroller : MonoBehaviour
{
    public Image fillBar;
    public TextMeshProUGUI healText;


    public void UpdateBar(float enegryNow, float maxEnegry)
    {
        fillBar.fillAmount = enegryNow / maxEnegry;
        healText.text = enegryNow.ToString("0") + "/" + maxEnegry.ToString("0");
    }

}
