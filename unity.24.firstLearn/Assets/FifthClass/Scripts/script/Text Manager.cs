    using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI npcNameText;
    public Image npcIcon;

    public string iconID;

    public Queue<string> stringQueue;

    public float typeSpeed;

    public GameObject TextParent;

    public void Awake()
    {
           stringQueue = new Queue<string>();
    }

    private void Start()
    {
        //npcIcon.sprite = Resources.Load<Sprite>($"Album/{iconID}");
    }

    public void StartText(SampleText[] sampleTexts)
    {
        TextParent.SetActive(true);
        npcNameText.text = sampleTexts[0].npcName; // Ui의 NPC 이름에 저장한 NPC 이름을 출력
        //textComponent.text = sampleTexts[0].sentences[0]; // UI의 대사 출력

        SampleText sampleText = sampleTexts[0]; //첫번째 데이터를 가져와서 sampletext에 저장
        npcIcon.sprite = Resources.Load<Sprite>($"Album/{sampleTexts[0].ImageName}");

        foreach (string sentecne in sampleText.sentences) //sampletext에 저장된 문장들에 접근하여 각각의 sentences를 stringQueue라는 자료구조에 저장함
        {
            stringQueue.Enqueue(sentecne);
        }
    }

    public void DisplayNextSentence()
    {
        

        if(stringQueue.Count == 0)
        {
            TextParent.SetActive(false);
            return;
        }

        string sentence = stringQueue.Dequeue();

        StopAllCoroutines();                      //중복 출력 방지.      
        StartCoroutine(TypeSentence(sentence));   //
    }
    
    IEnumerator TypeSentence(string sentence)
    {
        textComponent.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

}
