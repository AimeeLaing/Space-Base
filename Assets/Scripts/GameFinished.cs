using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinished : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void Exit()
    {
        Application.Quit();
    }
    private void Start()
    {
        //unlocks the cursor
        Cursor.lockState = CursorLockMode.None;
    }
}
