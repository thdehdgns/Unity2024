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
        npcNameText.text = sampleTexts[0].npcName; // Ui�� NPC �̸��� ������ NPC �̸��� ���
        //textComponent.text = sampleTexts[0].sentences[0]; // UI�� ��� ���

        SampleText sampleText = sampleTexts[0]; //ù��° �����͸� �����ͼ� sampletext�� ����
        npcIcon.sprite = Resources.Load<Sprite>($"Album/{sampleTexts[0].ImageName}");

        foreach (string sentecne in sampleText.sentences) //sampletext�� ����� ����鿡 �����Ͽ� ������ sentences�� stringQueue��� �ڷᱸ���� ������
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

        StopAllCoroutines();                      //�ߺ� ��� ����.      
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
