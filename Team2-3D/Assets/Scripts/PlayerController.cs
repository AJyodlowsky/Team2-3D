using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// this works so good imma gonna beat up an eldery woman
public class PlayerController : MonoBehaviour
{

    GameManager gMScript;

    [SerializeField] int health = 3;

    public float moveSmoothTime;
    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;
    public float gravityStrength;
    

    // DON'T TOUCH MY CODE YOU HEATHENS
    
    private CharacterController Controller;
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVelocity;

    private Vector3 CurrentForceVelocity;


    // Start is called before the first frame update
    void Start()
    {
        gMScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        gMScript.UpdateData();
        

        Controller = GetComponent<CharacterController>();

        gMScript.Level2WinCondition(); //why work pls


    }


   





    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Damage"))
        {
            //Destroy(other.gameObject);
            gMScript.TakeDamage();
            health--;
            ///gMScript.audioSource.clip = gMScript.gotHurtSFX;
            ///gMScript.audioSource.Play();
            
        }


        if (other.CompareTag("Lvl2")) //add transition here
        {
            SceneManager.LoadScene("LevelTwo");
        }

    }


    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerInput = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),

            y = 0f,

            z = Input.GetAxisRaw("Vertical")
        };


        if (PlayerInput.magnitude > 1f)
        {
            PlayerInput.Normalize();
        }

        Vector3 MoveVector = transform.TransformDirection(PlayerInput);
        float CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;


        CurrentMoveVelocity = Vector3.SmoothDamp(
            CurrentMoveVelocity,
            MoveVector * CurrentSpeed,
            ref MoveDampVelocity,
            moveSmoothTime

        );

        Controller.Move(CurrentMoveVelocity * Time.deltaTime);


        Ray groundCheckRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(groundCheckRay, 1.1f))
        {
            CurrentForceVelocity.y = -2f;

            if(Input.GetKey(KeyCode.Space))
            {
                CurrentForceVelocity.y = jumpForce;
            }
        }
        else
        {
            CurrentForceVelocity.y -= gravityStrength * Time.deltaTime;
        }


        Controller.Move(CurrentForceVelocity * Time.deltaTime);
    }



    //private void //OnTriggerEnter(Collider other)
   // {
        //if(other.CompareTag("Pickup"))
      //  {
          //  gMScript.pickups++;
          //  gMScript.UpdateData();
         //   Destroy(other.gameObject);
       // }
    //}

















}
