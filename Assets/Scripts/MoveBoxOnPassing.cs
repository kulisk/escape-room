using UnityEngine;

public class MoveBoxOnPassing : MonoBehaviour
{
    public Vector3 startCoordinates; // Οι συντεταγμένες της αρχικής θέσης του κουτιού
    public Vector3 endCoordinates; // Οι συντεταγμένες της τελικής θέσης του κουτιού
    public string playerTag = "Player"; // Η ετικέτα του παίκτη
    public Collider passingCollider; // Το κολλάιντζ του σημείου που πρέπει να περάσει ο παίκτης για να ενεργοποιηθεί η μετακίνηση
    public float moveSpeed = 1f; // Η ταχύτητα με την οποία θα κινείται το κουτί

    private bool isMoving = false;
    private bool playerInside = false;

    private void Update()
    {
        if (isMoving)
        {
            MoveBox();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag) && other == passingCollider)
        {
            playerInside = true;
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag) && other == passingCollider)
        {
            playerInside = false;
        }
    }

    private void MoveBox()
    {
        if (playerInside)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endCoordinates, step);

            if (transform.position == endCoordinates)
            {
                isMoving = false;
            }
        }
    }

    void Start()
    {
        // Set the initial position of the box
        transform.position = startCoordinates;
    }
}
