using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ControlsBack()
    {
        //OptionsUI.SetActive(false);
    }
    public void Options()
    {
       // OptionsUI.SetActive(true);
    }
}
