using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 moveInput;
    private bool isPaused = false;
    public GameObject pausePanel;
    public enegryPlayercontroller enegryPlayer;
    [SerializeField] private float enegryMax = 100;
    [SerializeField] private float enegryNow;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        pausePanel.SetActive(isPaused);
        enegryNow = enegryMax;
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.sqrMagnitude);
        if (moveInput.x != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift) && enegryNow > 0)
            {
                moveSpeed = 20f;
            }
            else
            {
                moveSpeed = 10f;
            }
            if (moveInput.x > 0)
                transform.localScale = new Vector3(1, 1, 0);
            else
                transform.localScale = new Vector3(-1, 1, 0);
        }
        transform.position += moveInput * moveSpeed * Time.deltaTime;
        UpdateEnegry();
        if (Input.GetKeyDown(KeyCode.R))
        {
            isPaused = !isPaused;
            if (isPaused == true)
            {
                Time.timeScale = 0;
                pausePanel.SetActive(isPaused);
            }
            else
            {
                Time.timeScale = 1;
                pausePanel.SetActive(isPaused);
            }
        }
    }
    public void UpdateEnegry()
    {
        if (moveSpeed == 20f)
        {
            enegryNow = enegryNow - 10 * Time.deltaTime;
            enegryPlayer.UpdateBar(enegryNow, enegryMax);
            if (enegryNow < 0)
            {
                enegryNow = 0;
            }
        }
        else
        {
            enegryPlayer.UpdateBar(enegryNow, enegryMax);
            enegryNow = enegryNow + 2 * Time.deltaTime;
            if (enegryNow > enegryMax)
            {
                enegryNow = enegryMax;
            }
        }
    }
}
