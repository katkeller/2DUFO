using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text timerText;

    [SerializeField]
    private float timerStartTime;

    private float timer;
    private bool canCountDown = true;
    private bool doOnce = false;

    private void Start()
    {
        timer = timerStartTime;
    }

    void Update()
    {
        if (timer >= 0.0f && canCountDown)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F");
        }
        else if (timer<= 0.0f && !doOnce)
        {
            canCountDown = false;
            doOnce = true;
            timerText.text = "0.00";
            timer = 0.0f;
        }
    }
}
