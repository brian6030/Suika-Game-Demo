using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherMove : MonoBehaviour
{
    public float MoveSpeed;
    [SerializeField] bool inverseMovement;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontalInput, 0.0f, 0.0f);

        // Apply the movement to the Rigidbody
        rb.velocity = movement * MoveSpeed;

        if (inverseMovement) 
        {
            rb.velocity *= -1;
        }
    }
}
