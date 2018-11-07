using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private Text CountText;
    [SerializeField]
    private Text WinText;
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private float timerStartTime;

    private float timer;
    private bool canCountDown = true;
    private bool doOnce = false;
    private int count;
    private bool canMove = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        WinText.text = "";
        SetCountText();

        timer = timerStartTime;
    }

    void Update()
    {
        if (timer >= 0.0f && canCountDown)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F");
        }
        else if (timer <= 0.0f && !doOnce)
        {
            canCountDown = false;
            doOnce = true;
            timerText.text = "0.00";
            timer = 0.0f;
            canMove = false;
            SetCountText();
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb2d.AddForce(movement*Speed);
        }
        
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
    private void SetCountText()
    {
        CountText.text = "Score: " + count.ToString();
        if (count >= 12)
        {
            WinText.text = "You Win!";
            canCountDown = false;
        }
        else if (count < 12 && !canMove)
        {
            WinText.text = "You lose!";
        }
    }
}
