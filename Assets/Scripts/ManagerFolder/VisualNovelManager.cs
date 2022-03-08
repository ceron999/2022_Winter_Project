using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualNovelManager : MonoBehaviour
{
    [SerializeField] GameObject leftCharacter;
    [SerializeField] GameObject rightCharacter;

    [SerializeField] GameObject talkUI;
    [SerializeField] GameObject leftName;
    [SerializeField] GameObject rightName;

    [SerializeField] Text contextText;
    [SerializeField] Text leftNameText;
    [SerializeField] Text rightNameText;

    bool isDialogue = false;
    bool isNext = false;

    private void Start()
    {
        ShowTalkUI();
        contextText.text = "";
    }

    void ShowTalkUI()
    {
        talkUI.SetActive(true);
    }
}
