using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject winText;
    private float timeRemaining = 60f;  
    private bool timerIsRunning = false;
    public GameObject player;
    

    void Start()
    {
        // Start the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                EndGame();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;  // To account for the fractional part
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("Time Left: {0:00}:{1:00}", minutes, seconds);
    }

    void EndGame()
    {
        winText.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        winText.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }
}
