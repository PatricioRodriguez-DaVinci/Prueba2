using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public bool       isLevelCompleted;

    void Start()
    {
        isLevelCompleted = false;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.P)) || isLevelCompleted)
        {
            YouWin();
        }
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Closed");
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        Debug.Log("Game Over");
    }

    void YouWin()
    {
        SceneManager.LoadScene("YouWin");
        Debug.Log("You Win");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log("Level 1");
    }
}
