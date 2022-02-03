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
    //�����ɽ�Ʈ�� �ǵ帰 ���� ����ؼ� �־�δ� ��
    private RaycastHit hit;

    //text���� ����� ���� text������
    public Text charDetailText;
    public Text characteristicText;


    void Update()
    {
        //���콺 Ŭ����
        if (Input.GetMouseButtonDown(0))
        {
            //���콺 �������� ����ؼ� ������
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);

            //���콺 �����ǿ��� ���̸� ������ ������ �ɸ��� hit�� ����
            if(Physics.Raycast(ray, out hit))
            {
                GameObject hitTarget = hit.collider.gameObject;
                

                if (!highlightedChar) //���õȰ� ���� ��� �����ϸ�
                {
                    hitTarget.GetComponent<Renderer>().material.color = Color.yellow;
                    highlightedChar = hitTarget;
                    //������ ĳ������ �÷��� ��Ÿ�� ����
                    charDetailText.text = hitTarget.GetComponent<Characters>().character_detail;
                    characteristicText.text = hitTarget.GetComponent<Characters>().characteristic;
                }

                else if (hitTarget != highlightedChar) //ĳ���� ������ ���¿��� ĳ���� �̿��� �ٸ� ���� ���� ���
                {
                    highlightedChar.GetComponent<Renderer>().material.color = new Color(143f / 255f, 170f / 255f, 220f / 255f); //���û��� ����

                    highlightedChar = hitTarget;

                    charDetailText.text = null;
                    characteristicText.text = null;
                }
            }
        }
    }
}
