using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMneu : MonoBehaviour
{
    public void PlaySingle() {
        SceneManager.LoadScene(1);
;    }
    public void PlayOnline()
    {
        SceneManager.LoadScene(2);       
    }
    public void Quit()
    {
        Application.Quit();
    }
}
