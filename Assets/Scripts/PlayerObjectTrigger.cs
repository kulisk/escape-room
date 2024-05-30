using UnityEngine;

public class PlayerObjectTrigger : MonoBehaviour
{
    public Transform playerTransform; // Το Transform του παίκτη
    public Transform ObjectCollider; // Το Transform του αντικειμένου που θα μετακινηθεί το οποίο θα κάνει το collider
    public Transform ObjectToMove; 
    public float xThreshold = 5f; // Η τιμή x που θα προκαλέσει τη μετακίνηση
    public Vector3 newPosition; // Οι νέες συντεταγμένες του αντικειμένου όταν γίνει η μετακίνηση
    public float duration = 10.0f; // Η διάρκεια της μετακίνησης
    private float startTime; // Ο χρόνος έναρξης της μετακίνησης

    private bool hasMoved = false; // Έχει ήδη γίνει η μετακίνηση
    private bool isMoving = false;// Αν το αντικείμενο μετακινείται ή όχι
    public GameObject door;
   


    void Start()
    {
        // Ορίζουμε τον προορισμό ως την αρχική θέση του αντικειμένου
        Vector3 newPosition = new Vector3(ObjectCollider.position.x, ObjectCollider.position.y, ObjectCollider.position.z);
        door.SetActive(false);
    }

    void Update()
    {
        Move_ObjectCollider();
        Move_ObjectToMove();
        
    }


    void Move_ObjectCollider()
    {
        // Εάν ο παίκτης έχει ξεπεράσει την τιμή x και δεν έχει γίνει ήδη η μετακίνηση
        if (playerTransform.position.x < xThreshold && !hasMoved)
        {
            startTime = Time.time; // Κρατάμε τον χρόνο έναρξης της μετακίνησης

            // Μετακινούμε το αντικείμενο στις νέες συντεταγμένες
            ObjectCollider.position = newPosition;
            // Ορίζουμε ότι έχει γίνει η μετακίνηση
            hasMoved = true;
            isMoving = true;
            door.SetActive(true);
        }
    }

    void Move_ObjectToMove()
    {
        if (isMoving)
        {
            float journeyFraction = (Time.time - startTime) / duration;
            transform.position = Vector3.MoveTowards(transform.position, newPosition, journeyFraction * Vector3.Distance(transform.position, newPosition));
            if (journeyFraction >= duration)
            {
                // Εάν έχει φτάσει στον προορισμό, σταματάμε τη μετακίνηση
                isMoving = false;
            }
        }

    }
}
