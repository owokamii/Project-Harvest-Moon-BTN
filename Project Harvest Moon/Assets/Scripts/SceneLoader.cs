using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private Animator animator;
    private Image fade;
    [SerializeField] private int levelToLoad;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        fade = GetComponentInChildren<Image>();
        fade.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        FadeToLevel(levelToLoad);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
