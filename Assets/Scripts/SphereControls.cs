using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControls : MonoBehaviour
{

    public float speed = 10.0f;
    public Vector3 currentPosition = new Vector3();
    public Vector3 newPosition = new Vector3();
    public float time;
    public Transform player;
    public float xyDiff = 0.0f;
    public float zDiff = 0.0f;
    public float movingTime = 2.0f;
    public float radius = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Move", 0, movingTime);
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        transform.position = Vector3.Lerp(currentPosition, newPosition, EaseInOut(time / movingTime));
    }

    void Move()
    {

        currentPosition = transform.position;
        if (isBallTooFar(currentPosition, player.position))
        {
            MoveTowardsPlayer();
        }
        else
        {
            MoveAwayFromPlayer();
        }
        time = 0;
    }

    float EaseIn(float t)
    {
        return t * t;
    }

    float Flip(float x)
    {
        return 1 - x;
    }

    float EaseOut(float t)
    {
        return Flip(Mathf.Pow(Flip(t), 2));
    }

    float EaseInOut(float t)
    {
        return Mathf.Lerp(EaseIn(t), EaseOut(t), t);
    }

    void MoveAwayFromPlayer()
    {
        float randomX = Random.value * xyDiff;
        float randomY = Random.value * xyDiff;
        float randomZ = Random.value * zDiff;
        Vector3 playerPosition = player.position;
        Vector3 direction = (transform.position - playerPosition).normalized + new Vector3(randomX, randomY, randomZ);
        newPosition = transform.position + direction;
    }

    void MoveTowardsPlayer()
    {
        float randomX = Random.value * xyDiff;
        float randomY = Random.value * xyDiff;
        float randomZ = Random.value * zDiff;
        Vector3 playerPosition = player.position;
        Vector3 direction = (transform.position - playerPosition).normalized + new Vector3(randomX, randomY, randomZ);
        newPosition = transform.position - direction;
    }

    bool isBallTooFar(Vector3 ball, Vector3 player)
    {
        return Vector3.Distance(ball, player) > radius; 
    }

}