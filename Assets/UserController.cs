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
    public List<bool> isCorrect = new List<bool>();

    public void GetInput(string input)
    {
        string a = input;
        if (a == alphabets[CorrectWords])
        {
            MessageDisplay.text = "Correct! Tell Next Word";
            bool temp = true;

            isCorrect.Add(temp);
            CorrectWords++;
        }
        else
        {
            MessageDisplay.text = "Try again";
            numberofTry++;
            if (numberofTry > 1)
            {
                bool temp = false;
                isCorrect.Add(temp);
                Debug.Log("consult doc");
                MessageDisplay.text = "consult doc";
                StartCoroutine(MarkDisplay());
            }
        }
    }

    public IEnumerator MarkDisplay()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < isCorrect.Count; i++)
        {
            if (isCorrect[0] != null)
            {
                if (isCorrect[0] == false)
                {
                    MessageDisplay.text = "Your Mark is 20/100";
                }
            }
            else if (isCorrect[1] != null || isCorrect[2] != null)
            {
                Debug.Log("asdsad");
                if (isCorrect[1] == false || isCorrect[2] == false)
                {
                    MessageDisplay.text = "Your Mark is 20/80";
                }
            }
            else if (isCorrect[3] != null)
            {
                if (isCorrect[3] == false)
                {
                    MessageDisplay.text = "Your Mark is 20/60";
                }
            }
        }
    }
}
