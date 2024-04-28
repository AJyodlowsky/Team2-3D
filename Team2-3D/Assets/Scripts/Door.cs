using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{

    GameManager gMScript;

    //public GameObject enoughPickupsText;

    public Animator door;
    public GameObject openText;

    public bool inReach;

    // Start is called before the first frame update
    void Start()
    {
        //enoughPickupsText.SetActive(false);

        gMScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();


        inReach = false; 
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Reach")
        {
            inReach = true;
           openText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }




    // Update is called once per frame
    void Update()
    {
        if (inReach && gMScript.pickups == 3 && Input.GetKeyDown(KeyCode.E))
        {
            DoorOpens();
        }
        else
        {
            DoorCloses();
        }

    }


    void DoorOpens()
    {
        
        door.SetBool("Open", true);
        door.SetBool("Closed", false);
    }


    void DoorCloses()
    {
        
        door.SetBool("Open", false);
        door.SetBool("Closed", true);
    }

}
