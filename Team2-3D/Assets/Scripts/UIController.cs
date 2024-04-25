using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{

    GameManager gMScript;

    private void Start()
    {
        gMScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }



    public void Resume()
    {
        gMScript.mainMenuPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void OnClickQuit()
    {
        Debug.Log("Quit button was clicked");
        Application.Quit();
    }


    public void OnClickHELP()
    {
        SceneManager.LoadScene("HELP");
    }


    public void OnClickCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnClickOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnClickTestScene()
    {
        SceneManager.LoadScene("Test Movement");

    }

    private void Update()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;


    }
}
