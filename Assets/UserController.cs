using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserController : MonoBehaviour
{
    public Text MessageDisplay;
    //public List<RowOfLetters> rowOfLetters = new List<RowOfLetters>();

    public InputField UserAns;
    public string ans;
    public List<string> alphabets = new List<string> { "E", "F", "P", "T"};
    public int numberofTry=0;
    public int CurrentWord=0;
    public List<bool> isCorrect = new List<bool>();
    public InputController inputController;



    public void GetInput(string input)
    {
        Debug.Log(CurrentWord);
        Debug.Log(input);
        string a = input;
        UserAns.text = "";
        if (a == alphabets[CurrentWord])
        {
            //MessageDisplay.text = "Correct! Tell Next Word";
            MessageSystem("Correct! Tell Next Word");
            bool temp = true;

            isCorrect.Add(temp);
            CurrentWord++;
        }
        else
        {
            //MessageDisplay.text = "Try again";
            MessageSystem("Try again");

            numberofTry++;
            if (numberofTry > 1)
            {
                bool temp = false;
                isCorrect.Add(temp);
                Debug.Log("consult doc");
                MessageDisplay.text = "consult doc";
                MessageSystem("consult doc");

                StartCoroutine(MarkDisplay());
            }
        }
        ////for (int i = 0; i < rowOfLetters.Count; i++)
        ////{
        //    for (int j = 0; j < rowOfLetters[CurrentWord].alphabets.Length; j++)
        //    {
        //    Debug.Log(rowOfLetters[CurrentWord].alphabets.Length);
        //        if (a == rowOfLetters[CurrentWord].alphabets[j])
        //        {
        //            MessageDisplay.text = "Correct";
        //            rowOfLetters[CurrentWord].isRight[j] = true;
        //        }
        //        else if (a != rowOfLetters[CurrentWord].alphabets[j])
        //        {
        //        Debug.Log(CurrentWord);
        //        Debug.Log(input);
        //        Debug.Log(rowOfLetters[CurrentWord].isRight[j]);
        //            MessageDisplay.text = "Wrong";
        //            numberofTry++;
        //            if (numberofTry > 1)
        //            {
        //                rowOfLetters[CurrentWord].isRight[j] = false;
        //                MessageDisplay.text = "consult doc";
        //                StartCoroutine(MarkDisplay());
        //            }
        //        }      
        //}
        //    for(int k=0;k<rowOfLetters[CurrentWord].isRight.Length;k++)
        //    { 
        //        if (rowOfLetters[CurrentWord].isRight[k] == true)
        //        {
        //            CurrentWord++;
        //        }

        //    }

    }


    public IEnumerator MarkDisplay()
    {
        yield return new WaitForSeconds(0.5f);
        //for (int j = 0; j < rowOfLetters[CurrentWord].isRight.Length; j++)
        //{
        if (isCorrect[0] != null)
        {
            if (isCorrect[0] == false)
            {
                //MessageDisplay.text = "Your Mark is 20/100";
                MessageSystem("Your Mark is 20/100");

            }
        }
        else if (isCorrect[1] != null || isCorrect[2] != null)
        {
            Debug.Log("asdsad");
            if (isCorrect[1] == false || isCorrect[2] == false)
            {
                //MessageDisplay.text = "Your Mark is 20/80";
                MessageSystem("Your Mark is 20/80");

            }
        }
        else if (isCorrect[3] != null)
        {
            if (isCorrect[3] == false)
            {
                //MessageDisplay.text = "Your Mark is 20/60";
                MessageSystem("Your Mark is 20/60");

            }
            //if (rowOfLetters[CurrentWord].isRight[j] == false)
            //{
            //    MessageDisplay.text = "your mark is low" +rowOfLetters[CurrentWord].mark ;
            //}
        }
    }

    public IEnumerator MessageSystem(string message)
    {
        yield return new WaitForSeconds(0.2f);

        MessageDisplay.text = message;

        yield return new WaitForSeconds(3f);

        MessageDisplay.text = "";

    }

}

//[System.Serializable]
//public class RowOfLetters
//{
//    public int a;
//    public string[] alphabets;
//    public bool[] isRight;
//    public float mark;
//}
