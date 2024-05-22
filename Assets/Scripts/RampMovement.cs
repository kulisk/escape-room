using UnityEngine;

public class RampMovement : MonoBehaviour
{
    public Transform rampTransform; // Reference to the ramp's Transform component
    [SerializeField] private float closingDuration = 2f; // Duration for the closing movement

    public Vector3 closePosition = new Vector3(-74.7f, 2.6f, 0f); // End position when the ramp is closed
    public Quaternion closeRotation = Quaternion.Euler(0f, 0f, 0f); // End rotation when the ramp is closed

    private Vector3 openPosition = new Vector3(-46.1f, 18.3f, -0.2f); // Start position when the ramp is open
    private Quaternion openRotation = Quaternion.Euler(0f, 0f, 90f); // Start rotation when the ramp is open

    private float startTime; // Time when the movement started
    private bool isClosing = false; // Flag to indicate if the ramp is closing
    private bool isOpening = false; // Flag to indicate if the ramp is opening
    private bool isFrozen = false; // Flag to indicate if the ramp is frozen in place

    private void Start()
    {
        // Ensure the ramp starts at the open position and rotation
        rampTransform.position = openPosition;
        rampTransform.rotation = openRotation;
    }

    private void Update()
    {
        if (Crystals.completed && !isClosing && !isOpening && !isFrozen)
        {
            StartClosing();
        }

        if (isClosing)
        {
            MoveRamp(closePosition, closeRotation);
        }
        else if (isOpening)
        {
            MoveRamp(openPosition, openRotation);
        }
    }

    // Method to start closing the ramp
    public void StartClosing()
    {
        isClosing = true;
        isOpening = false;
        startTime = Time.time; // Record the starting time of the movement
    }

    // Method to move the ramp to the specified position and rotation
    private void MoveRamp(Vector3 targetPosition, Quaternion targetRotation)
    {
        float journeyFraction = (Time.time - startTime) / closingDuration;
        rampTransform.position = Vector3.Lerp(rampTransform.position, targetPosition, journeyFraction);
        rampTransform.rotation = Quaternion.Lerp(rampTransform.rotation, targetRotation, journeyFraction);

        // Check if the movement has completed
        if (journeyFraction >= 1f)
        {
            if (isClosing)
            {
                isClosing = false;
                isFrozen = true; // Ramp is now frozen in place
            }
            else if (isOpening)
            {
                isOpening = false;
            }
        }
    }
}
