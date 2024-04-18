using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int pickups = 0;
    public TMP_Text pickupText;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateData()
    {
        pickupText.text = "Pickups: " + pickups;
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
