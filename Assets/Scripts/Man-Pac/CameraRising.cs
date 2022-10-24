using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRising : MonoBehaviour
{
    public float speed = 2f;
    static float upperY = 58f;
    static float lowerY = 2.857f;

    // public static float lowerX{ get; set;}
    // public static float upperX{get; set;}

    Vector3 scene = new Vector3(0f,lowerY,-10f);
    // public Text text;



    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(risingScreen());
    }

    IEnumerator risingScreen(){
        yield return new WaitForSeconds(5f);
            transform.Translate(0f,speed*Time.deltaTime, 0f);
        if (transform.position.y >= upperY){
            transform.position = scene;
        }
    }
}
