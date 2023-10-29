using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    public static bool gamePaused = true;
    
    public static float previousRecord = 0.0f;
    public static bool gameEnded = false;
    public GameObject startScreenSource;
    public GameObject endScreenSource;
    public GameObject endScreenScoreSource;
    public GameObject timeTrackerSource;
    GameObject startScreen;
    GameObject endScreen;
    GameObject endScreenScore;
    GameObject timeTracker;
    public GameObject canvas;
    public GameObject player;
    public GameObject ball;
    private float startRound = 0.00f;
    public static float roundTime = 0.00f;


    // Start is called before the first frame update
    void Start()
    {

        startScreen = Instantiate(startScreenSource, canvas.transform);
        roundTime = 0.0f;
        startRound = 0.0f; 
        ResetPlayerAndBall();
        PauseGame();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
        if (Input.GetKeyDown(KeyCode.Space) && gamePaused)
        {
            PlayGame();
        }
        if (gameEnded && !gamePaused)
        {
            WinGame();
        }
        if (!gamePaused)
        {
            roundTime = Time.time - startRound;
        }
        if(player.transform.position.y < 0)
        {
            ResetPlayer();
        }

    }

    void WinGame()
    {
        PauseGame();
        if (previousRecord == 0f || previousRecord > roundTime) previousRecord = roundTime;
        if (timeTracker) Destroy(timeTracker);
        if (!endScreen) endScreen = Instantiate(endScreenSource, canvas.transform);
        if (!endScreenScore) endScreenScore = Instantiate(endScreenScoreSource, canvas.transform);
        endScreenScore.GetComponent<TextMeshProUGUI>().text = $"Round Time: {roundTime.ToString("0.00")}\nCurrent Record: {previousRecord.ToString("0.00")}";
    }

    void ResetPlayerAndBall()
    {
        ResetPlayer();
        ball.transform.position = new Vector3(0, 105, 40);
        ball.GetComponent<SphereControls>().ResetMovement();
        ball.GetComponent<SphereControls>().RemoveRepeat();

    }

    void ResetPlayer()
    {
        player.transform.position = new Vector3(0, 100.1f, 0);
        player.transform.rotation = new Quaternion(0, 0, 0, 0);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }


    void PlayGame()
    {
        ResetPlayerAndBall();
        ball.GetComponent<SphereControls>().AddRepeat();
        startRound = Time.time;
        roundTime = 0f;
        Time.timeScale = 1f;


        if (startScreen) Destroy(startScreen);
        if (!timeTracker) timeTracker = Instantiate(timeTrackerSource, canvas.transform);
        if (endScreen) Destroy(endScreen);
        if (endScreenScore) Destroy(endScreenScore);


        gamePaused = false;
        gameEnded = false;
    }

    void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0f;
    }

    void ResetGame()
    {
        if (!startScreen) startScreen = Instantiate(startScreenSource, canvas.transform);
        roundTime = 0.0f;
        startRound = 0.0f;
        ResetPlayerAndBall();
        PauseGame();
        

    }


}
