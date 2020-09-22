using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float tumble;
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Vector3 angularVelocity = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
        rigidbody.angularVelocity = angularVelocity * tumble;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
