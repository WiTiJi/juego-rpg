using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowOptions()
    {
        Debug.Log("abre opciones");
    }

    public void QuitOptions()
    {
        Debug.Log("cierra opciones");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}