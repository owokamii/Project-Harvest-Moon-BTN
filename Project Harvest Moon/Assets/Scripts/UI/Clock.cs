using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    [Header("Component")]
    private TMP_Text clockTime;
    private int minute = 0;
    private int hour = 6;
    private bool isNoon = false;


    [Header("Timer Settings")]
    public float currentTime;

    private void Awake()
    {
        isNoon = false;
        enabled = true;
        clockTime = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        currentTime = currentTime += Time.deltaTime;

        if(currentTime >= 5)
        {
            if(minute != 50)
            {
                minute += 10;
            }
            else
            {
                if(hour == 12)
                {
                    hour = 1;
                }
                else
                {
                    hour += 1;
                }
                minute = 0;
            }
            if (hour == 12 && minute == 0)
            {
                if (!isNoon)
                {
                    isNoon = true;
                }
                else
                {
                    isNoon = false;
                }
            }
            currentTime = 0;
            SetTimerText();
            if(hour == 6 && minute == 0 && !isNoon)
            {
                enabled = false;
            }
        }
    }

    private void SetTimerText()
    {
        if(!isNoon)
        {
            clockTime.text = "AM     " + hour.ToString() + " : " + minute.ToString("00");
        }
        else
        {
            clockTime.text = "PM     " + hour.ToString() + " : " + minute.ToString("00");
        }
    }
}