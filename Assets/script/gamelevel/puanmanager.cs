using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puanmanager : MonoBehaviour
{
    private int toplampuan;
    private int puanartisi;

    [SerializeField]
    private Text puanText;
    void Start()
    {
        puanText.text = toplampuan.ToString();
    }
public void PuanArtir(string seviye)
{
    switch(seviye)
    {
        case "kolay":
        puanartisi = 5;
        break;
        case "orta":
        puanartisi = 10;
        break;
        case "zor":
        puanartisi = 15;
        break;
        
    }
    toplampuan += puanartisi;
    puanText.text = toplampuan.ToString();
}
}
