using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToInit : MonoBehaviour
{
    public Vector2 init;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerController.isAlive){
            Debug.Log(init);
            rb.position = init;
            rb.position = init;
            rb.position = init;
            rb.position = init;
            rb.position = init;
            rb.position = init;

        }
    }
}
