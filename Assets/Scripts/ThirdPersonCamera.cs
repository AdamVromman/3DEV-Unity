using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirToCombatLookAt = orientation.position - new Vector3(transform.position.x, orientation.position.y, transform.position.z);
        orientation.forward = dirToCombatLookAt.normalized;


        playerObj.forward = dirToCombatLookAt.normalized;
    }
}
