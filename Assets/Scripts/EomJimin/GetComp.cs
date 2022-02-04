using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetComp : MonoBehaviour
{
    public Text charDetailText;
    public Text characteristicText;
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void click()
    {
        Character getObjInfo = character.GetComponent<Character>();
        charDetailText.text = getObjInfo.charInfo.Character_Detail;
        characteristicText.text = getObjInfo.charInfo.Characteristic;
    }
}
