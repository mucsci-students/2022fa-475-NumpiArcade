using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keeps : MonoBehaviour
{
    // Start is called before the first frame update
    public static int deaths = 0;
    public static int lives = 3;
    public static int Score = 0;
    


    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
    }
}
