using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class gateManager : MonoBehaviour
{
    private Animator gate; 
    private bool isGateOpen = false;
    public Transform destinationGate; 
    public GameObject tuong;
     
    void Start()
    {
        gate = GetComponent<Animator>();
    }

    void Update()
    {
        GameObject enemy = tuong;
         if (enemy == null)
        {
            gate.SetTrigger("open");
            BoxCollider2D boxCollider = gate.GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                boxCollider.isTrigger = true;
            }
            isGateOpen = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isGateOpen && other.CompareTag("Player"))
        {
            other.transform.position = destinationGate.position - new Vector3(0,1,0);
           
        }
    }
}
