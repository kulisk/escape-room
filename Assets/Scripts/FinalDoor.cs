using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public Transform doorTransform; // Reference to the door's Transform component
    [SerializeField] private float closingDuration = 900f; // Duration of door closing in seconds (15 minutes)
    [SerializeField] private float openingDuration = 5f; // Duration of door opening in seconds

    public Vector3 closePosition; // Οι συντεταγμένες της πόρτας όταν είναι κληστή

    private Vector3 openPosition; // Οι συντεταγμένες της πόρτας όταν είναι ανοιχτή

    private float closingStartTime; // Time when the door started closing
    private float openingStartTime; // Time when the door started opening
    private bool isClosing = true; // Flag to indicate if the door is closing

    private bool isMoving = false;// Αν το αντικείμενο μετακινείται ή όχι


    private void Start()
    {
        closingStartTime = Time.time; // Initialize closing start time
        openingStartTime = Time.time; // Initialize opening start time
        Vector3 openPosition = new Vector3(doorTransform.position.x, doorTransform.position.y, doorTransform.position.z);// Οι συντεταγμένες της πόρτας όταν είναι ανοιχτή
    }

    private void Update()
    {
        if (isClosing==true && isMoving==true)
        {
            float journeyFraction = (Time.time - closingStartTime) / closingDuration;
            doorTransform.position = Vector3.MoveTowards(doorTransform.position, closePosition, journeyFraction * Vector3.Distance(doorTransform.position, closePosition));

            if (journeyFraction >= closingDuration)
            {
                // Εάν έχει φτάσει στον προορισμό, σταματάμε τη μετακίνηση
                isMoving = false;
            }

        }
        else if (isClosing==false && isMoving==true)
        {
            float journeyFraction = (Time.time - openingStartTime) / openingDuration;
            doorTransform.position = Vector3.MoveTowards(doorTransform.position, openPosition, journeyFraction * Vector3.Distance(doorTransform.position, openPosition));


            if (journeyFraction >= openingDuration)
            {
                // Εάν έχει φτάσει στον προορισμό, σταματάμε τη μετακίνηση
                isMoving = false;
            }
        }
    }

    // Method to start closing the door
    public void StartClosing()
    {
        if(isMoving==false && isClosing==false)//Έτσι ώστε να μην το ξανά καλέσει όταν ήδη κλήνει
        {
            isClosing = true;
            isMoving = true;
            closingStartTime = Time.time; // Reset closing start time
        }
    }

    // Method to start opening the door
    public void StartOpening()
    {
        if(isMoving==true && isClosing==true)//για να ξεκινήσει να ανοίγει μόνο όταν θα είναι στην διάρκεια που κλήνει
        {
            isClosing = false;
            isMoving= true;
            openingStartTime = Time.time; // Reset opening start time
        }
    }

}