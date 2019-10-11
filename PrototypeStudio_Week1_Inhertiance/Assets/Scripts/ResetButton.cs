using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public KeyCode resetSceneKey;
    public KeyCode resetGameKey;

    void Start()
    {
        Debug.Log("Palmmy, this scene is loaded.");
    }

    // Update is called once per frame
    void Update()
    {
        CheckResetScene(resetSceneKey);
    }

    void CheckResetScene(KeyCode resetScene)
    {
        if (Input.GetKey(resetScene))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
