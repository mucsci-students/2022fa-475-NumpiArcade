using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
        [SerializeField] private Rigidbody2D rb;

    public Vector2 init;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        if(!PlayerController.isAlive){
            rb.position = init;
        }
    }
}
