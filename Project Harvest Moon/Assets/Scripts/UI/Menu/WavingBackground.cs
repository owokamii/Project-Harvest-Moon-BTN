using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class WavingBackground : MonoBehaviour
{
    [SerializeField] private RawImage wavingBackground;
    [SerializeField] private float xBack, xForth, y;
    private float timer;

    /* public Transform pointA;
     public Transform pointB;

     public float speed;
     public float amplitude;
     public float amplitudeOffset;

     private void Start()
     {
         transform.position = pointA.position;
     }

     private void Update()
     {
         transform.position = Vector3.Lerp(pointA.position, pointB.position, Mathf.Sin(Time.time * speed) * amplitude + amplitudeOffset);
     }*/

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer <= 3)
        {
            wavingBackground.uvRect = new Rect(wavingBackground.uvRect.position + new Vector2(xBack, y) * Time.deltaTime, wavingBackground.uvRect.size);
        }
        else if(timer >=6)
        {
            wavingBackground.uvRect = new Rect(wavingBackground.uvRect.position + new Vector2(xForth, y) * Time.deltaTime, wavingBackground.uvRect.size);
            timer = 0;
        }
    }
}
