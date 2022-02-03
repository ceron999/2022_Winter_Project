using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class CharacterManager_K : MonoBehaviour
{
    public List<GameObject> charList = new List<GameObject>();
    GameObject highlightedChar = null;

    public Camera getCamera;
    //레이케스트가 건드린 것을 취득해서 넣어두는 곳
    private RaycastHit hit;

    //text관련 출력을 위한 text모음들
    public Text charDetailText;
    public Text characteristicText;


    void Update()
    {
        //마우스 클릭시
        if (Input.GetMouseButtonDown(0))
        {
            //마우스 포지션을 취득해서 대입해
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);

            //마우스 포지션에서 레이를 던져서 뭔가가 걸리면 hit에 넣음
            if(Physics.Raycast(ray, out hit))
            {
                GameObject hitTarget = hit.collider.gameObject;
                

                if (!highlightedChar) //선택된게 없는 경우 선택하면
                {
                    hitTarget.GetComponent<Renderer>().material.color = Color.yellow;
                    highlightedChar = hitTarget;
                    //선택한 캐릭터의 플레이 스타일 설명
                    charDetailText.text = hitTarget.GetComponent<Characters>().character_detail;
                    characteristicText.text = hitTarget.GetComponent<Characters>().characteristic;
                }

                else if (hitTarget != highlightedChar) //캐릭터 선택한 상태에서 캐릭터 이외의 다른 것을 누를 경우
                {
                    highlightedChar.GetComponent<Renderer>().material.color = new Color(143f / 255f, 170f / 255f, 220f / 255f); //선택상태 해제

                    highlightedChar = hitTarget;

                    charDetailText.text = null;
                    characteristicText.text = null;
                }
            }
        }
    }
}
