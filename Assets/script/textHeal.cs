using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class textHeal : MonoBehaviour
{
    public TextMeshProUGUI healText;
    private float damageAmount;
    private Vector3 offset = new Vector3(0f, 1.5f, 0f);

    public void TakeDamage(float damage)
    {
        damageAmount = damage;
        UpdateTextheal();
    }
    public void UpdateTextheal()
    {   
        healText.text = "-" + damageAmount.ToString("F0");
        transform.position = transform.parent.position + offset;
        transform.LookAt(Camera.main.transform);  
    }
}

