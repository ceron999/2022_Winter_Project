using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance : MonoBehaviour
{
    public GameObject gilbertStriker;
    public GameObject gilbertSupporter;
    public GameObject walwhaStriker;
    public GameObject walwhaSupporter;
    public GameObject patrickStriker;
    public GameObject patrickSupporter1;
    public GameObject patrickSupporter2;
    public GameObject gilbert;
    public GameObject walwha;
    public GameObject patrick;
    bool gbool, wbool, pbool;
    
    // Start is called before the first frame update
    void Start()
    {
        gbool = gilbert.GetComponent<Character>().isStriker;
        wbool = walwha.GetComponent<Character>().isStriker;
        pbool = patrick.GetComponent<Character>().isStriker;
        appear();
    }

    // Update is called once per frame
    public void appear()
    {
       if(gbool)
        {
            walwhaStriker.SetActive(false);
            patrickStriker.SetActive(false);
            patrickSupporter1.SetActive(false);
            gilbertSupporter.SetActive(false);
        }
       else if(wbool)
        {
            gilbertStriker.SetActive(false);
            patrickStriker.SetActive(false);
            walwhaSupporter.SetActive(false);
            patrickSupporter2.SetActive(false);
        }
       else if(pbool)
       {
           gilbertStriker.SetActive(false);
           walwhaStriker.SetActive(false);
           patrickSupporter1.SetActive(false);
           patrickSupporter2.SetActive(false);
       }
    }
    
}
