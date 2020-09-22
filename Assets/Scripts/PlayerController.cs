using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public float xMin, xMax, zMin, zMax;
    private Rigidbody rigidbody;

    public GameObject bullet;
    public Transform bulletSpawn;
    
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);

        rigidbody.velocity = move * speed;
        rigidbody.position = new Vector3(Mathf.Clamp(rigidbody.position.x, xMin, xMax), 0, Mathf.Clamp(rigidbody.position.z, zMin, zMax)); // -1 -> 12 o 18| -21 -> 21
        rigidbody.rotation = Quaternion.Euler(0, 0, -rigidbody.velocity.x * tilt);
    }
}
