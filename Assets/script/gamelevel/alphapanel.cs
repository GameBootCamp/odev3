﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class alphapanel : MonoBehaviour
{
    public GameObject panel;
    void Start()
    {
        panel.GetComponent<CanvasGroup>().DOFade(0,2f);
    } 

    
}
