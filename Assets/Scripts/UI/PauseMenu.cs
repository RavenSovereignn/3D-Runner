using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject OptionsUI;
    [SerializeField] private GameObject ShopUI;
    public ShopManager shopManager;
    public bool isPausedMenu = false;
    public bool playerLost;
    

    void ActivateMenu()
    {
        Time.timeScale = 0;
        Debug.Log(Time.timeScale);
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        Debug.Log(Time.timeScale);
        pauseMenuUI.SetActive(false);

        isPausedMenu = false;
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void ControlsBack()
    {
        OptionsUI.SetActive(false);
        ShopUI.SetActive(false);
    }
    public void Options()
    {
        OptionsUI.SetActive(true);
    }
    public void Shop()
    {
        ShopUI.SetActive(true);
        shopManager.LoadShop();
    }
    public void MenuState()
    {
        isPausedMenu = true;
        ActivateMenu();
    }

}
