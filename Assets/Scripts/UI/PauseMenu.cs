using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject OptionsUI;
    public bool isPausedMenu = false;
    public bool playerLost;
    

    void ActivateMenu()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);

        isPausedMenu = false;
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void ControlsBack()
    {
        OptionsUI.SetActive(false);
    }
    public void Options()
    {
        OptionsUI.SetActive(true);
    }
    public void MenuState()
    {
        isPausedMenu = true;
        ActivateMenu();
    }

}
