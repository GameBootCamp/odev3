using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sonucmanager : MonoBehaviour
{
    
 public void oyunayenidenbasla()
 {
    SceneManager.LoadScene("gamelevel");
 }

 public void anamenuyedon()
 {
SceneManager.LoadScene("menulevel");
 }

}
