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
        Level2WinCondition();
    }


    public void Level2WinCondition()
    {
        string currentScene;
        currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "LevelTwo" && gMScript.pickups == 3)
        {
            SceneManager.LoadScene("WIN");
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
