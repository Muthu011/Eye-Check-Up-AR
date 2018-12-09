using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public GameObject Menu;

    public void DrawMenu()
    {
        Menu.SetActive(true);
    }

    public void ClearScreen()
    {
        Menu.SetActive(false);

    }
}
