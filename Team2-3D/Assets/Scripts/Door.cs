using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public Animator door;
    public GameObject openText;

    public bool inReach;

    // Start is called before the first frame update
    void Start()
    {
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
        if (inReach && Input.GetKeyDown(KeyCode.E))
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
        Debug.Log("Opens");
        door.SetBool("Open", true);
        door.SetBool("Closed", false);
    }


    void DoorCloses()
    {
        Debug.Log("Closes");
        door.SetBool("Open", false);
        door.SetBool("Closed", true);
    }

}
