using UnityEngine;
using TMPro;

public class DefuserTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject player;
    public GameObject standingObject;
    public float maxTime;

    private bool isPlayerOnObject;
    private float timer;

    private void Start()
    {
        isPlayerOnObject = false;
        timer = 0f;
        UpdateTimerUI();
    }

    private void Update()
    {
        if (isPlayerOnObject)
        {
            timer += Time.deltaTime;

            if (timer >= maxTime)
            {
                timer = maxTime;
                // Perform actions when the timer reaches 4 seconds
                // Add your desired logic here
            }

            UpdateTimerUI();
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
        int milliseconds = Mathf.FloorToInt((timer * 1000f) % 1000f);

        string timerString = string.Format("{0:0}:{1:00}", seconds, milliseconds);
        timerText.text = timerString;
    }
}
