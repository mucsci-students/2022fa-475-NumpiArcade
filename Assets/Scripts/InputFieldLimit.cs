using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldLimit : MonoBehaviour
{
    public TextMeshProUGUI initials;
    public Button confirmButton;
    public string[] legalKeys;
    public int counter = 0;
    
    void Update()
    {
        if(counter == 3)
        {
            confirmButton.interactable = true;
        }
        else
        {
            confirmButton.interactable = false;
        }

        foreach(string letter in legalKeys)
        {
            if(letter == Input.inputString && Input.inputString != "")
            {
                if(counter == 2)
                {
                    initials.SetText(initials.text.Substring(0, 2) + letter.ToUpper());
                    counter += 1;
                }
                else if(counter == 1)
                {
                    initials.SetText(initials.text.Substring(0, 1) + letter.ToUpper() + "_");
                    counter += 1;
                }
                else if(counter == 0)
                {
                    initials.SetText(letter.ToUpper() + "__");
                    counter += 1;
                }
                break;
            }
        }

        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            if(counter == 3)
            {
                initials.SetText(initials.text.Substring(0, 2) + "_");
                counter -= 1;
            }
            else if(counter == 2)
            {
                initials.SetText(initials.text.Substring(0, 1) + "__");
                counter -= 1;
            }
            else if(counter == 1)
            {
                initials.SetText("___");
                counter -= 1;
            }
        }
    }
}
