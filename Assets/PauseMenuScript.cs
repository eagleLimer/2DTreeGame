using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public bool gameIsPaused = false;
    public GameObject pauseMenuUi;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    void PauseGame()
    {
        gameIsPaused = true;
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        gameIsPaused = false;
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1;
    }
}
