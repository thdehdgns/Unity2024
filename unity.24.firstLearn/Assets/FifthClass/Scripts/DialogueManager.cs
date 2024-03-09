using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI nameText;
    public Queue<string> sentences;
    public float textSpeed;

    public Animator animator;

    public Image npcImage;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        sentences.Clear();

        nameText.text = dialogue.name;


        npcImage.sprite = Resources.Load<Sprite>($"Album/{dialogue.ImageName}");

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
    }



    public void DisplayerNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        textComponent.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            textComponent.text += letter;

            yield return new WaitForSeconds(textSpeed);
        }
    }


    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
