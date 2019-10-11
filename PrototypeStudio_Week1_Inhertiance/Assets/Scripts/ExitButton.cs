using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public KeyCode exitGameKey;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckResetScene(exitGameKey);
    }

    void CheckResetScene(KeyCode exitGame)
    {
        if (Input.GetKey(exitGame))
        {
            Application.Quit();
            Debug.Log("Palmmy, someone exit your game.");
        }
    }
}
