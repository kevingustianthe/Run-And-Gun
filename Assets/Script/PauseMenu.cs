using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string mainMenu;
    public GameObject thePauseMenu;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        thePauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        thePauseMenu.SetActive(false);
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        thePauseMenu.SetActive(false);
        FindObjectOfType<GameManager>().Reset();
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }
}
