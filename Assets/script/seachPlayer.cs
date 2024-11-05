using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seachPlayer : MonoBehaviour

{
    public float movementSpeed = 15f;
    public float detectionRange = 25f;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float attackCooldown = 0.5f;
    public Animator animator;
    public float x;
    private Rigidbody2D rb;
    private Vector3 Position;

    [SerializeField] private GameObject player;
    private bool isPlayerDetected = false;
    private float lastAttackTime;

    private void Start()
    {
        player = GameObject.Find("PLAYER");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Position = transform.position;
    }

    private void Update()
    {
        seachplayer();
    }
    public void seachplayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= detectionRange)
        {
            isPlayerDetected = true;
        }
        else
        {   
            isPlayerDetected = false;
        }

        
        if (isPlayerDetected)
        {
            animator.SetTrigger("walk");
             transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
             if(transform.position != Position )
            {
                animator.SetTrigger("walk");
                if ((transform.position.x - Position.x) < 0){
                    transform.localScale = new Vector3(-x,x,0);
                    Position = transform.position;}
                else {
                    transform.localScale= new Vector3(x,x,0);
                    Position = transform.position;}
            }

            if (distanceToPlayer <= attackRange && Time.time - lastAttackTime >= attackCooldown)
            {
                Debug.Log("tancong");
                lastAttackTime = Time.time;
            }
        }
    }
 

}
