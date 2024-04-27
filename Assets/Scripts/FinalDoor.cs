using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public Transform doorTransform; // Reference to the door's Transform component
    [SerializeField] private float closingDuration = 900f; // Duration of door closing in seconds (15 minutes)
    [SerializeField] private float openingDuration = 5f; // Duration of door opening in seconds
    [SerializeField] private float closingSpeed = 1f; // Speed of door closing in x-axis
    [SerializeField] private float openingSpeed = 1f; // Speed of door opening in x-axis
    private float closingStartTime; // Time when the door started closing
    private float openingStartTime; // Time when the door started opening
    private bool isClosing = false; // Flag to indicate if the door is closing
    private bool isOpening = false; // Flag to indicate if the door is opening

    private void Start()
    {
        closingStartTime = Time.time; // Initialize closing start time
        openingStartTime = Time.time; // Initialize opening start time
    }

    private void Update()
    {
        if (isClosing)
        {
            float elapsedTime = Time.time - closingStartTime;
            float newXPosition = doorTransform.position.x - (closingSpeed * Time.deltaTime);
            Vector3 newPosition = new Vector3(newXPosition, doorTransform.position.y, doorTransform.position.z);
            doorTransform.position = newPosition;

            if (elapsedTime >= closingDuration)
            {
                isClosing = false;
            }
        }
        else if (isOpening)
        {
            float elapsedTime = Time.time - openingStartTime;
            float newXPosition = doorTransform.position.x + (openingSpeed * Time.deltaTime);
            Vector3 newPosition = new Vector3(newXPosition, doorTransform.position.y, doorTransform.position.z);
            doorTransform.position = newPosition;

            if (elapsedTime >= openingDuration)
            {
                isOpening = false;
            }
        }
    }

    // Method to start closing the door
    public void StartClosing()
    {
        isClosing = true;
        closingStartTime = Time.time; // Reset closing start time
    }

    // Method to start opening the door
    public void StartOpening()
    {
        isOpening = true;
        openingStartTime = Time.time; // Reset opening start time
    }
}
