using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public float[] spawnProbabilities;
    [SerializeField] Transform spawnTransform;

    [SerializeField] float spawnInterval = 1.0f;
    [SerializeField] GameObject initialSpawnObject;
    GameObject launchObject;
    GameObject instantiatedObject;

    Vector3 gravityDirection = new Vector3(0, -1, 0);
    [SerializeField] float forceMagnitude = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        InitialSpawn();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody rb = launchObject.GetComponent<Rigidbody>();
            launchObject.transform.parent = null;

            rb.isKinematic = false;
            rb.AddForce(gravityDirection * forceMagnitude);

            StartCoroutine(WaitForSpawn());
        }
    }

    IEnumerator WaitForSpawn() 
    {
        yield return new WaitForSeconds(spawnInterval);
        SwapPosition();
        Spawn();
    }

    void Spawn() 
    {
        float randomValue = Random.value; // From 0 - 1
        Debug.Log(randomValue);

        for (int i = 0; i < spawnObjects.Length; i++) 
        {
            if (randomValue < 1 - spawnProbabilities[i])
            {
                print(i + 1);

                instantiatedObject = Instantiate(spawnObjects[i], spawnTransform.position, Quaternion.identity);
                instantiatedObject.transform.parent = spawnTransform;
                instantiatedObject.GetComponent<Rigidbody>().isKinematic = true;
                break;
            }
        }
    }

    void InitialSpawn() 
    {
        launchObject = Instantiate(initialSpawnObject, transform.position, Quaternion.identity);
        launchObject.transform.parent = transform;
        launchObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    void SwapPosition() 
    {
        launchObject = instantiatedObject;
        launchObject.transform.parent = transform;
        launchObject.transform.position = transform.position;
    }
}
