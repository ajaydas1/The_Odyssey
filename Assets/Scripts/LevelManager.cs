using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField]GameObject UI;
    [SerializeField]Transform Player;

   void Update()
    {
      if (Player == null) Restart();
      if (Player.position.y < -10) Restart();
      if(Input.GetKeyDown(KeyCode.Backspace))
      {
         Restart();
      }

      if(Input.GetKeyDown(KeyCode.Q))
      {
        Quit();
      }

      
      if(isPaused)Pause(); else Resume();
      
      if(Input.GetKeyDown(KeyCode.Escape))
      {
        if(isPaused) isPaused = false; else isPaused = true;
      }

    }

    public void Restart()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
      Application.Quit();
    }

    public void Resume()
    {
      Time.timeScale = 1f;
      if(UI != null)UI.SetActive(false);
      isPaused = false;
    }

    public void Pause()
    {
      Time.timeScale = 0f;
      if(UI != null)UI.SetActive(true);
      isPaused = true;
      
    }

    public void MainMenu()
    {
      SceneManager.LoadScene(0);
    }

    public void Play()
    {
      SceneManager.LoadScene(1);
    } 
    

} 
