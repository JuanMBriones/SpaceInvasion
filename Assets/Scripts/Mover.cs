using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    private Rigidbody rigidbodyBullet;
    public float speed;

    private void Awake()
    {
        rigidbodyBullet = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rigidbodyBullet.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(rigidbodyBullet.position.z >= 70 || rigidbodyBullet.position.z<=-30)
        {
            Destroy(rigidbodyBullet.gameObject);
        }
    }
}
