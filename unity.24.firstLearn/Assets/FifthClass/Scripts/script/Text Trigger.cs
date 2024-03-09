using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texttriger : MonoBehaviour
{
    public SampleText[] sampletext;

    private void Start()
    {
        TriggerText(sampletext);
    }

    public void TriggerText(SampleText[] sampleTexts)
    {
        FindObjectOfType<TextManager>().StartText(sampleTexts);
    }
}
