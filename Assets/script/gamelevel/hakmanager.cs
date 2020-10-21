using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hakmanager : MonoBehaviour
{
  [SerializeField]
  private GameObject hak1, hak2, hak3;
   

public void haklarıKontrolEt(int hak)
{
    switch(hak)
    {
        case 3:
        hak1.SetActive(true);
        hak2.SetActive(true);
        hak3.SetActive(true);
        break;

        case 2:
         hak1.SetActive(true);
        hak2.SetActive(true);
        hak3.SetActive(false);
        break;
case 1:
         hak1.SetActive(true);
        hak2.SetActive(false);
        hak3.SetActive(false);
        break;

        case 0 :
         hak1.SetActive(false);
        hak2.SetActive(false);
        hak3.SetActive(false);
        break;

    }
}
   
}
