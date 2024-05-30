using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public Transform doorTransform; // Reference to the door's Transform component

    [SerializeField] private float openingDuration = 9000000f; // Duration for the opening movement in seconds (15 minutes)
    [SerializeField] private float closingDuration = 5f; // Duration for the closing movement in seconds

    public Vector3 openPosition = new Vector3(-145f, 70f, 0f); // Position when the door is open
    public Vector3 closePosition = new Vector3(-145f, 20f, 0f); // Position when the door is closed

    private float startTime; // Time when the movement started
    private bool isClosing = false; // Flag to indicate if the door is closing
    private bool isOpening = false; // Flag to indicate if the door is opening
    private bool isFrozen = false; // Flag to indicate if the door is frozen in place

    private void Start()
    {
        // Start closing the door immediately
        StartClosing();
    }

    private void Update()
    {
        if (Crystals.completed && !isOpening && !isFrozen)
        {
            StartOpening();
        }

        if (isClosing)
        {
            MoveDoor(closePosition, closingDuration);
        }
        else if (isOpening)
        {
            MoveDoor(openPosition, openingDuration);
        }
    }

    // Method to start closing the door
    public void StartClosing()
    {
        isClosing = true;
        isOpening = false;
        startTime = Time.time; // Record the starting time of the movement
    }

    // Method to start opening the door
    public void StartOpening()
    {
        isClosing = false;
        isOpening = true;
        startTime = Time.time; // Record the starting time of the movement
    }

    // Method to move the door to the specified position with the given duration
    private void MoveDoor(Vector3 targetPosition, float duration)
    {
        float journeyFraction = (Time.time - startTime) / duration;
        doorTransform.position = Vector3.Lerp(doorTransform.position, targetPosition, journeyFraction);

        // Check if the movement has completed
        if (journeyFraction >= 1f)
        {
            if (isClosing)
            {
                isClosing = false;
                isFrozen = true; // Door is now frozen in place
            }
            else if (isOpening)
            {
                isOpening = false;
            }
        }
    }
}
