using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject GameOverText;

    void Start()
    {
        GameOverText.SetActive(false);
    }

    public void GameOver() 
    {
        Time.timeScale = 0.0f;
        GameOverText.SetActive(true);
    }
}
