using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float jump = 0.0f;
    public float force = 10000f;
    public int pitch = 5;
    public int roll = 5;
    public int turn = 5;
    public bool flying;
    public float velocity;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        velocity = gameObject.GetComponent<Rigidbody>().velocity.y / Time.deltaTime;
        flying = velocity > 10 || velocity < -10;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, pitch);
        }

        if (Input.GetKey(KeyCode.D))
        {

            transform.Rotate(Vector3.back, pitch);
            
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right, roll);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.left, roll);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down, roll);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, roll);
        }


        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.Space))
        {
                rigidbody.AddForce(gameObject.transform.up * force);

        }


        
        
    }

}
