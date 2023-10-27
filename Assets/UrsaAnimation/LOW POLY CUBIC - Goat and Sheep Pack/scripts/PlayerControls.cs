using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float jump = 0.0f;
    public float force = 2000f;
    public int pitch = 50;
    public int roll = 50;
    public int turningSpeed = 75;
    public bool flying;
    public float velocity;
    public float allowedForce = 2000.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        velocity = gameObject.GetComponent<Rigidbody>().velocity.y / Time.deltaTime;
        flying = velocity > 10 || velocity < -10;

        if(flying)
        {
            transform.Rotate(Vector3.right, Time.deltaTime * verticalInput * pitch);
            transform.Rotate(Vector3.back, Time.deltaTime * horizontalInput * roll);
        }
        else {
            transform.Translate(Vector3.forward * Time.deltaTime * verticalInput);
            transform.Rotate(Vector3.up, Time.deltaTime * horizontalInput * turningSpeed);
        }
    }

    void FixedUpdate()
    {
        
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.Space))
        {
            jump = Mathf.Min(jump + 0.1f, 10);

        }
        else
        {
            jump = Mathf.Max(jump - 0.1f, 0);
        }


        if(velocity < allowedForce)
        {
            rigidbody.AddForce(Vector3.up * jump * force);
        }
        
    }

}
