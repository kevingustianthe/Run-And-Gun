using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGenerator : MonoBehaviour
{
    public GameObject theHealthObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnHealth(Vector3 startPosition)
    {
        Instantiate(theHealthObject, startPosition, transform.rotation);
    }
}
