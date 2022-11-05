using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRising : MonoBehaviour
{
     public float speed = 1;

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(risingScreen());
    }

    IEnumerator risingScreen(){
        yield return new WaitForSeconds(10f);
            transform.Translate(0f,speed*Time.deltaTime, 0f);
        // if (transform.position.y >= upperY){
        //     transform.position = scene;
        // }
    }
}
