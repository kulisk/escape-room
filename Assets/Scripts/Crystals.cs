using UnityEngine;
using System.Collections.Generic;

public class Crystals : MonoBehaviour
{
    [SerializeField] private List<int> correctSequence = new List<int> { 3, 1, 4, 2 }; // Correct sequence of button presses
    private List<int> playerSequence; // Sequence of button presses by the player
    private DoorController doorController; // Reference to the DoorController

    private void Start()
    {
        playerSequence = new List<int>();
        doorController = FindObjectOfType
        <DoorController>(); // Find the DoorController in the scene
    }

    // Method to call when a button is pressed
    public void ButtonPressed(int buttonIndex)
    {
        // Check if the button pressed is the next in the correct sequence
        if (correctSequence[playerSequence.Count] == buttonIndex)
        {
            playerSequence.Add(buttonIndex);
            if (playerSequence.Count == correctSequence.Count)
            {
                // Puzzle completed
                PuzzleCompleted();
            }
        }
        else
        {
            // Incorrect button pressed, handle accordingly
            // For example, reset the playerSequence or display a message
        }
    }

    // Method to call when the puzzle is completed
    private void PuzzleCompleted()
    {
        Debug.Log("Puzzle Completed!");
        
        // Stop the door from closing if it's already closing
        if (doorController != null)
        {
            doorController.StopClosing();
        }
        
        // Start opening the door upwards
        if (doorController != null)
        {
            doorController.StartOpening();
        }
    }
}