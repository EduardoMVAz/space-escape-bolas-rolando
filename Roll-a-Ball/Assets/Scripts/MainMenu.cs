using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject infoMenu;
    public void PlayGame() {
        SceneManager.LoadScene("MainGame");
    }

    public void Info() {
        mainMenu.SetActive(false);
        infoMenu.SetActive(true);
    }

    public void CloseInfo() {
        mainMenu.SetActive(true);
        infoMenu.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
