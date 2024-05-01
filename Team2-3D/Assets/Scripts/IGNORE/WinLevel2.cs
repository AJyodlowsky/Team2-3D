using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel2 : MonoBehaviour
{
    GameManager gMScript;
    // Start is called before the first frame update
    void Start()
    {
        
        gMScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Win();
    }

    public void Win()
    {
        string currentScene;
        currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "WIN")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    



// Update is called once per frame
void Update()
    {
        
    }
}
