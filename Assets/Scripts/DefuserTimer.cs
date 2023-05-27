using UnityEngine;
using TMPro;

public class DefuserTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject player;
    public GameObject standingObject;
    public float maxTime;
    public float completedTextDuration = 2f;
    private bool isPlayerOnObject;
    private bool alreadyCounted;
    private float timer;
    private float completedTextTimer;
    private bool isDisplayingCompletedText;
    public DefuserCounter defuserCounter;

    private void Start()
    {
        alreadyCounted = false;
        isPlayerOnObject = false;
        timer = 0f;
        completedTextTimer = 0f;
        isDisplayingCompletedText = false;
        UpdateTimerUI();
    }

    private void Update()
    {
        if (isPlayerOnObject)
        {
            timer += Time.deltaTime;

            if (timer >= maxTime)
            {
                // Perform actions when the timer reaches maxTime
                // Add your desired logic here
                DefuseCompleted();
            }
            else
            {
                UpdateTimerUI();
            }
        }

        if (isDisplayingCompletedText)
        {
            completedTextTimer += Time.deltaTime;

            if (completedTextTimer >= completedTextDuration)
            {
                isDisplayingCompletedText = false;
                timerText.text = string.Empty; // Clear the text

                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && other.gameObject.CompareTag("Player"))
        {
            isPlayerOnObject = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player && other.gameObject.CompareTag("Player"))
        {
            isPlayerOnObject = false;
        }
    }

    private void UpdateTimerUI()
    {
        int seconds = Mathf.FloorToInt(timer);
        int milliseconds = Mathf.FloorToInt((timer * 100f) % 100f);

        string timerString = string.Format("{0:0}:{1:00}", seconds, milliseconds);
        timerText.text = timerString;
    }

    private void DefuseCompleted()
    {
        //alreadyCounted = true;
        isDisplayingCompletedText = true;
        timerText.text = "Completed";
        completedTextTimer = 0f;

        if(!alreadyCounted)
        {
            defuserCounter.CountOneDefuser();
            alreadyCounted = true;     
        }

    }
}
