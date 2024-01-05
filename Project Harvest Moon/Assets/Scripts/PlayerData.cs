[System.Serializable]
public class PlayerData
{
    public float currentTime;
    public int hour;
    public int minute;

    public PlayerData(Clock clock)
    {
        currentTime = clock.currentTime;
        hour = clock.hour;
        minute = clock.minute;
    }
}
