using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class SampleText
{
    // ¿£ÇÇ¾¾ ÀÌ¸§
    public int sceneID;
    public string npcName;
    public string ImageName;
  
    [TextArea(3, 10)]
    public string[] sentences;
}

[System.Serializable]
public class SampleTextlist
{
    public SampleText[] SampleTexts;
}

