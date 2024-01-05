using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    [Header("References")]
    public TMP_Text time;
    public TMP_Text day;
    public TMP_Text date;

    [HideInInspector] public int minute = 0;
    [HideInInspector] public int hour = 6;
    private bool isNoon = false;
    private string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

    [Header("Timer Settings")]
    public float currentTime;

    private void Awake()
    {
        isNoon = false;
        enabled = true;
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
            time.text = "AM     " + hour.ToString() + " : " + minute.ToString("00");
        }
        else
        {
            time.text = "PM     " + hour.ToString() + " : " + minute.ToString("00");
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SaveClock(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        currentTime = data.currentTime;
        hour = data.hour;
        minute = data.minute;
    }
}