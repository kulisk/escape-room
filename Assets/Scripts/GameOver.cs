using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public Canvas lossCanvas; // Reference to the loss Canvas
    public Button retryButton; // Reference to the retry Button
    public float timerDuration = 900000f; // Timer duration in seconds (15 minutes)
    public TextMeshProUGUI timerText; // Reference to the timer Text

    private bool gameLost = false;
    private float currentTime;

    void Start()
    {
        // Ensure the loss canvas is initially disabled
        lossCanvas.gameObject.SetActive(false);

        // Add a listener to the retry button to restart the scene
        retryButton.onClick.AddListener(RetryGame);

        // Initialize the timer
        currentTime = timerDuration;
    }

    void Update()
    {
        // Update the timer
        currentTime -= Time.deltaTime;

        // Update the timer text display
        UpdateTimerText();

        // Check if the timer has reached zero
        if (!gameLost && currentTime <= 0)
        {
            TriggerLoss();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TriggerLoss()
    {
        // Disable all other scripts (excluding this one)
        MonoBehaviour[] allScripts = FindObjectsOfType<MonoBehaviour>();
        foreach (MonoBehaviour script in allScripts)
        {
            if (script != this)
            {
                script.enabled = false;
            }
        }

        // Show the loss canvas and message
        lossCanvas.gameObject.SetActive(true);
        gameLost = true;
    }

    void RetryGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

