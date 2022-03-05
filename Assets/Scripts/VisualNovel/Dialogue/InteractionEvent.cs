using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    [SerializeField] DialogueEvent dialogueEvent;

    public Dialogue[] GetDiaLogue()
    {
        dialogueEvent.dialogues = DataBaseManager.dataBaseManager.GetDialogues((int)dialogueEvent.line.x,(int)dialogueEvent.line.y);
        return dialogueEvent.dialogues;    
    }
}
