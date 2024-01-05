using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject currentDialogue;
    public GameObject nextDialogue;

    [TextArea] public string[] lines;
    public float textSpeed;

    private TMP_Text texts;
    private Image dialogueBox;
    private int index;

    private void Start()
    {
        texts = GetComponent<TMP_Text>();
        dialogueBox = GetComponentInParent<Image>();
        texts.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        // needs to be changed in the future
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(texts.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                texts.text = lines[index];
            }
        }

        if(currentDialogue.activeInHierarchy == false)
        {
            if(nextDialogue != null)
            {
                nextDialogue.SetActive(true);
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char C in lines[index].ToCharArray())
        {
            texts.text += C;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            texts.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            dialogueBox.gameObject.SetActive(false);
        }
    }
}
