using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{

    GameManager gMScript;

    public GameObject pickupOBJ;
   

    public GameObject pickupText;

    public bool hasPickUp; //this is will be used for later. If we want to store certain pickups in places. 

    public bool inReach;


    // Start is called before the first frame update
    void Start()
    {
        gMScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        inReach = false;    
        hasPickUp = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickupText.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickupText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inReach == true && Input.GetKeyUp(KeyCode.E))
        {
            gMScript.pickups++;
            gMScript.UpdateData();
            hasPickUp = true;
            pickupOBJ.SetActive(false);
            pickupText.SetActive(false);
        }
    }


    


}
