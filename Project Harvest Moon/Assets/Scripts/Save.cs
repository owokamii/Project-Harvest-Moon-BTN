using UnityEngine;

public class Save : MonoBehaviour
{
    public void SavePlayer()
    {
        //SaveSystem.SaveClock(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();


    }
}
