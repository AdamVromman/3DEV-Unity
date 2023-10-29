using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;
    public Transform aimPoint;
    public Transform ball;

    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    { 

        Vector3 dirToaimPoint = aimPoint.position - new Vector3(transform.position.x, transform.position.y, transform.position.z);
        orientation.forward = dirToaimPoint.normalized;

        playerObj.forward = dirToaimPoint.normalized;

    }
}
