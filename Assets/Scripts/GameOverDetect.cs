using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverDetect : MonoBehaviour
{
    public LevelManager levelManager;
    public bool GameOver = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.position.y < transform.position.y)
        {
            GameOver = true;
            levelManager.GameOver();
        }
    }
}
