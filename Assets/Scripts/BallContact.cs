using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallContact : MonoBehaviour
{
    [SerializeField] GameObject convertTargetObj;
    [SerializeField] int score;

    ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.Find("SceneManager").GetComponent<ScoreManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(gameObject.tag))
        {
            /*
            int instance = gameObject.GetInstanceID();
            int colInstance = collision.gameObject.GetInstanceID();
  
            if(instance > colInstance && convertTargetObj != null) 
            {
                // Get the collision position
                Vector3 collisionPosition = collision.contacts[0].point;

                // Instantiate the cube at the collision position
                Instantiate(convertTargetObj, collisionPosition, Quaternion.identity);

                // Add score
                scoreManager.AddScore(score);
            }
            */

            if (collision.transform.position.y > transform.position.y)
            {
                if (convertTargetObj != null)
                {
                    // Get the collision position
                    Vector3 collisionPosition = collision.contacts[0].point;

                    // Instantiate position
                    Vector3 instantiatePoint = (transform.position + collisionPosition) / 2;
                    Instantiate(convertTargetObj, instantiatePoint, Quaternion.identity);
                }
                // Add score
                scoreManager.AddScore(score);
            }

            Destroy(collision.gameObject);
        }
    }
}
