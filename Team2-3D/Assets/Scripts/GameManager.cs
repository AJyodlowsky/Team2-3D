using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int pickups = 0;
    public TMP_Text pickupText;

    public GameObject mainMenuPanel;


    // Start is called before the first frame update
    void Start()
    {
        mainMenuPanel.SetActive(false);
    }

    public void UpdateData()
    {
        
        pickupText.text = "Pickups: " + pickups;
    }




    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Q))
        {
            mainMenuPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }
}
