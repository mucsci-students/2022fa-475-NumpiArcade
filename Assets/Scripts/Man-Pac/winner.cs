using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StallRead(10f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator StallRead(float time){
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("MPStage1");
    }
}
