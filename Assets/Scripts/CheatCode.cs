using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCode : MonoBehaviour
{
    private int[] konamiCode = {0, 0, 1, 1, 2, 3, 2, 3, 4, 5};
    private int[] input = new int[10];
    public int count = 0;
    public int cheater = 0;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            input[count] = 0;
            count = count + 1;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            input[count] = 1;
            count = count + 1;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            input[count] = 2;
            count = count + 1;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            input[count] = 3;
            count = count + 1;
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            input[count] = 4;
            count = count + 1;
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            input[count] = 5;
            count = count + 1;
        }
        if(Input.GetKeyDown(KeyCode.Delete))
        {
            count = 0;
        }
        if(count == 10)
        {
            for(int i = 0; i < 10; i++)
            {
                if(konamiCode[i] != input[i])
                {
                    count = 0;
                    break;
                }
            }
            if(count == 10)
            {
                cheater = 1;
            }
        }
    }
}
