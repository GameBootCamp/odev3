using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using DG.Tweening;
using UnityEngine.SceneManagement;

public class menumanager : MonoBehaviour
{
   [SerializeField]
   private GameObject startButton, exitbutton;
    void Start()
    {
       FadeOut();
    }
void FadeOut()
{
    startButton.GetComponent<CanvasGroup>().DOFade(1,0.8f);
    exitbutton.GetComponent<CanvasGroup>().DOFade(1,0.8f);
} 

public void ExitGame()
{
    Application.Quit();
}

public void StartGameLevel()
{
   SceneManager.LoadScene("gameLevel");
}
    
}
