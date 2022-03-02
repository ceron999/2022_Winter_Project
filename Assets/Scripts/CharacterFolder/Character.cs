using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour //, IDropHandler
{
    public bool isStriker;
    public bool isSupporter;

    public int Character_ID;
    public string Character_Name;
    public int Health;
    public int Speed;

    public string strikerExplanation;
    public string characteristic;
}
