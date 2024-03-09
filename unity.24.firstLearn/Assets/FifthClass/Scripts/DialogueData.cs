using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueData : MonoBehaviour
{
    private static DialogueData instance;
    public static DialogueData Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new DialogueData();
            }

            return instance;
        }
    }

    public string jsonName;
    public DialogueList dialouges = new DialogueList();
    public Dictionary<int, Dialogue> dialogueDatas = new Dictionary<int, Dialogue>();

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void LoadData()
    {
        TextAsset jsonString = Resources.Load<TextAsset>($"JsonData/{jsonName}");
        dialouges = JsonUtility.FromJson<DialogueList>(jsonString.text);

        for (int i = 0; i < dialouges.dialogues.Length; i++)
        {
            dialogueDatas.Add(dialouges.dialogues[i].sceneID, dialouges.dialogues[i]);
            
        }    
    }

    private void Start()
    {
        LoadData();
    }

    public Dialogue ReturnDialogueByID(int dialogueID)
    {
        Dialogue newDialouge = new Dialogue();
        newDialouge.sceneID = dialogueID;
        newDialouge.name = dialogueDatas[dialogueID].name;
        newDialouge.ImageName = dialogueDatas[dialogueID].ImageName;
        newDialouge.sentences = dialogueDatas[dialogueID].sentences;

        return newDialouge;
    }
}
