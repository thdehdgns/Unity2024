using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texttriger : MonoBehaviour
{
    public SampleText[] sampletext;

    private SampleText loadText;
    private void Start()
    {
        //TriggerText(sampletext);
    }

    public void TriggerText(SampleText[] sampleTexts)
    {
        FindObjectOfType<TextManager>().StartText(sampleTexts);
    }
    public void TriggerText()
    {
        FindObjectOfType<TextManager>().StartText(sampletext);
    }
}
