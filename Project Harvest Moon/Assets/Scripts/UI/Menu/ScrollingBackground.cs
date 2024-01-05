using UnityEngine;
using UnityEngine.UI;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private RawImage scrollingBackground;
    [SerializeField] private float x, y;

    private void Update()
    {
        scrollingBackground.uvRect = new Rect(scrollingBackground.uvRect.position + new Vector2(x, y) * Time.deltaTime, scrollingBackground.uvRect.size);
    }
}