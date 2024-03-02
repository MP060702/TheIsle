using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnType : MonoBehaviour
{   
    
    public void OnBtnClick1()
    {
        SceneManager.LoadScene("Tuto");
    }

    public void OnBtnClick2()
    {
        Application.Quit();
    }

    public void OnBtnClick3()
    {
        SceneManager.LoadScene("InGame");
    }

    public void OnBtnClick4()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
