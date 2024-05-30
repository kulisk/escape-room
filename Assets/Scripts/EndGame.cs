using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGame : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's Transform
    public Vector3 targetPosition = new Vector3(-145, 0, 0); // Target position
    public Canvas endGameCanvas; // Reference to the end game Canvas

    public bool gameEnded = false;
    
    void Start()
    {
        // Ensure the end game canvas is initially disabled
        endGameCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!gameEnded && playerTransform.position.x <= targetPosition.x)
        {
            TriggerEndGame();
        }

        if (gameEnded && Input.GetKeyDown(KeyCode.Space))
        {
            Application.Quit();
        }
    }

    void TriggerEndGame()
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

        // Show the end game canvas and message
        endGameCanvas.gameObject.SetActive(true);

        gameEnded = true;
    }
}
