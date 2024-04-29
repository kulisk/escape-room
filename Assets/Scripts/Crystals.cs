using UnityEngine;
using System.Collections.Generic;

public class Crystals : MonoBehaviour
{
    [SerializeField] private List<string> correctTags = new List<string> { "Crystal1", "Crystal2", "Crystal3", "Crystal4" }; // Correct tags to be obtained
    private List<string> obtainedTags; // List to store obtained tags

    private void Start()
    {
        obtainedTags = new List<string>();
    }

    // Method to call when interacting with objects
    public void InteractWithTag(string tag)
    {
        // Check if the tag is one of the correct tags
        if (correctTags.Contains(tag))
        {
            // Add the tag to the list of obtained tags
            obtainedTags.Add(tag);

            // Check if the obtained tags match the correct tags in sequence
            if (CheckTagsMatch())
            {
                PuzzleCompleted();
            }
            else
            {
                ResetPlayerSequence();
            }
        }
    }

    // Method to check if the obtained tags match the correct tags in sequence
    private bool CheckTagsMatch()
    {
        if (obtainedTags.Count != correctTags.Count)
            return false;

        for (int i = 0; i < correctTags.Count; i++)
        {
            if (obtainedTags[i] != correctTags[i])
                return false;
        }

        return true;
    }

    // Method to reset the player's tag list
    private void ResetPlayerSequence()
    {
        obtainedTags.Clear();
    }

    // Method to call when the puzzle is completed
    private void PuzzleCompleted()
    {
        // Add your puzzle completion logic here
    }
}