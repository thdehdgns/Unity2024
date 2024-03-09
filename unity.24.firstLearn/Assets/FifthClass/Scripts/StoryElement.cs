using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryElement : MonoBehaviour
{
    private Dialogue dialogue;
    public int dialogueID;

    public void TriggerDialouge(int dialogueID)
    {
        dialogue = DialogueData.Instance.dialogueDatas[dialogueID];

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
