using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public GameObject player;
    public float yOffset = 2.0f;
    public float zOffset = -5.0f;
    public float Turnspeed = 2.0f;
    public Transform ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, yOffset, zOffset);
        transform.LookAt(ball);
    }
}
