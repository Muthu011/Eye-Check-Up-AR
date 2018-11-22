using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserController : MonoBehaviour
{
    public Text MessageDisplay;
    public InputField UserAns;
    public string ans;
    public List<string> alphabets = new List<string> { "E", "F", "P", "T"};
    public int numberofTry=0;
    public int CorrectWords=0;

    public void GetInput(string input)
    {
        string a = input;
        if (a == alphabets[CorrectWords])
        {
            MessageDisplay.text = "Correct! Tell Next Word";
            CorrectWords++;
        }
        else
        {
            MessageDisplay.text = "Try again";
            numberofTry++;
            if (numberofTry > 3)
            {
                Debug.Log("consult doc");
                MessageDisplay.text = "consult doc";
            }
        }
    }

}
