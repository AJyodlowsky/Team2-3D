using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    GameManager gMScript;
    public GameObject player;

    NavMeshAgent agent;

    [SerializeField] LayerMask groundLayer, playerLayer;

    Vector3 destpoint;
    bool walkPointSet;
    [SerializeField] float range;


    [SerializeField] float sightRange, attackRange;
    public bool playerInSight, playerInAttackRange;

    void Patrol()
    {
        if (!walkPointSet) SearchForDest();
        if(walkPointSet) agent.SetDestination(destpoint);
        if(Vector3.Distance(transform.position, destpoint) < 10) walkPointSet = false;       
    }

    void Chase()
    {
        
        agent.SetDestination(player.transform.position);
    }


    void Attack()
    {

    }


    void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);
        destpoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if(Physics.Raycast(destpoint, Vector3.down, groundLayer))
        {
            walkPointSet = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        gMScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);


        if(!playerInSight && !playerInAttackRange) Patrol();
        if (playerInSight && !playerInAttackRange)
        {
            Chase();
            gMScript.audioSource.clip = gMScript.SnakeSFX;
            gMScript.audioSource.Play();
        }        
        if (playerInSight && playerInAttackRange) Attack();
    }
}
