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

    private void Start()
    {
        npcIcon.sprite = Resources.Load<Sprite>($"Album/{iconID}");
    }

    public void StartText(SampleText[] sampleTexts)
    {
        npcNameText.text = sampleTexts[0].npcName;
        textComponent.text = sampleTexts[0].sentences[0];

        SampleText sampleText = sampleTexts[0];

        //foreach(string sentecne in sampleTexts.sentences)
        //{
        //    stringQueue.Enqueue(sentecne);
        //}
    }

    
}
